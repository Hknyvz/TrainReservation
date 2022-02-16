using System.Collections.Generic;
using System.Linq;
using TrainReservation.Application;
using TrainReservation.Domain.RequestObjects;
using TrainReservation.Domain.ResponseObject;
using TrainReservation.Domain.TrainInfo;

namespace TrainReservation.Persistance.Services
{
    public class ReservationService : IReservationService
    {
        public ResponseReservation CheckReservation(RequestReservation requestReservation)
        {
            IEnumerable<SettlementDetail> settlementDetails = GetConvenientWagon(requestReservation);
            if (settlementDetails.Count() > 0)
            {
                return new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = settlementDetails
                };
            }
            return new ResponseReservation
            {
                RezervasyonYapilabilir = false
            };
        }

        private IEnumerable<SettlementDetail> GetConvenientWagon(RequestReservation requestReservation)
        {
            List<SettlementDetail> convenientWagons = new List<SettlementDetail>();
            var wagonArray = requestReservation.Tren.Vagonlar.ToArray();
            int personCount = requestReservation.RezervasyonYapilacakKisiSayisi;
            for (int i = 0; i < wagonArray.Length; i++)
            {
                int remainingCapacity = (wagonArray[i].Kapasite * 70 / 100) - wagonArray[i].DoluKoltukAdet;
                if (requestReservation.KisilerFarkliVagonlaraYerlestirilebilir)
                {
                    if (remainingCapacity > 0)
                    {
                        convenientWagons.Add(new SettlementDetail
                        {
                            KisiSayisi = personCount > remainingCapacity ? remainingCapacity : personCount,
                            VagonAdi = wagonArray[i].Ad
                        });
                        personCount = personCount > remainingCapacity ? personCount - remainingCapacity : 0;
                    }
                    if (personCount == 0)
                    {
                        break;
                    }
                }
                else
                {
                    if (remainingCapacity >= personCount)
                    {
                        convenientWagons.Add(new SettlementDetail { KisiSayisi = personCount, VagonAdi = wagonArray[i].Ad });
                        personCount = personCount > remainingCapacity ? personCount - remainingCapacity : 0;
                        break;
                    }
                }

            }
            if (personCount > 0)
            {
                convenientWagons.Clear();
            }
            return convenientWagons;
        }
    }
}
