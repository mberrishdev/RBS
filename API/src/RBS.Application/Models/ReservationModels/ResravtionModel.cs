using RBS.Domain.Reservations;

namespace RBS.Application.Models.ReservationModels
{
    public class ResravtionModel
    {
        public DateTime DateTime { get; set; }
        public int PersonCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string QrCode { get; set; }
        public int? TableId { get; set; }
        public int ApplicationUserId { get; private set; }
        public int RestaurantId { get; private set; }

        public ResravtionModel(Reservation reservation)
        {
            DateTime = reservation.DateTime;
            PersonCount = reservation.PersonCount;
            SpecialRequest = reservation.SpecialRequest;
            QrCode = reservation.QrCode;
            TableId = reservation.TableId;
            ApplicationUserId = reservation.ApplicationUserId;
            RestaurantId = reservation.RestaurantId;
        }
    }
}
