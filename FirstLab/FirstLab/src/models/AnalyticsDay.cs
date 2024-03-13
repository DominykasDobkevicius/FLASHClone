using System;
using System.Collections.ObjectModel;

namespace FirstLab.src.models;

public class AnalyticsDay
{
    public DateTime Date { get; set; }

    public int FlashcardSetsEdited { get; set; }

    public int FlashcardSetsPlayed { get; set; }
}
