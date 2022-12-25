public class Day25
{
    public static void Run()
    {
        long[] powers = new long[25];
        powers[0] = 1;
        for (var i = 1; i < powers.Length; i++)
        {
            powers[i] = powers[i - 1] * 5;
        }

        long tot = 0;

        using (StreamReader file = new StreamReader("day25/p.in"))
        {
            string ln;
            
            while ((ln = file.ReadLine()) != null)
            {
                var s = String.Concat(ln.Reverse());
                long sum = 0;
                for (var i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case '2': sum += 2 * powers[i]; break;
                        case '1': sum += 1 * powers[i]; break;
                        case '0': sum += 0 * powers[i]; break;
                        case '-': sum += -1 * powers[i]; break;
                        case '=': sum += -2 * powers[i]; break;
                    }
                }
                //Console.WriteLine(sum);
                tot += sum;
            }
            file.Close();
        }

        Console.WriteLine(tot);

        var snafu = "";
        while (tot > 0)
        {
            switch (tot % 5)
            {
                case 0: snafu += "0"; break;
                case 1: snafu += "1"; break;
                case 2: snafu += "2"; break;
                case 3: snafu += "="; break;
                case 4: snafu += "-"; break;
            }

            tot -= (tot + 2) % 5;
            tot = (tot + 2) / 5;
        }

        Console.WriteLine(String.Concat(snafu.Reverse()));


    }
}

