namespace WellbeingTracking.Application.DTOs;

public class LogWellbeingDto
{
    public string Mood { get; set; } = string.Empty;
    public int StressLevel { get; set; }
    public double SleepHours { get; set; }
}
