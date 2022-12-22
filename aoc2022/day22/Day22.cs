public class Day22
{
    private static int w = 150;
    private static int h = 200;
    private static char[,] map = new char[150, 200];
    //private static int w = 16;
    //private static int h = 12;
    //private static char[,] map = new char[16, 12];
    private static int side = 1;

    private static Tuple<int, int> MoveRight(int x, int y)
    {
        if (side == 1)
        {
            x++;
        }
        
        return new Tuple<int, int>(x, y);
    }

    private static Tuple<int, int> MoveLeft(int x, int y)
    {
        if (side == 1)
        {
            x--;
        }
        return new Tuple<int, int>(x, y);
    }

    private static Tuple<int, int> MoveUp(int x, int y)
    {
        if (side == 1)
        {
            y--;
        }
        return new Tuple<int, int>(x, y);
    }

    private static Tuple<int, int> MoveDown(int x, int y)
    {
        if (side == 1)
        {
            y++;
        }
        
        return new Tuple<int, int>(x, y);
    }

    private static Tuple<int, int> Wrap(Tuple<int, int> pos)
    {
        var x = pos.Item1;
        var y = pos.Item2;
        if (x == w) x = 0;
        if (x == -1) x = w - 1;
        if (y == -1) y = h - 1;
        if (y == h) y = 0;
        return new Tuple<int, int>(x, y);
    }

    private static Tuple<int, int> DoMove(Tuple<int, int> pos, char turn)
    {
        Tuple<int, int> newPos = null;
        if (turn == 'R') newPos = Wrap(MoveRight(pos.Item1, pos.Item2));
        if (turn == 'L') newPos = Wrap(MoveLeft(pos.Item1, pos.Item2));
        if (turn == 'U') newPos = Wrap(MoveUp(pos.Item1, pos.Item2));
        if (turn == 'D') newPos = Wrap(MoveDown(pos.Item1, pos.Item2));

        while (map[newPos.Item1, newPos.Item2] == ' ')
        {
            if (turn == 'R') newPos = Wrap(MoveRight(newPos.Item1, newPos.Item2));
            if (turn == 'L') newPos = Wrap(MoveLeft(newPos.Item1, newPos.Item2));
            if (turn == 'U') newPos = Wrap(MoveUp(newPos.Item1, newPos.Item2));
            if (turn == 'D') newPos = Wrap(MoveDown(newPos.Item1, newPos.Item2));
        }

        if (map[newPos.Item1, newPos.Item2] == '#')
        {
            return new Tuple<int, int>(pos.Item1, pos.Item2);
        }
        else if (map[newPos.Item1, newPos.Item2] == '.')
        {
            return newPos;
        }
       
        throw new Exception();
    }
    public static void Run()
    {
        using (StreamReader file = new StreamReader("day22/p.in"))
        {
            string ln;
            var index = 0;
            string movement = "";
            Tuple<int, int> pos = null;

            while ((ln = file.ReadLine()) != null)
            {
                if (index <= h - 1)
                {
                    for (var i = 0; i < w; i++)
                    {
                        if (i < ln.Length)
                        {
                            map[i, index] = ln[i];
                        }
                        else
                        {
                            map[i, index] = ' ';
                        }
                        if (pos == null && map[i, index] == '.')
                        {
                            pos = new Tuple<int, int>(i, index);
                        }
                    }
                }
                else if (index == h + 1)
                {
                    movement = ln;
                }
                index++;
            }

            var str = "";
            var turn = 'R';
            for(var c = 0; c < movement.Length; c++)
            {
                if (movement[c] == 'R')
                {
                    if (str.Length != 0) {
                        var m = int.Parse(str);
                        for (var move = 0; move < m; move++)
                        {
                            pos = DoMove(pos, turn);
                            //Console.WriteLine(pos.Item1 + " " + pos.Item2);
                        }
                        str = "";
                    }
                    // clockwise
                    if (turn == 'R') { turn = 'D'; }
                    else if (turn == 'D') { turn = 'L'; }
                    else if (turn == 'L') { turn = 'U'; }
                    else if (turn == 'U') { turn = 'R'; }
                }
                else if (movement[c] == 'L')
                {
                    if (str.Length != 0)
                    {
                        var m = int.Parse(str);
                        for (var move = 0; move < m; move++)
                        {
                            pos = DoMove(pos, turn);
                        }
                        str = "";
                    }
                    // clockwise
                    if (turn == 'R') { turn = 'U'; }
                    else if (turn == 'D') { turn = 'R'; }
                    else if (turn == 'L') { turn = 'D'; }
                    else if (turn == 'U') { turn = 'L'; }
                }
                else
                {
                    str += movement[c];
                }
            }

            if (str.Length != 0)
            {
                var m = int.Parse(str);
                for (var move = 0; move < m; move++)
                {
                    pos = DoMove(pos, turn);
                }
                str = "";
            }

            // Facing is 0 for right (>), 1 for down (v), 2 for left (<), and 3 for up (^)
            var row = pos.Item2 + 1;
            var col = pos.Item1 + 1;
            var face = 0;
            if (turn == 'D') face = 1;
            if (turn == 'L') face = 2;
            if (turn == 'U') face = 3;
            var tot = row * 1000 + 4 * col + face;
            Console.WriteLine(row + " " + col);
            Console.WriteLine(tot);

            file.Close();
        }
    }
}

