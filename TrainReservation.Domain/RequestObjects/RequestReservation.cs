using TrainReservation.Domain.TrainInfo;

namespace TrainReservation.Domain.RequestObjects
{
    public class RequestReservation
    {
        public Train Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
