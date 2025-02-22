namespace Domain.Entities
{
    public class ProductAnalysisTypes
    {
        public AnalysisType AnalysisType { get; set; } = null!;
        public long AnalysisTypeId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid ProductId { get; set; }
    }
}