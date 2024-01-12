namespace AcmeSys.App.DTOs
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int SubsidiaryId { get; set; }
        public int QuantitySold { get; set; }
        public DateTime SaleDate { get; set; }
    }

}
