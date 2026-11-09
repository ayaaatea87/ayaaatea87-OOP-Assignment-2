namespace SrpLab;

public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    private readonly AcuityScorer _acuityScorer = new();
    private readonly PagerAlertLog _pagerAlertLog = new();
    private readonly HandoffNoteBuilder _handoffNoteBuilder = new();
    private readonly CensusCsvExporter _censusCsvExporter = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();

        var acuity = _acuityScorer.Score(heartRate, spo2);
        _vitalsScore[bed] = acuity;

        _pagerAlertLog.Add(bed, acuity);
    }

    public string BuildHandoffNote(int bed)
    {
        if (!_bedPatient.TryGetValue(bed, out var patient))
            return $"Bed {bed}: empty";

        var acuity = _vitalsScore[bed];

        return _handoffNoteBuilder.Build(
            bed,
            patient,
            acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerAlertLog.Drain();
    }

    public string ExportCensusCsv()
    {
        return _censusCsvExporter.Export(
            _bedPatient,
            _vitalsScore);
    }
}
