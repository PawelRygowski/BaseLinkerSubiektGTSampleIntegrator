namespace BaseSubjektIntegrator.BaseLinker
{
	public class BaseLinkerProductModel
	{
        public string Storage { get; set; }
        public string StorageId { get; set; }
        public string OrderProductId { get; set; }
        public string ProductId { get; set; }
        public string VariantId { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }
        public string Sku { get; set; }
        public string Ean { get; set; }
        public string AuctionId { get; set; }
        public int PriceBrutto { get; set; }
        public int TaxRate { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}
