using System.Collections.Generic;

namespace BaseSubjektIntegrator.BaseLinker
{
	public class BaseLinkerOrderModel
	{
        public int OrderId { get; set; }
        public string ShopOrderId { get; set; }
        public string ExternalOrderId { get; set; }
        public string OrderSource { get; set; }
        public string OrderSourceId { get; set; }
        public string OrderSourceInfo { get; set; }
        public int OrderStatusId { get; set; }
        public bool Confirmed { get; set; }
        public int DateConfirmed { get; set; }
        public int DateAdd { get; set; }
        public int DateInStatus { get; set; }
        public string UserLogin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserComments { get; set; }
        public string AdminComments { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentMethodCod { get; set; }
        public int PaymentDone { get; set; }
        public string DeliveryMethod { get; set; }
        public int DeliveryPrice { get; set; }
        public string DeliveryPackageModule { get; set; }
        public string DeliveryPackageNr { get; set; }
        public string DeliveryFullname { get; set; }
        public string DeliveryCompany { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryPostcode { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryCountryCode { get; set; }
        public string DeliveryPointId { get; set; }
        public string DeliveryPointName { get; set; }
        public string DeliveryPointAddress { get; set; }
        public string DeliveryPointPostcode { get; set; }
        public string DeliveryPointCity { get; set; }
        public string InvoiceFullname { get; set; }
        public string InvoiceCompany { get; set; }
        public string InvoiceNip { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceCity { get; set; }
        public string InvoicePostcode { get; set; }
        public string InvoiceCountry { get; set; }
        public string InvoiceCountryCode { get; set; }
        public string WantInvoice { get; set; }
        public string ExtraField1 { get; set; }
        public string ExtraField2 { get; set; }
        public string OrderPage { get; set; }
        public int PickState { get; set; }
        public int PackState { get; set; }
        public List<BaseLinkerProductModel> Products { get; set; }
    }
}