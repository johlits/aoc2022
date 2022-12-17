public class Day17
{
    public static List<Tuple<int, long>> GetBlock(long type, long h) {
        var w = 1;
        var block = new List<Tuple<int, long>>();
        if (type == 0)
        {
            block.Add(new Tuple<int, long>(2 + w, 0 + h));
            block.Add(new Tuple<int, long>(3 + w, 0 + h));
            block.Add(new Tuple<int, long>(4 + w, 0 + h));
            block.Add(new Tuple<int, long>(5 + w, 0 + h));
        }
        if (type == 1)
        {
            block.Add(new Tuple<int, long>(3 + w, 0 + h - 2));
            block.Add(new Tuple<int, long>(2 + w, 1 + h - 2));
            block.Add(new Tuple<int, long>(3 + w, 1 + h - 2));
            block.Add(new Tuple<int, long>(4 + w, 1 + h - 2));
            block.Add(new Tuple<int, long>(3 + w, 2 + h - 2));
        }
        if (type == 2)
        {
            block.Add(new Tuple<int, long>(4 + w, 0 + h-2));
            block.Add(new Tuple<int, long>(4 + w, 1 + h-2));
            block.Add(new Tuple<int, long>(4 + w, 2 + h-2));
            block.Add(new Tuple<int, long>(3 + w, 2 + h-2));
            block.Add(new Tuple<int, long>(2 + w, 2 + h -2));
        }
        if (type == 3)
        {
            block.Add(new Tuple<int, long>(2 + w, 0 + h-3));
            block.Add(new Tuple<int, long>(2 + w, 1 + h-3));
            block.Add(new Tuple<int, long>(2 + w, 2 + h-3));
            block.Add(new Tuple<int, long>(2 + w, 3 + h-3));
        }
        if (type == 4)
        {
            block.Add(new Tuple<int, long>(2 + w, 0 + h-1));
            block.Add(new Tuple<int, long>(3 + w, 0 + h-1));
            block.Add(new Tuple<int, long>(2 + w, 1 + h-1));
            block.Add(new Tuple<int, long>(3 + w, 1 + h-1));
        }
        return block;
    }
    public static void Run()
    {
        var h = 4000;
        bool[,] arr = new bool[9, h];

        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                arr[j, i] = false;
            }
        }

        for (var i = 0; i < h; i++)
        {
            arr[0, i] = true;
            arr[8, i] = true;
        }
        for (var i = 0; i < 9; i++)
        {
            arr[i, h - 1] = true;
        }

        long lo = h;

        using (StreamReader file = new StreamReader("day17/p.in"))
        {
            string wind = null;
            string ln;
            while ((ln = file.ReadLine()) != null)
            {
                wind = ln;
            }
            var step = 0;

            for (long r = 0; r < 2022; r++)
            {
                var isFalling = true;
                var block = GetBlock(r % 5, lo - 5);
                while (isFalling)
                {
                    var push = wind[(step) % wind.Length];
                    //Console.WriteLine(push);
                    step++;
                    if (push == '<')
                    {
                        var newPositions = new List<Tuple<int, long>>();
                        foreach (var position in block)
                        {
                            newPositions.Add(new Tuple<int, long>(position.Item1 - 1, position.Item2));
                        }
                        var okToMove = true;
                        foreach (var position in newPositions)
                        {
                            if (arr[position.Item1, position.Item2] == true)
                            {
                                okToMove = false;
                            }
                        }
                        if (okToMove)
                        {
                            block = newPositions;
                        }
                    }
                    if (push == '>')
                    {
                        var newPositions = new List<Tuple<int, long>>();
                        foreach (var position in block)
                        {
                            newPositions.Add(new Tuple<int, long>(position.Item1 + 1, position.Item2));
                        }
                        var okToMove = true;
                        foreach (var position in newPositions)
                        {
                            if (arr[position.Item1, position.Item2])
                            {
                                okToMove = false;
                            }
                        }
                        if (okToMove)
                        {
                            block = newPositions;
                        }
                    }


                    var fallPositions = new List<Tuple<int, long>>();
                    foreach (var position in block)
                    {
                        fallPositions.Add(new Tuple<int, long>(position.Item1, position.Item2 + 1));
                    }
                    var okToFall = true;
                    foreach (var position in fallPositions)
                    {
                        if (arr[position.Item1, position.Item2])
                        {
                            okToFall = false;
                        }
                        if (arr[position.Item1, position.Item2])
                        {
                            okToFall = false;
                        }
                    }

                    if (okToFall)
                    {
                        block = fallPositions;
                    }
                    else
                    {
                        foreach (var pos in block)
                        {
                            arr[pos.Item1, pos.Item2] = true;
                            if ((pos.Item2 + 1) < lo)
                            {
                                lo = pos.Item2 + 1;
                                Console.WriteLine(lo);
                                
                            }
                            
                            isFalling = false;
                        }


                        //for (var j = lo - 1; j < 4000; j++)
                        //{
                        //    for (var i = 0; i < 9; i++)
                        //    {
                        //        Console.Write(arr[i, j]);
                        //    }
                        //    Console.WriteLine();
                        //}
                        //Console.WriteLine();
                    }

                }
            }

            file.Close();
            Console.WriteLine("best: " + (h - lo));
        }
    }
}

