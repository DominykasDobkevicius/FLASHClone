using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FirstLab.src.controllers;
using FirstLab.src.data;
using FirstLab.src.mappers;
using FirstLab.src.models;
using FirstLab.src.models.DTOs;

namespace FirstLab.src.interfaces;

public interface IAnalyticsViewService
{
    public Task<ObservableCollection<AnalyticsDay>> InitializeAnalytics();

    public int GetFlashcardSetsEditedOnDate(ObservableCollection<AnalyticsDay> analyticsDays, DateTime date);
    public int GetFlashcardSetsPlayedOnDate(ObservableCollection<AnalyticsDay> analyticsDays, DateTime date);
}