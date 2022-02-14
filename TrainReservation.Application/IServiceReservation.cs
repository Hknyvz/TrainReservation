using TrainReservation.Domain.RequestObjects;
using TrainReservation.Domain.ResponseObject;

namespace TrainReservation.Application
{
    public interface IServiceReservation
    {
        ResponseReservation CheckReservation(RequestReservation requestReservation);
    }
}
