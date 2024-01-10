namespace AdventOfCode
{
    public class AdventOfCode
    {
        public const string sDay = "Day";

        public static void Main()
        {
            Day2.Solve();
        }

        public static string[] GetData(int nDay)
        {
            string filePath = "\\" + sDay + nDay + "\\" + sDay + nDay + ".txt";
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + filePath);

            return sText;
        }
    }
}