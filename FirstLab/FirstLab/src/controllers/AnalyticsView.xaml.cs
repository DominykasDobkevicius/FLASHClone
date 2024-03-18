using FirstLab.src.interfaces;
using FirstLab.src.models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Defaults;
using System.Linq;

namespace FirstLab.src.controllers
{
    public partial class AnalyticsView : UserControl, INotifyPropertyChanged
    {
        readonly IAnalyticsViewService _analyticsViewService;

        public ObservableCollection<AnalyticsDay> AnalyticsDays;

        private List<string> _analyticsDaysStrings = new();
        public List<string> AnalyticsDaysStrings
        {
            get { return _analyticsDaysStrings; }
            set
            {
                _analyticsDaysStrings = value;
                OnPropertyChanged(nameof(AnalyticsDaysStrings));
            }
        }

        private ChartValues<ObservablePoint> _analyticsDaysEdits = new();
        public ChartValues<ObservablePoint> AnalyticsDaysEdits
        {
            get { return _analyticsDaysEdits; }
            set
            {
                _analyticsDaysEdits = value;
                OnPropertyChanged(nameof(AnalyticsDaysEdits));
            }
        }

        private ChartValues<ObservablePoint> _analyticsDaysPlays = new();
        public ChartValues<ObservablePoint> AnalyticsDaysPlays
        {
            get { return _analyticsDaysPlays; }
            set
            {
                _analyticsDaysPlays = value;
                OnPropertyChanged(nameof(AnalyticsDaysPlays));
            }
        }

        private int _flashcardSetsPlayed;
        public int FlashcardSetsPlayed
        {
            get { return _flashcardSetsPlayed; }
            set
            {
                _flashcardSetsPlayed = value;
                OnPropertyChanged(nameof(FlashcardSetsPlayed));
            }
        }

        private int _flashcardSetsEdited;
        public int FlashcardSetsEdited
        {
            get { return _flashcardSetsEdited; }
            set
            {
                _flashcardSetsEdited = value;
                OnPropertyChanged(nameof(FlashcardSetsEdited));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static Func<double, string> FormatAsInteger = value => Math.Round(value).ToString("0");

        private void OnDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ReloadAnalyticsGraphs(StartDatePicker.SelectedDate ?? DateTime.MinValue, EndDatePicker.SelectedDate ?? DateTime.MaxValue);
        }

        public AnalyticsView(IAnalyticsViewService analyticsViewService)
        {
            InitializeComponent();
            _analyticsViewService = analyticsViewService;
        }

        public async void ReloadAnalyticsTask()
        {
            AnalyticsDays = await _analyticsViewService.InitializeAnalytics();
            FlashcardSetsEdited = _analyticsViewService.GetFlashcardSetsEditedOnDate(AnalyticsDays, DateTime.UtcNow.Date);
            FlashcardSetsPlayed = _analyticsViewService.GetFlashcardSetsPlayedOnDate(AnalyticsDays, DateTime.UtcNow.Date);

            ReloadAnalyticsGraphs(DateTime.MinValue, DateTime.MaxValue);

            DataContext = this;
        }

        public void ReloadAnalyticsGraphs(DateTime graphsStartDay, DateTime graphsEndDay)
        {
            var AnalyticsDaysFilter = new ObservableCollection<AnalyticsDay>(AnalyticsDays
                .Where(x => x.Date >= graphsStartDay && x.Date <= graphsEndDay)
                .OrderBy(x => x.Date));

            AnalyticsDaysStrings.Clear();
            foreach(var analyticsDay in AnalyticsDaysFilter)
            {
                AnalyticsDaysStrings.Add(analyticsDay.Date.ToString("yyyy-MM-dd"));
            }

            AnalyticsDaysEdits.Clear();
            AnalyticsDaysPlays.Clear();
            for(int i = 0; i < AnalyticsDaysStrings.Count; ++i)
            {
                AnalyticsDaysEdits.Add(new ObservablePoint(i, AnalyticsDaysFilter[i].FlashcardSetsEdited));
                AnalyticsDaysPlays.Add(new ObservablePoint(i, AnalyticsDaysFilter[i].FlashcardSetsPlayed));
            }
        }
    }
}
