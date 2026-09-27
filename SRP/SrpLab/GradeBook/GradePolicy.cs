namespace SrpLab;

public sealed class GradePolicy
{
    public string Letter(GradeBook gradeBook, string studentId)
    {
        var average = gradeBook.Average(studentId);

        if (average >= 90)
            return "A";

        if (average >= 80)
            return "B";

        if (average >= 70)
            return "C";

        if (average >= 60)
            return "D";

        return "F";
    }

    public bool MeetsHonorRoll(
        GradeBook gradeBook,
        string studentId)
    {
        return gradeBook.Average(studentId) >= 85 &&
               Letter(gradeBook, studentId) is "A" or "B";
    }
}
