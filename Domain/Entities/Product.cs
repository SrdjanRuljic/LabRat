namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;

        #region Collections

        public virtual ICollection<ProductAnalysisTypes> ProductAnalysisTypes { get; set; } = null!;

        #endregion Collections
    }
}