using Microsoft.AspNetCore.Mvc;
using RBS.Application.Services.Reservations;
using RBS.Application.Services.Reservations.Responses;
using RBS.Domain.Reservations.Commands;

namespace RBS.API.Controllers.Reservation
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReservationController : ApiControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        //[ProducesResponseType(ActionResult<ReservationResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ReservationResponse>> RestaurantReservation([FromBody] ReservationCommand command)
        {
            if (command.IsUserLogIn && UserModel == null)
                return Unauthorized();

            if (command.IsUserLogIn)
                command.UserModel = UserModel;

            var response = await _reservationService.ResevationCommandHandler(command);
            return Ok(response);
        }

    }
}
