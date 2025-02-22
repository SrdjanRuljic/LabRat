namespace Application.Common.Interfaces
{
    public interface IAnalysis
    {
        Domain.Enums.AnalysisTypes AnalysisType { get; }
        DateTime DateTime { get; }
        string SerialNumber { get; }
    }
}