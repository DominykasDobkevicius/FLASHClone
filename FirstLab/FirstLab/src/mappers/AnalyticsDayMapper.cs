using FirstLab.src.interfaces;
using FirstLab.src.models.DTOs;
using FirstLab.src.models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FirstLab.src.mappers;

public class AnalyticsDayMapper : IAnalyticsDayMapper
{
    IFactoryContainer _factoryContainer;

    public AnalyticsDayMapper(IFactoryContainer factoryContainer)
    {
        _factoryContainer = factoryContainer;
    }
    public AnalyticsDayDTO TransformAnalyticsDayToDTO(AnalyticsDay analyticsDay)
    {
        AnalyticsDayDTO set = _factoryContainer!.CreateObject<AnalyticsDayDTO>();

        set.Date = analyticsDay.Date;
        set.FlashcardSetsEdited = analyticsDay.FlashcardSetsEdited;
        set.FlashcardSetsPlayed = analyticsDay.FlashcardSetsPlayed;

        return set;
    }

    public AnalyticsDay TransformDTOtoAnalyticsDay(AnalyticsDayDTO dto)
    {
        AnalyticsDay set = _factoryContainer!.CreateObject<AnalyticsDay>();

        set.Date = dto.Date;
        set.FlashcardSetsEdited = dto.FlashcardSetsEdited;
        set.FlashcardSetsPlayed = dto.FlashcardSetsPlayed;

        return set;
    }
}
