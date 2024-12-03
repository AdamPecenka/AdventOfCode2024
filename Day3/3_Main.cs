using System.Text.RegularExpressions;

namespace Day3;

class Program {
    static void Main(string[] args) {
        using StreamReader file = new StreamReader("3_Input.txt");
        string input = file.ReadToEnd();
        string pattern1 = @"mul\((\d{1,3}),(\d{1,3})\)";
        string pattern2 = @"(mul\((\d{1,3}),(\d{1,3})\))|(don't\(\))|(do\(\))";
        int result1 = 0;
        int result2 = 0;
        bool enabled = true;

        Match match1 = Regex.Match(input, pattern1);
        while(match1.Success) {
            result1 += int.Parse(match1.Groups[1].Value) * int.Parse(match1.Groups[2].Value);

            match1 = match1.NextMatch();
        }

        Match match2 = Regex.Match(input, pattern2);
        while(match2.Success) {
            
            if(match2.Groups[5].Value != string.Empty) {
                enabled = true;
            }

            if(match2.Groups[4].Value != string.Empty) {
                enabled = false;
            }

            if(match2.Groups[1].Value != string.Empty) {
                if(enabled) {
                    result2 += int.Parse(match2.Groups[2].Value) * int.Parse(match2.Groups[3].Value);
                }
            }

            match2 = match2.NextMatch();
        }

        Console.WriteLine($"[1] = {result1}");
        Console.WriteLine($"[2] = {result2}");
    }   
}
