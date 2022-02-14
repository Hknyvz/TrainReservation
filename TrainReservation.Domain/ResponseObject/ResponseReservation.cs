using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
