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
            Tree tree = new Tree(new IComparable[] {9,5,3,6,4,7,2,8,1,10});
            Console.WriteLine(tree);
            Console.WriteLine(tree.Delete(6));
            Console.WriteLine(tree);
            Console.WriteLine(tree.Delete(3));
            Console.WriteLine(tree);
            Console.WriteLine(tree.Delete(15));
            Console.WriteLine(tree);
            Console.WriteLine(tree.Delete(6));
            Console.WriteLine(tree);
            Console.ReadKey();
        }
    }
}
