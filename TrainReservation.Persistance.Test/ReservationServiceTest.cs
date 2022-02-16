using System;
using System.Collections.Generic;
using System.Linq;
using TrainReservation.Domain.RequestObjects;
using TrainReservation.Domain.ResponseObject;
using TrainReservation.Domain.TrainInfo;
using TrainReservation.Persistance.Services;
using Xunit;

namespace TrainReservation.Persistance.Test
{
    public class ReservationServiceTest : IClassFixture<ReservationService>
    {
        private ReservationService _reservationService { get; set; }
        public ReservationServiceTest()
        {
            _reservationService = new ReservationService();
        }
        public static IEnumerable<object[]> _requestReservations = new List<object[]>
        {
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 50 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 80 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 80 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = true,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = new List<SettlementDetail>
                    {
                        new SettlementDetail{KisiSayisi=3,VagonAdi="Vagon 1"}
                    }
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 69 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 62 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 55 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = true,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = new List<SettlementDetail>
                    {
                        new SettlementDetail{KisiSayisi=1,VagonAdi="Vagon 1"},
                        new SettlementDetail{KisiSayisi=1,VagonAdi="Vagon 2"},
                        new SettlementDetail{KisiSayisi=1,VagonAdi="Vagon 3"}
                    }
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 70 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 63 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 56 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = true,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = false,
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 67 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 60 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 70 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = false,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = new List<SettlementDetail>
                    {
                        new SettlementDetail{KisiSayisi=3,VagonAdi="Vagon 1"},
                    }
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 75 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 65 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 70 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = false,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = false,
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 75 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 65 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 20 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = false,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = new List<SettlementDetail>
                    {
                        new SettlementDetail{KisiSayisi=3,VagonAdi="Vagon 3"},
                    }
                }
            },
            new object[]
            {
                new RequestReservation
                {
                    Tren = new Train
                    {
                        Ad = "Baþkent Ekspres",
                        Vagonlar = new List<Wagon>
                        {
                            new Wagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 75 },
                            new Wagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 61 },
                            new Wagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 20 },
                        }
                    },
                    KisilerFarkliVagonlaraYerlestirilebilir = true,
                    RezervasyonYapilacakKisiSayisi = 3
                },
                new ResponseReservation
                {
                    RezervasyonYapilabilir = true,
                    YerlesimAyrinti = new List<SettlementDetail>
                    {
                        new SettlementDetail{KisiSayisi=2,VagonAdi="Vagon 2"},
                        new SettlementDetail{KisiSayisi=1,VagonAdi="Vagon 3"},
                    }
                }
            },
        };

        [Theory]
        [MemberData(nameof(_requestReservations))]
        public void CheckReservation(RequestReservation requestReservation, ResponseReservation expected)
        {
            ResponseReservation result = _reservationService.CheckReservation(requestReservation);
            Assert.Equal(expected.RezervasyonYapilabilir, result.RezervasyonYapilabilir);
            var expectSettlementDetailList = expected.YerlesimAyrinti.ToList();
            var resultSettlementDetailList = result.YerlesimAyrinti.ToList();
            Assert.Equal(expectSettlementDetailList.Count, resultSettlementDetailList.Count);

            for (int i = 0; i < expectSettlementDetailList.Count; i++)
            {
                Assert.Equal(expectSettlementDetailList[i], resultSettlementDetailList[i]);
            }
        }
    }
}
