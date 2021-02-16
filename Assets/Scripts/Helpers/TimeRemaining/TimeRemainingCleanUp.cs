using System.Collections.Generic;


public sealed class TimeRemainingCleanUp : ICleanUp
{
    private readonly List<ITimeRemaining> _timeRemainings;

    public TimeRemainingCleanUp()
    {
        _timeRemainings = TimeRemainingExtensions.TimeRemainings;
    }

    public void Cleaner()
    {
        _timeRemainings.Clear();
    }
}