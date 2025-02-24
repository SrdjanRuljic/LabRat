namespace Application.Common.Interfaces
{
    public interface IAnalysisMessage
    {
        string AnalysisType { get; }
        DateTime DateTime { get; }
        string SerialNumber { get; }
    }
}