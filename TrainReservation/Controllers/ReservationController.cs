using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservation.Application;
using TrainReservation.Domain.RequestObjects;

namespace TrainReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService { get; }
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult CheckReservation(RequestReservation requestReservation)
        {
            return Ok(_reservationService.CheckReservation(requestReservation));
        }
    }
}
