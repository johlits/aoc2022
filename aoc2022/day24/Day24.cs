public class Day24
{
    public static void Run()
    {
        //var w = 8;
        //var h = 6;
        //var rot = 6 * 4;
        var w = 122;
        var h = 27;
        var rot = 120 * 25;

        // 242 too low
        Console.WriteLine("begin");

        using (StreamReader file = new StreamReader("day24/p.in"))
        {
            string ln;
            var blizzards = new Dictionary<Tuple<int, int>, string>();
            var players = new List<Tuple<int, int, char, int, string>>();
            var r = 0;

            while ((ln = file.ReadLine()) != null)
            {
                for (var c = 0; c < ln.Length; c++)
                {
                    switch (ln[c])
                    {
                        case '<': blizzards.Add(new Tuple<int, int>(c, r), "L"); break;
                        case '>': blizzards.Add(new Tuple<int, int>(c, r), "R"); break;
                        case '^': blizzards.Add(new Tuple<int, int>(c, r), "U"); break;
                        case 'v': blizzards.Add(new Tuple<int, int>(c, r), "D"); break;
                        case 'E': 
                            players.Add(new Tuple<int, int, char, int, string>(c, r, '.', 0, "."));
                            players.Add(new Tuple<int, int, char, int, string>(c, r, 'D', 0, "D"));
                            break;
                    }
                }
                r++;
            }
            file.Close();

            var q = new Queue<Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>>();
            q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>(
                new Dictionary<Tuple<int, int>, string>(blizzards), players[0]));
            q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>(
                new Dictionary<Tuple<int, int>, string>(blizzards), players[1]));

            var visited = new HashSet<Tuple<int, int, int, int>>();
            var skips = 0;

            while (q.Count > 0)
            {
                var data = q.Dequeue();
                var blizzes = data.Item1;
                var player = data.Item2;

                //Console.WriteLine(player.Item1 + " " + player.Item2 + " " + player.Item3);

                var mem = new Tuple<int, int, int, int>(player.Item1, player.Item2, player.Item3, (player.Item4 % rot));
                if (visited.Contains(mem))
                {
                    skips++;
                    continue;
                }
                visited.Add(mem);

                var newBlizzes = new Dictionary<Tuple<int, int>, string>();
                foreach (KeyValuePair<Tuple<int, int>, string> entry in blizzes)
                {
                    Tuple<int, int> pos = entry.Key;
                    
                    var s = entry.Value;
                    
                    for (var c = 0; c < s.Length; c++)
                    {
                        var x = pos.Item1;
                        var y = pos.Item2;

                        switch (s[c])
                        {
                            case 'U': y--; break;
                            case 'D': y++; break;
                            case 'L': x--; break;
                            case 'R': x++; break;
                        }

                        if (x == 0) { x = w - 2; }
                        if (x == w - 1) { x = 1; }
                        if (y == 0) { y = h - 2; }
                        if (y == h - 1) { y = 1; }

                        if (newBlizzes.ContainsKey(new Tuple<int, int>(x, y)))
                        {
                            newBlizzes[new Tuple<int, int>(x, y)] =
                                newBlizzes[new Tuple<int, int>(x, y)] + s[c];
                        }
                        else
                        {
                            newBlizzes.Add(new Tuple<int, int>(x, y), "" + s[c]);
                        }
                    }
                }

                var px = player.Item1;
                var py = player.Item2;
                var pd = player.Item3;
                var pr = player.Item4;

                switch (pd)
                {
                    case 'U': py--; break;
                    case 'D': py++; break;
                    case 'L': px--; break;
                    case 'R': px++; break;
                }

                pr++;

                if (!newBlizzes.ContainsKey(new Tuple<int, int>(px, py)))
                {

                    if (px == w - 2 && py == h - 1)
                    {
                        Console.WriteLine("found");
                        Console.WriteLine("steps: " + pr);
                        Console.WriteLine("path: " + player.Item5);
                        Console.WriteLine("skips: " + skips);
                        break;
                    }

                    if (px < w - 2 && py > 0)
                        q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>
                        (newBlizzes, new Tuple<int, int, char, int, string>(px, py, 'R', pr, player.Item5 + "R")));
                    if (py < h - 2 || (px == 1 && py == 0) || (px == w - 2 && py == h - 2))
                        q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>
                        (newBlizzes, new Tuple<int, int, char, int, string>(px, py, 'D', pr, player.Item5 + "D")));
                    if (py > 1 || (px == 1 && py == 1))
                        q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>
                        (newBlizzes, new Tuple<int, int, char, int, string>(px, py, 'U', pr, player.Item5 + "U")));
                    if (px > 1 && py > 0)
                        q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>
                        (newBlizzes, new Tuple<int, int, char, int, string>(px, py, 'L', pr, player.Item5 + "L")));
                    
                    q.Enqueue(new Tuple<Dictionary<Tuple<int, int>, string>, Tuple<int, int, char, int, string>>
                        (newBlizzes, new Tuple<int, int, char, int, string>(px, py, ' ', pr, player.Item5 + ".")));
                }

            }
        }
    }
}

