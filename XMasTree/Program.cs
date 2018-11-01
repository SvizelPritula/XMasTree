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
            Tree root = new Tree(new IComparable[] {9,5,3,6,4,7,2,8,1,10});
            Console.WriteLine(root.Search(6));
            Console.ReadKey();
        }
    }
}
