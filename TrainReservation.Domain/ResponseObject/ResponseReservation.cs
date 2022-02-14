using System.Collections.Generic;
using TrainReservation.Domain.TrainInfo;

namespace TrainReservation.Domain.ResponseObject
{
    public class ResponseReservation
    {
        public ResponseReservation()
        {
            YerlesimAyrinti = new HashSet<SettlementDetail>();
        }
        public bool RezervasyonYapilabilir { get; set; }
        public ICollection<SettlementDetail> YerlesimAyrinti { get; set; }
    }
}
