using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            Random random = new Random();

            while (true)
            {
                Console.Write("What to do? ");
                string line = Console.ReadLine();

                if (line=="list")
                {
                    Console.WriteLine(tree);
                }

                if (line == "insert")
                {
                    Console.Write("What to insert? ");
                    tree.Insert(int.Parse(Console.ReadLine()));
                }

                if (line == "delete")
                {
                    Console.Write("What to delete? ");
                    tree.Delete(int.Parse(Console.ReadLine()));
                }

                if (line == "search")
                {
                    Console.Write("What to search? ");
                    IComparable result = tree.Search(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Found: "+(result==null?"Nothing":result));
                }

                if (line == "minimum")
                {
                    Console.WriteLine("The minimum is: "+tree.GetMinimum());
                }

                if (line == "maximum")
                {
                    Console.WriteLine("The minimum is: " + tree.GetMaximum());
                }

                if (line == "random")
                {
                    Console.Write("How many numbers? ");
                    int count = int.Parse(Console.ReadLine());
                    Console.Write("How large? ");
                    int max = int.Parse(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        tree.Insert(random.Next(max));
                    }
                }

                if (line == "enum")
                {
                    foreach (object i in tree)
                    {
                        Console.Write(i);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }

                if (line == "exit")
                {
                    Console.Write("Bye");
                    break;
                }
            }
        }
    }
}
