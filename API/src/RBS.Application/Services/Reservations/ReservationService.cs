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
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
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
        private readonly IUnitOfWork<Reservation> _unitOfWork;
        private readonly IRepository<Reservation> _repository;

        public ReservationService(IUnitOfWork<Reservation> unitOfWork,
            IRestaurantService restaurantService, IQrCodeService qrCodeService,
            ITableService tableService, IUserService userService,
            IRestaurantNotificationService restaurantNotificationService,
            IPlatformNotificationService platformNotificationService,
            IReservationRemainderService reservationRemainderService)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
            _restaurantService = restaurantService;
            _qrCodeService = qrCodeService;
            _tableService = tableService;
            _userService = userService;
            _restaurantNotificationService = restaurantNotificationService;
            _platformNotificationService = platformNotificationService;
            _reservationRemainderService = reservationRemainderService;
        }

        public async Task<ReservationResponse> ResevationCommandHandler(ReservationCommand command)
        {
            //Todo:check person count
            var restaurant = await _restaurantService.GetById(command.RestaurantId);
            if (restaurant == null)
                throw new CommandValidationException("Restaurant does not exist");

            var table = await _tableService.GetById(command.TableId);
            if (table == null)
                throw new CommandValidationException("Table does not exist");

            if (command.DateTime.TimeOfDay < restaurant.OpentTime.TimeOfDay && command.DateTime.TimeOfDay > restaurant.CloseTime.TimeOfDay)
                throw new CommandValidationException($"Restaurant open at {restaurant.OpentTime.TimeOfDay} and close at {restaurant.CloseTime.TimeOfDay}");

            QRModel qrCode = null;

            if (!command.IsUserLogIn)
            {
                int userId = await _userService.RegisterGuestUser(command.GuestUser);
                command.UserModel = new()
                {
                    UserId = userId,
                };
            }

            var reservation = new Reservation(command);
            await _repository.CreateAsync(reservation);

            var frontBaseUrl = "";
            var qrCodeUrl = $"{frontBaseUrl}?ReservationId={reservation.Id}&";
            try
            {
                qrCode = _qrCodeService.GenerateByteArrayQrCode(qrCodeUrl);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

            reservation.AddQrCode(qrCode.Data);

            if (command.SendNewsOfRestaurant)
            {
                CreateRestaurantNotificationCommand createRestaurantNotificatCommand = new()
                {
                    RestaruantId = command.RestaurantId,
                    UserId = command.UserModel.UserId,
                    NotificationType = NotificationType.NotificationEmail,
                };

                await _restaurantNotificationService.CreateRestaurantNotification(createRestaurantNotificatCommand);
            }

            if (command.SendNewsOfPlatform)
            {
                CreatePlatformNotificationCommand createPlatformNotificatCommand = new()
                {
                    UserId = command.UserModel.UserId,
                    NotificationType = NotificationType.NotificationEmail,
                };

                await _platformNotificationService.CreatePlatformNotification(createPlatformNotificatCommand);
            }

            if (command.SendReservationReminders)
            {
                CreateReservationRemainderCommand createReservationRemainder = new()
                {
                    Type = NotificationType.EmailPhone,
                    ToBeSentDate = reservation.DateTime.Subtract(TimeSpan.FromMinutes(30)),
                    ReservationId = reservation.Id,
                };

                await _reservationRemainderService.CreateReservationRemainder(createReservationRemainder);
            }

            if (command.AddBookingToCallendar)
            {
            }

            await _unitOfWork.CommitAsync();

            return new()
            {
                QrCode = qrCode
            };
        }

        public async Task<List<ResravtionModel>> GetRestaurantReservationsByDay(int restaruantId, DateTime reseravtionDate)
        {
            var reservations = await _repository.GetListAsync(predicate: x => x.RestaurantId == restaruantId && x.DateTime.Date == reseravtionDate.Date);
            return reservations.Select(x => new ResravtionModel(x)).ToList();
        }
    }
}
