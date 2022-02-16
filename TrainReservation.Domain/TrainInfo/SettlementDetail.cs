using System;

namespace TrainReservation.Domain.TrainInfo
{
    public class SettlementDetail : IEquatable<SettlementDetail>
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }

        public bool Equals(SettlementDetail other)
        {
            return VagonAdi.Equals(other.VagonAdi) && KisiSayisi.Equals(other.KisiSayisi);
        }
    }
}