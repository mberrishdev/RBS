using Common.Repository.Repository;
using Common.Repository.UnitOfWork;
using RBS.Application.Exceptions;
using RBS.Application.Models.QRModels;
using RBS.Application.Models.ReservationModels;
using RBS.Application.Services.PlatformNotifications;
using RBS.Application.Services.QrCodeServices;
using RBS.Application.Services.ReservationRemainders;
using RBS.Application.Services.Reservations.Responses;
using RBS.Application.Services.RestaurantNotifications;
using RBS.Application.Services.Restaurants;
using RBS.Application.Services.Tables;
using RBS.Application.Services.UserServices;
using RBS.Domain.Enums;
using RBS.Domain.PlatformNotifications.Commands;
using RBS.Domain.ReservationReminders.Commands;
using RBS.Domain.Reservations;
using RBS.Domain.Reservations.Commands;
using RBS.Domain.RestaurantNotifications.Commands;

namespace RBS.Application.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IQrCodeService _qrCodeService;
        private readonly ITableService _tableService;
        private readonly IUserService _userService;
        private readonly IRestaurantNotificationService _restaurantNotificationService;
        private readonly IPlatformNotificationService _platformNotificationService;
        private readonly IReservationRemainderService _reservationRemainderService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Reservation> _repository;
        private readonly IQueryRepository<Reservation> _queryRepository;

        public ReservationService(IUnitOfWork unitOfWork, IRepository<Reservation> repository,
            IQueryRepository<Reservation> queryRepository,
            IRestaurantService restaurantService, IQrCodeService qrCodeService,
            ITableService tableService, IUserService userService,
            IRestaurantNotificationService restaurantNotificationService,
            IPlatformNotificationService platformNotificationService,
            IReservationRemainderService reservationRemainderService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _queryRepository = queryRepository;
            _restaurantService = restaurantService;
            _qrCodeService = qrCodeService;
            _tableService = tableService;
            _userService = userService;
            _restaurantNotificationService = restaurantNotificationService;
            _platformNotificationService = platformNotificationService;
            _reservationRemainderService = reservationRemainderService;
            _repository = repository;
        }

        public async Task<ReservationResponse> ResevationCommandHandler(ReservationCommand command, CancellationToken cancellationToken)
        {
            //Todo:check person count
            var restaurant = await _restaurantService.GetById(command.RestaurantId, cancellationToken);
            if (restaurant == null)
                throw new CommandValidationException("Restaurant does not exist");

            var table = await _tableService.GetById(command.TableId, cancellationToken);
            if (table == null)
                throw new CommandValidationException("Table does not exist");

            if (command.DateTime.TimeOfDay < restaurant.OpentTime.TimeOfDay && command.DateTime.TimeOfDay > restaurant.CloseTime.TimeOfDay)
                throw new CommandValidationException($"Restaurant open at {restaurant.OpentTime.TimeOfDay} and close at {restaurant.CloseTime.TimeOfDay}");

            QRModel qrCode = null;

            if (!command.IsUserLogIn)
            {
                int userId = await _userService.RegisterGuestUser(command.GuestUser, cancellationToken);
                command.UserModel = new()
                {
                    UserId = userId,
                };
            }

            using (var scope = await _unitOfWork.CreateScopeAsync(cancellationToken))
            {
                var reservation = new Reservation(command);
                await _repository.InsertAsync(reservation, cancellationToken);

                var frontBaseUrl = "";
                var qrCodeUrl = $"{frontBaseUrl}?ReservationId={reservation.Id}&";

                qrCode = _qrCodeService.GenerateByteArrayQrCode(qrCodeUrl);

                reservation.AddQrCode(qrCode.Data);

                if (command.SendNewsOfRestaurant)
                {
                    CreateRestaurantNotificationCommand createRestaurantNotificatCommand = new()
                    {
                        RestaruantId = command.RestaurantId,
                        UserId = command.UserModel.UserId,
                        NotificationType = NotificationType.NotificationEmail,
                    };

                    await _restaurantNotificationService.CreateRestaurantNotification(createRestaurantNotificatCommand, cancellationToken);
                }

                if (command.SendNewsOfPlatform)
                {
                    CreatePlatformNotificationCommand createPlatformNotificatCommand = new()
                    {
                        UserId = command.UserModel.UserId,
                        NotificationType = NotificationType.NotificationEmail,
                    };

                    await _platformNotificationService.CreatePlatformNotification(createPlatformNotificatCommand, cancellationToken);
                }

                if (command.SendReservationReminders)
                {
                    CreateReservationRemainderCommand createReservationRemainder = new()
                    {
                        Type = NotificationType.EmailPhone,
                        ToBeSentDate = reservation.DateTime.Subtract(TimeSpan.FromMinutes(30)),
                        ReservationId = reservation.Id,
                    };

                    await _reservationRemainderService.CreateReservationRemainder(createReservationRemainder, cancellationToken);
                }

                if (command.AddBookingToCallendar)
                {
                }

                await scope.CompletAsync(cancellationToken);
            }

            return new()
            {
                QrCode = qrCode
            };
        }

        public async Task<List<ResravtionModel>> GetRestaurantReservationsByDay(int restaruantId, DateTime reseravtionDate, CancellationToken cancellationToken)
        {
            var reservations = await _queryRepository.GetListAsync(predicate: x => x.RestaurantId == restaruantId && x.DateTime.Date == reseravtionDate.Date,
                cancellationToken: cancellationToken);
            return reservations.Select(x => new ResravtionModel(x)).ToList();
        }
    }
}
