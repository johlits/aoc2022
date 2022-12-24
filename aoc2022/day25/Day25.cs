public class Day25
{
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day25/p.in"))
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

