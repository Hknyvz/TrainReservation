using System.Text.Json;

namespace TrainReservation.Domain.ResponseObject
{
    public class ErrorObject
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
