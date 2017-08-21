using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    class Program
    {
        delegate double doubleIt(double dbl);
        
        static void Main(string[] args)
        {
            Console.WriteLine();
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg {i}: {args[i]}");
            }

            string[] myArgs = Environment.GetCommandLineArgs();
            Console.WriteLine(string.Join(", ", myArgs));
            //SayHallo();

            bool canIVote = true;
            Console.WriteLine($"Biggest Integer: {int.MaxValue}");
            Console.WriteLine($"Smallest Integer: {int.MinValue}");
            Console.WriteLine($"Biggest Double: {double.MaxValue.ToString("#")}");
            decimal decPiVal = 3.1315926535897932384626433832M;
            bool boolFromStr = bool.Parse("true");
            int intFromStr = int.Parse("10");
            DateTime awesomeDate = new DateTime(1986, 3, 2);
            Console.WriteLine($"Day of Week: {awesomeDate.DayOfWeek}");
            awesomeDate = awesomeDate.AddDays(4);
            awesomeDate = awesomeDate.AddMonths(1);
            awesomeDate = awesomeDate.AddYears(2);
            Console.WriteLine($"New date: {awesomeDate.Date}");
            TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            lunchTime = lunchTime.Add(new TimeSpan(1, 0, 0));
            Console.WriteLine($"New Time: {lunchTime.ToString()}");

            BigInteger big = BigInteger.Parse("1234132432543253242342342314122412");
            Console.WriteLine($"Big Num * 2 = {big * 2}");
            Console.WriteLine("Currency: {0:c}", 23.455);
            Console.WriteLine("Pad with 0s: {0:d4}", 23);
            Console.WriteLine("3 Decimals: {0:f3}", 23.4555);
            Console.WriteLine("Commas: {0:n4}", 2300);

            string randString = "This is a string";
            Console.WriteLine("String Length: {0}", randString.Length);
            Console.WriteLine("String Contains is: {0}", randString.Contains("is"));
            Console.WriteLine("Index of is: {0}", randString.IndexOf("is"));
            Console.WriteLine("Remove String: {0}", randString.Remove(0, 6));
            Console.WriteLine("Insert String: {0}", randString.Insert(10, "short "));
            Console.WriteLine("Replace String: {0}", randString.Replace("string", "sentence"));
            Console.WriteLine("Compare A to B: {0}", String.Compare("A", "B", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("A = a: {0}", String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Pad Left: {0}", randString.PadLeft(20, '.'));
            Console.WriteLine("Pad Right: {0}", randString.PadRight(20, '.'));
            Console.WriteLine("Trim(): {0}", randString.Trim());
            Console.WriteLine("Uppercase: {0}", randString.ToUpper());
            Console.WriteLine("Lowercase: {0}", randString.ToLower());

            string newString = String.Format("{0} saw a {1} {2} in the {3}", "Paul", "rabbit", "eating", "field");
            Console.WriteLine(newString);
            Console.WriteLine(@"Exactly what I Typed ' \");

            // Classes
            Shape[] shapes = { new Circle(5), new Rectangle(4, 5) };
            foreach (Shape s in shapes)
            {
                s.GetInfo();
                Console.WriteLine("{0} Area: {1:f2}", s.Name, s.Area());
                Circle testCirc = s as Circle;
                if (testCirc == null)
                {
                    Console.WriteLine("This isn't a Circle");
                }

                if (s is Circle)
                {
                    Console.WriteLine("This isn't a Rectangle");
                }
            }
            object circ1 = new Circle(4);
            Circle circ2 = (Circle)circ1;
            Console.WriteLine("The {0} Area is {1:f2}", circ2.Name, circ2.Area());

            // Interfaces
            Vehicle buick = new Vehicle("Buick", 4, 160);
            if (buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            }
            else
            {
                Console.WriteLine("The {0} can't be driven", buick.Brand);
            }
            IElectronicDevice TV = TVRemote.GetDevice();
            PowerButton powBut = new PowerButton(TV);
            powBut.Execute();
            powBut.Undo();

            // Collections
            collectionFunctions();

            // Generics
            //List<int> numList = new List<int>();
            List<Animal> animalList = new List<Animal>();
            animalList.Add(new Animal() { Name = "Doug" });
            animalList.Add(new Animal() { Name = "Paul" });
            animalList.Add(new Animal() { Name = "Sally" });
            animalList.Insert(1, new Animal() { Name = "Steve" });
            animalList.RemoveAt(1);
            Console.WriteLine("Num of Animals: {0}", animalList.Count());
            foreach (Animal a in animalList)
            {
                Console.WriteLine(a.Name);
            }
            int x = 5, y = 4;
            Animal.GetSum(ref x, ref y);
            string strX = "4", strY = "3";
            Animal.GetSum(ref strX, ref strY);
            Rectangle<int> rec1 = new Rectangle<int>(20, 50);
            Console.WriteLine(rec1.GetArea());
            Rectangle<string> rec2 = new Rectangle<string>("20", "50");
            Console.WriteLine(rec2.GetArea());
            
            // Delegates
            Arithmetic add, sub, addSub;
            add = new Arithmetic(Add);
            sub = new Arithmetic(Subtract);
            addSub = add + sub;
            Console.WriteLine("Add 6 & 10");
            add(6, 10);
            Console.WriteLine("Add & Subtract 10 & 4");
            addSub(10, 4);
            
            // Manipulating list
            doubleIt dlIt = z => z * 2;
            Console.WriteLine($"5 + 2 = {dlIt(5)}");
            List<int> numList = new List<int> { 1, 9, 2, 6, 3 };
            var evenList = numList.Where(a => a % 2 == 0).ToList();
            foreach (var j in evenList)
            {
                Console.WriteLine(j);
            }
            var rangeList = numList.Where(a => (a > 2) && (a < 9)).ToList();
            foreach (var j in rangeList)
            {
                Console.WriteLine(j);
            }
            List<int> flipList = new List<int>();
            int k = 0;
            Random rnd = new Random();
            while(k < 100)
            {
                flipList.Add(rnd.Next(1, 3));
                k++;
            }
            Console.WriteLine("Heads: {0}", flipList.Where(a => a == 1).ToList().Count);
            Console.WriteLine("Tails: {0}", flipList.Where(a => a == 2).ToList().Count);

            var nameList = new List<string> { "Doug", "Sally", "Sue" };
            var sNameList = nameList.Where(a => a.StartsWith("S"));
            foreach (var m in sNameList)
            {
                Console.WriteLine(m);
            }
            var oneTo10 = new List<int>();
            oneTo10.AddRange(Enumerable.Range(1, 10));
            var squares = oneTo10.Select(a => a * a);
            foreach (var l in squares)
            {
                Console.WriteLine(l);
            }
            var listOne = new List<int>(new int[] { 1, 3, 4 });
            var listTwo = new List<int>(new int[] { 4, 6, 8 });
            var sumList = listOne.Zip(listTwo, (a, b) => a + b).ToList();
            foreach (var n in sumList)
            {
                Console.WriteLine(n);
            }
            var numList2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("Sum: {0}", numList2.Aggregate((a, b) => a + b));
            Console.WriteLine("Average: {0}", numList2.AsQueryable().Average());
            Console.WriteLine("All > 3: {0}", numList2.All(a => a > 3));
            Console.WriteLine("Any > 3: {0}", numList2.Any(a => a > 3));
            var numList3 = new List<int>() { 1, 2, 3, 2, 3 };
            Console.WriteLine("Distinct: {0}", string.Join(", ", numList3.Distinct()));
            var numList4 = new List<int>() { 3 };
            Console.WriteLine("Except: {0}", string.Join(", ", numList3.Except(numList4)));
            Console.WriteLine("Intersect: {0}", string.Join(", ", numList3.Intersect(numList4)));

            // Overloading and enumaration
            AnimalFarm myAnimals = new AnimalFarm();
            myAnimals[0] = new Animal("Wilbur");
            myAnimals[1] = new Animal("Templeton");
            myAnimals[2] = new Animal("Gander");
            myAnimals[3] = new Animal("Charlotte");
            foreach (Animal i in myAnimals)
            {
                Console.WriteLine(i.Name);
            }
            Box box1 = new Box(2, 3, 4);
            Box box2 = new Box(5, 6, 7);
            Box box3 = box1 + box2;
            Console.WriteLine($"Box 3: {box3}");
            Console.WriteLine($"Box Int: {(int)box3}");
            Box box4 = (Box)4;
            Console.WriteLine($"Box 4: {box4}");
            var shopkins = new
            {
                Name = "Shopkins",
                Price = 4.99
            };
            Console.WriteLine("{0} cost ${1}", shopkins.Name, shopkins.Price);
            var toyArray = new[] {
                new { Name = "Yo-Kai Pack", Price = 4.99 },
                new { Name = "Legos", Price = 9.99 }
            };

            foreach (var item in toyArray)
            {
                Console.WriteLine("{0} costs ${1}", item.Name, item.Price);
            }
            Console.ReadLine();
        }

        private static void SayHallo()
        {
            string name = "";
            Console.WriteLine("What is your name: ");
            name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
        }

        private static void collectionFunctions()
        {
            #region ArrayList Code
            ArrayList aList = new ArrayList();
            aList.Add("Bob");
            aList.Add(40);
            Console.WriteLine("Count: {0}", aList.Count);
            Console.WriteLine("Capacity: {0}", aList.Capacity);
            ArrayList aList2 = new ArrayList();
            aList2.AddRange(new object[] { "Mike", "Sally", "Egg" });
            aList.AddRange(aList2);
            aList2.Sort();
            aList2.Reverse();
            aList2.Insert(1, "Turkey");
            ArrayList range = aList2.GetRange(0, 2);
            foreach (object o in range)
            {
                Console.WriteLine(o);
            }
            aList2.RemoveAt(0);
            aList2.RemoveRange(0, 2);
            foreach (var item in aList2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Turkey Index : {0}", aList2.IndexOf("Turkey", 0));
            string[] myArray = (string[])aList2.ToArray(typeof(string));
            string[] customers = { "Bob", "Sally", "Sue" };
            ArrayList custArrayList = new ArrayList();
            custArrayList.AddRange(customers);
            foreach (string s in custArrayList)
            {
                Console.WriteLine(s);
            }
            #endregion
            #region Dictonaries Code
            Dictionary<string, string> superheroes = new Dictionary<string, string>();
            superheroes.Add("Clark Kent", "Superman");
            superheroes.Add("Bruce Wayne", "Batman");
            superheroes.Add("Barry West", "Flash");
            superheroes.Remove("Barry West");
            Console.WriteLine("Count: {0}", superheroes.Count);
            Console.WriteLine("Clark Kent: {0}", superheroes.ContainsKey("Clark Kent"));
            superheroes.TryGetValue("Clark Kent", out string test);
            Console.WriteLine($"Clark Kent: {test}");
            foreach (KeyValuePair<string, string> item in superheroes)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
            superheroes.Clear();
            #endregion
            #region Queues Code
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("1 in Queue: {0}", queue.Contains(1));
            Console.WriteLine("Remove 1: {0}", queue.Dequeue());
            Console.WriteLine("Peek 1: {0}", queue.Peek());
            object[] numArray = queue.ToArray();
            Console.WriteLine(string.Join(", ", numArray));
            //queue.Clear();
            foreach (object o in queue)
            {
                Console.WriteLine($"Queue: {o}");
            }
            #endregion
            #region Stack Code
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Peek 1: {0}", stack.Peek());
            Console.WriteLine("Pop b1: {0}", stack.Pop());
            Console.WriteLine("Contain 1: {0}", stack.Contains(1));
            object[] numArray2 = stack.ToArray();
            Console.WriteLine(string.Join(", ", numArray2));
            stack.Clear();
            foreach (object o in stack)
            {
                Console.WriteLine($"Stack: {o}");
            }
            #endregion
        }

        public delegate void Arithmetic(double num1, double num2);

        public static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }

        public static void Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }
    }

    public struct Rectangle<T>
    {
        private T width;
        private T length;
        public T Width
        {
            get { return width; }
            set { width = value; }
        }
        
        public T Length
        {
            get { return length; }
            set { length = value; }
        }
        
        public Rectangle(T w, T l)
        {
            width = w;
            length = l;
        }

        public string GetArea()
        {
            double dblWidth = Convert.ToDouble(Width);
            double dblLength = Convert.ToDouble(Length);
            return $"{Width} * {Length} = {dblWidth * dblLength}";
        }
    }
}
