using System.Collections.Generic;
using TrainReservation.Domain.TrainInfo;

namespace TrainReservation.Domain.ResponseObject
{
    public class ResponseReservation
    {
        public ResponseReservation()
        {
            YerlesimAyrinti = new List<SettlementDetail>();
        }
        public bool RezervasyonYapilabilir { get; set; }
        public IEnumerable<SettlementDetail> YerlesimAyrinti { get; set; }
    }
}
