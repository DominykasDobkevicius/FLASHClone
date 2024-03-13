using FirstLab.src.models;
using FirstLab.src.models.DTOs;

namespace FirstLab.src.interfaces
{
    public interface IAnalyticsDayMapper
    {
        AnalyticsDay TransformDTOtoAnalyticsDay(AnalyticsDayDTO dto);
        AnalyticsDayDTO TransformAnalyticsDayToDTO(AnalyticsDay analyticsDay);
    }
}