using System.Runtime.CompilerServices;

namespace Day2;
class Program {
    static void Main(string[] args) {
        int safeReportCtr1 = 0;
        int safeReportCtr2 = 0;
        using StreamReader file = new StreamReader("2_Input.txt");
        var report = new List<int>();
        string line;

        while ((line = file.ReadLine()) != null) {
            string[] parts = line.Split(' ');

            report.AddRange(Array.ConvertAll(parts, int.Parse));
            
            if(CheckSafety(report)) {
                safeReportCtr1++;
            }
            if(CheckSafetyWithDampener(report)) {
                safeReportCtr2++;
            }

            report.Clear();
        }

        Console.WriteLine($"[1] = {safeReportCtr1}");
        Console.WriteLine($"[2] = {safeReportCtr2}");
    }

    static bool CheckSafety(List<int> report) {
        var isIncreasing =
            report.Zip(report.Skip(1),
            (a, b) => a.CompareTo(b) < 0)
                .All(b => b);

        var isDecreasing =
            report.Zip(report.Skip(1),
            (a, b) => a.CompareTo(b) > 0)
                .All(b => b);

        var moreThan3 =
            report.Zip(report.Skip(1),
            (a, b) => b - a >= -3)
                .All(b => b);

        var lessThan3 =
            report.Zip(report.Skip(1),
            (a, b) => b - a <= 3)
                .All(b => b);

        bool condition1 = isIncreasing || isDecreasing;
        bool condition2 = moreThan3 && lessThan3;

        return condition1 && condition2;
    }

    static bool CheckSafetyWithDampener(List<int> report) {
        int len = report.Count;
        var reports = new List<List<int>>();

        for(int i = 0; i < len; i++) {
            var newReport = new List<int>(report);
            newReport.RemoveAt(i);
            reports.Add(newReport);
        }

        var res = CheckSafety(report) || reports.Any(x => CheckSafety(x));

        return res;
    }
}
