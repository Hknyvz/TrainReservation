using System.Collections.Generic;

namespace TrainReservation.Domain.TrainInfo
{
    public class Train
    {
        public Train()
        {
            Vagonlar = new List<Wagon>();
        }
        public string Ad { get; set; }
        public IEnumerable<Wagon> Vagonlar { get; set; }
    }
}