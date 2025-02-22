namespace Domain.Entities
{
    public class AnalysisType
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        #region Collections

        public virtual ICollection<ProductAnalysisTypes> ProductAnalysisTypes { get; set; } = null!;

        #endregion Collections
    }
}