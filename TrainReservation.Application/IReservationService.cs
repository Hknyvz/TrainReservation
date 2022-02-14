using TrainReservation.Domain.RequestObjects;
using TrainReservation.Domain.ResponseObject;

namespace TrainReservation.Application
{
    public interface IReservationService
    {
        ResponseReservation CheckReservation(RequestReservation requestReservation);
    }
}
