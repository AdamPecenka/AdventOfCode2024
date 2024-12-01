namespace Day1;

class Program {
    static void Main(string[] args) {
        List<int> rList = new List<int>();
        List<int> lList = new List<int>();
        using StreamReader file = new StreamReader("1_Input.txt");
        string line;

        while((line = file.ReadLine()) != null) {
            //string Delimiter = "   ";
            //string[] parts = line.Split(new[] { Delimiter }, StringSplitOptions.None);
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);


            lList.Add(int.Parse(parts[0]));
            rList.Add(int.Parse(parts[1]));
        }

        lList.Sort();
        rList.Sort();

        int result1 = PartOne(lList, rList);
        int result2 = PartTwo(lList, rList);

        Console.WriteLine($"[1] = {result1}");
        Console.WriteLine($"[2] = {result2}");
    }

    static int PartOne(List<int> lList, List<int> rList) {
        int res = 0;
        int dist;

        for(int i = 0; i < rList.Count; i++) {
            dist = lList[i] - rList[i];

            res += Math.Abs(dist);
        }
        return res;
    }
    static int PartTwo(List<int> lList, List<int> rList) {
        int res = 0;
        int count;
        List<int> temp = new List<int>();

        foreach(int item in lList) {
            temp.AddRange(
                rList.FindAll(x => x == item)
            );
            count = temp.Count;

            res += item * count;
            temp.Clear();
        }

        return res;
    }
}