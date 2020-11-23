using System;
using BaseSubjektIntegrator.BaseLinker;
using InsERT;

namespace BaseSubjektIntegrator.SubiektGT
{
	public class SubiektGTConnector
	{
		private GTClass gt;
		public SubiektGTConnector(Configuration configuration)
		{
			this.gt = new GTClass();
			Configure(configuration);
		}

		public void Configure(Configuration configuration)
		{
			this.gt.Produkt = ProduktEnum.gtaProduktSubiekt;
			this.gt.Serwer = configuration.SGTServer;
			this.gt.Baza = configuration.SGTDatabaseName;
			this.gt.Autentykacja = AutentykacjaEnum.gtaAutentykacjaMieszana;
			this.gt.Uzytkownik = configuration.SGTDBUserName;
			this.gt.UzytkownikHaslo = configuration.SGTDBUserPassword;
			this.gt.Operator = configuration.SGTOperator;
			this.gt.OperatorHaslo = configuration.SGTOperatorPassword;
		}

		public void SendOrder(BaseLinkerOrderModel order)
		{
			Subiekt subiekt = this.gt.Uruchom((int)UruchomDopasujEnum.gtaUruchomDopasuj, (int)UruchomEnum.gtaUruchom) as Subiekt;
			
			// sprawdzalbym tutaj czy nie tworzymy duplikatu ale mozna uzywac metody Istnieje() tylko po Id lub odnoszac sie 
			// do raw data w bazie 
			SuDokument suDokument = subiekt.SuDokumentyManager.DodajZK();
			suDokument.KontrahentId = getKontrahentId(subiekt, order);

			Console.WriteLine("Adding order positions...");
			suDokument.NumerOryginalny = order.OrderId;

			foreach (BaseLinkerProductModel product in order.Products)
			{
				SuPozycja pozycja = suDokument.Pozycje.DodajUslugeJednorazowa() as SuPozycja;
				pozycja.UslJednNazwa = product.Name;
				pozycja.CenaBruttoPrzedRabatem = product.PriceBrutto;
				pozycja.IloscJm = product.Quantity;
				pozycja.VatId = getVatId(product.TaxRate);
			}

			suDokument.Zapisz();
			suDokument.Wyswietl();
			suDokument.Zamknij();
		}

		private int getKontrahentId(Subiekt subiekt, BaseLinkerOrderModel order)
		{
			Kontrahent kontrahent;

			if (!subiekt.Kontrahenci.Istnieje(order.UserLogin))
			{
				Console.WriteLine("Creating nonexisting Kontrahent");
				kontrahent = subiekt.KontrahenciManager.DodajKontrahenta();
				kontrahent.Symbol = order.UserLogin; 
				kontrahent.NazwaPelna = order.DeliveryFullname;
				kontrahent.Nazwa = order.DeliveryFullname;
				kontrahent.Ulica = order.DeliveryAddress;
				kontrahent.KodPocztowy = order.DeliveryPostcode;
				kontrahent.Miejscowosc = order.DeliveryCity;

				kontrahent.Email = order.Email;
				kontrahent.Zapisz();
				kontrahent.Zamknij();
			}
			Console.WriteLine("Getting kontrahentId");
			kontrahent = subiekt.Kontrahenci.Wczytaj(order.UserLogin) as Kontrahent;
			return (int)kontrahent.Identyfikator;
		}

		private int getVatId(int taxRate)
		{ 
			//z pelna swiadomoscia problemow
			switch (taxRate)
			{
				case 22 : return 1;
				case 7: return 2;
				case 3: return 3;
				case 0: return 4;
				case 5: return 8;
				case 6: return 10;
				case 23: return 100001;
				default: return 100001;
			}
		}
	}
}