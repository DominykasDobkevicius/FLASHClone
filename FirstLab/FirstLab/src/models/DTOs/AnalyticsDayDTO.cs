using System.ComponentModel.DataAnnotations;
using System;

namespace FirstLab.src.models.DTOs;

public class AnalyticsDayDTO
{
    [Key]
    public DateTime Date { get; set; }
    public int FlashcardSetsEdited { get; set; }
    public int FlashcardSetsPlayed { get; set; }
}
