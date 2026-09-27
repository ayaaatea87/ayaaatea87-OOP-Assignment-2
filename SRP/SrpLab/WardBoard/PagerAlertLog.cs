namespace SrpLab;

public sealed class PagerAlertLog
{
    private readonly List<string> _log = new();

    public void Add(int bed, int acuity)
    {
        if (acuity >= 8)
            _log.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
    }

    public IReadOnlyList<string> Drain()
    {
        var copy = _log.ToList();
        _log.Clear();
        return copy;
    }
}
