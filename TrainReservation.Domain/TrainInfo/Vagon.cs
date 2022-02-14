namespace TrainReservation.Domain.TrainInfo
{
    public class Vagon
    {
        public string Ad { get; set; }
        //Gerçek şartlarda bir vagon 255'i geçebilir. Ancak 32767 den fazlada olmayacağı için short veri tipi uygundur.
        public short Kapasite { get; set; }
        public short DoluKoltukAdet { get; set; }
    }
}