public class Day2
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day2/p.in"))
        {
            string ln;
            while ((ln = file.ReadLine()) != null)
            {
                Console.WriteLine(ln);
            }

            file.Close();
        }
    }
}

