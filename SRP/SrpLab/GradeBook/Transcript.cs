namespace SrpLab;

public sealed class Transcript
{
    public string TranscriptPlain(
        GradeBook gradeBook,
        GradePolicy policy,
        string studentId,
        string fullName)
    {
        return $"TRANSCRIPT\n" +
               $"Student: {fullName} ({studentId})\n" +
               $"Average: {gradeBook.Average(studentId)}\n" +
               $"Letter: {policy.Letter(gradeBook, studentId)}\n" +
               $"Honor: {policy.MeetsHonorRoll(gradeBook, studentId)}\n";
    }

    public string ExportCsv(
        GradeBook gradeBook,
        GradePolicy policy)
    {
        var rows = new List<string>
        {
            "studentId,average,letter,honor"
        };

        foreach (var id in gradeBook.StudentIds.OrderBy(x => x))
        {
            rows.Add(
                $"{id}," +
                $"{gradeBook.Average(id)}," +
                $"{policy.Letter(gradeBook, id)}," +
                $"{(policy.MeetsHonorRoll(gradeBook, id) ? 1 : 0)}");
        }

        return string.Join('\n', rows);
    }
}
