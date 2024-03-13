using FirstLab.src.interfaces;
using FirstLab.src.models;
using FirstLab.src.models.DTOs;
using FirstLab.src.utilities;
using FirstLab.src.controllers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using FirstLab.src.mappers;

namespace FirstLab.src.services;

public class AnalyticsViewService : IAnalyticsViewService
{
    readonly IDatabaseRepository _databaseRepository;
    readonly IAnalyticsDayMapper _analyticsDayMapper;

    public AnalyticsViewService(IDatabaseRepository databaseRepository, IAnalyticsDayMapper analyticsDayMapper)
    {
        _databaseRepository = databaseRepository;
        _analyticsDayMapper = analyticsDayMapper;
    }

    public async Task<ObservableCollection<AnalyticsDay>> InitializeAnalytics()
    {
        ObservableCollection<AnalyticsDayDTO> analyticsDayDTOs = await _databaseRepository.GetAllAsync<AnalyticsDayDTO>();
        var analyticsDays = new ObservableCollection<AnalyticsDay>();

        foreach(var dto in analyticsDayDTOs)
        {
            AnalyticsDay set = _analyticsDayMapper.TransformDTOtoAnalyticsDay(dto);
            analyticsDays!.Add(set);
        }

        return analyticsDays;
    }

    public int GetFlashcardSetsEditedOnDate(ObservableCollection<AnalyticsDay> analyticsDays, DateTime date)
    {
        return analyticsDays
            .Where(analyticsDay => analyticsDay.Date == date)
            .Select(analyticsDay => analyticsDay.FlashcardSetsEdited)
            .FirstOrDefault();
    }

    public int GetFlashcardSetsPlayedOnDate(ObservableCollection<AnalyticsDay> analyticsDays, DateTime date)
    {
        return analyticsDays
            .Where(analyticsDay => analyticsDay.Date == date)
            .Select(analyticsDay => analyticsDay.FlashcardSetsPlayed)
            .FirstOrDefault();
    }
}
