using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ1
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJack bj = new BlackJack();
            bj.Jogar();

            Console.ReadKey();
        }
    }
}
