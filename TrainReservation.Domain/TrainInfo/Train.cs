using System.Collections.Generic;

namespace TrainReservation.Domain.TrainInfo
{
    public class Train
    {
        public Train()
        {
            Vagonlar = new HashSet<Vagon>();
        }
        public string Ad { get; set; }
        public ICollection<Vagon> Vagonlar { get; set; }
        //Vagon Kapasitesi kadar rezervasyon yapılabileceği için Vagon kapasitesiyle aynı veri tipi kullanılmıştır. Ancak gerçek şartlarda byte veri tipi yeterli olabilir.
        public short RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}