using System.Numerics;
using System.Security.Cryptography;

public class Day11
{
    public class Item
    {
        public int[] wheels = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public Item(int start)
        {
            wheels[0] = start % 17;
            wheels[1] = start % 7;
            wheels[2] = start % 13;
            wheels[3] = start % 2;
            wheels[4] = start % 19;
            wheels[5] = start % 3;
            wheels[6] = start % 5;
            wheels[7] = start % 11;
        }
        public void IncreaseWheels(int op)
        {
            if (op == 0)
            {
                wheels[0] = ((wheels[0] * 5) % 17);
                wheels[1] = ((wheels[1] * 5) % 7);
                wheels[2] = ((wheels[2] * 5) % 13);
                wheels[3] = ((wheels[3] * 5) % 2);
                wheels[4] = ((wheels[4] * 5) % 19);
                wheels[5] = ((wheels[5] * 5) % 3);
                wheels[6] = ((wheels[6] * 5) % 5);
                wheels[7] = ((wheels[7] * 5) % 11);
            }
            if (op == 1)
            {
                wheels[0] = ((wheels[0] + 3) % 17);
                wheels[1] = ((wheels[1] + 3) % 7);
                wheels[2] = ((wheels[2] + 3) % 13);
                wheels[3] = ((wheels[3] + 3) % 2);
                wheels[4] = ((wheels[4] + 3) % 19);
                wheels[5] = ((wheels[5] + 3) % 3);
                wheels[6] = ((wheels[6] + 3) % 5);
                wheels[7] = ((wheels[7] + 3) % 11);
            }
            if (op == 2)
            {
                wheels[0] = ((wheels[0] + 7) % 17);
                wheels[1] = ((wheels[1] + 7) % 7);
                wheels[2] = ((wheels[2] + 7) % 13);
                wheels[3] = ((wheels[3] + 7) % 2);
                wheels[4] = ((wheels[4] + 7) % 19);
                wheels[5] = ((wheels[5] + 7) % 3);
                wheels[6] = ((wheels[6] + 7) % 5);
                wheels[7] = ((wheels[7] + 7) % 11);
            }
            if (op == 3)
            {
                wheels[0] = ((wheels[0] + 5) % 17);
                wheels[1] = ((wheels[1] + 5) % 7);
                wheels[2] = ((wheels[2] + 5) % 13);
                wheels[3] = ((wheels[3] + 5) % 2);
                wheels[4] = ((wheels[4] + 5) % 19);
                wheels[5] = ((wheels[5] + 5) % 3);
                wheels[6] = ((wheels[6] + 5) % 5);
                wheels[7] = ((wheels[7] + 5) % 11);
            }
            if (op == 4)
            {
                wheels[0] = ((wheels[0] + 2) % 17);
                wheels[1] = ((wheels[1] + 2) % 7);
                wheels[2] = ((wheels[2] + 2) % 13);
                wheels[3] = ((wheels[3] + 2) % 2);
                wheels[4] = ((wheels[4] + 2) % 19);
                wheels[5] = ((wheels[5] + 2) % 3);
                wheels[6] = ((wheels[6] + 2) % 5);
                wheels[7] = ((wheels[7] + 2) % 11);
            }
            if (op == 5)
            {
                wheels[0] = ((wheels[0] * 19) % 17);
                wheels[1] = ((wheels[1] * 19) % 7);
                wheels[2] = ((wheels[2] * 19) % 13);
                wheels[3] = ((wheels[3] * 19) % 2);
                wheels[4] = ((wheels[4] * 19) % 19);
                wheels[5] = ((wheels[5] * 19) % 3);
                wheels[6] = ((wheels[6] * 19) % 5);
                wheels[7] = ((wheels[7] * 19) % 11);
            }
            if (op == 6)
            {
                wheels[0] = ((wheels[0] * wheels[0]) % 17);
                wheels[1] = ((wheels[1] * wheels[1]) % 7);
                wheels[2] = ((wheels[2] * wheels[2]) % 13);
                wheels[3] = ((wheels[3] * wheels[3]) % 2);
                wheels[4] = ((wheels[4] * wheels[4]) % 19);
                wheels[5] = ((wheels[5] * wheels[5]) % 3);
                wheels[6] = ((wheels[6] * wheels[6]) % 5);
                wheels[7] = ((wheels[7] * wheels[7]) % 11);
            }
            if (op == 7)
            {
                wheels[0] = ((wheels[0] + 4) % 17);
                wheels[1] = ((wheels[1] + 4) % 7);
                wheels[2] = ((wheels[2] + 4) % 13);
                wheels[3] = ((wheels[3] + 4) % 2);
                wheels[4] = ((wheels[4] + 4) % 19);
                wheels[5] = ((wheels[5] + 4) % 3);
                wheels[6] = ((wheels[6] + 4) % 5);
                wheels[7] = ((wheels[7] + 4) % 11);
            }
        }

        public bool IsDivisible(int val)
        {
            if (val == 17) return wheels[0] == 0;
            if (val == 7) return wheels[1] == 0;
            if (val == 13) return wheels[2] == 0;
            if (val == 2) return wheels[3] == 0;
            if (val == 19) return wheels[4] == 0;
            if (val == 3) return wheels[5] == 0;
            if (val == 5) return wheels[6] == 0;
            if (val == 11) return wheels[7] == 0;
            throw new Exception();
        }
    }
    private class Monkey
    {
        public int Id;
        public BigInteger Inspections = 0;
        public List<Item> Items;

        public void Operation(Item item)
        {
            item.IncreaseWheels(Id);
        }

        public int Test (Item item)
        {
            switch (Id)
            {
                case 0: return item.IsDivisible(17) ? 4 : 7;
                case 1: return item.IsDivisible(7) ? 3 : 2;
                case 2: return item.IsDivisible(13) ? 0 : 7;
                case 3: return item.IsDivisible(2) ? 0 : 2;
                case 4: return item.IsDivisible(19) ? 6 : 5;
                case 5: return item.IsDivisible(3) ? 6 : 1;
                case 6: return item.IsDivisible(5) ? 3 : 1;
                case 7: return item.IsDivisible(11) ? 5 : 4;
            }
            throw new Exception("No such monkey");
        }
    }
    public static void Run()
    {
        var monkeys = new List<Monkey>();
        monkeys.Add(new Monkey()
        {
            Id = 0,
            Items = new List<Item>() { new Item(89), new Item(74) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 1,
            Items = new List<Item>() { new Item(75), new Item(69), new Item(87), new Item(57), new Item(84), new Item(90), new Item(66), new Item(50) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 2,
            Items = new List<Item>() { new Item(55) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 3,
            Items = new List<Item>() { new Item(69), new Item(82), new Item(69), new Item(56), new Item(68) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 4,
            Items = new List<Item>() { new Item(72), new Item(97), new Item(50) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 5,
            Items = new List<Item>() { new Item(90), new Item(84), new Item(56), new Item(92), new Item(91), new Item(91) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 6,
            Items = new List<Item>() { new Item(63), new Item(93), new Item(55), new Item(53) }
        });
        monkeys.Add(new Monkey()
        {
            Id = 7,
            Items = new List<Item>() { new Item(50), new Item(61), new Item(52), new Item(58), new Item(86), new Item(68), new Item(97) }
        });
        for (var i = 0; i < 10000; i++)
        {
            foreach(var monkey in monkeys)
            {
                for (var j = 0; j < monkey.Items.Count; j++)
                {
                    monkey.Inspections++;
                    var item = monkey.Items[j];
                    monkey.Operation(item);
                    monkeys[monkey.Test(item)].Items.Add(item);
                }
                monkey.Items.Clear();
            }
            Console.WriteLine(i);
        }
        var sorted = monkeys.OrderBy(x => x.Inspections).Reverse().ToList();
        var m1 = sorted[0].Inspections;
        var m2 = sorted[1].Inspections;
        Console.WriteLine(m1 * m2);
    }
}

