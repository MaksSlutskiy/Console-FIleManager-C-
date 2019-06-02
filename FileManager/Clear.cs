using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Clear
    {
        public void ClearTop(int left, int top, int nexttop)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (top != nexttop)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine("_________________________________");
                top++;
            }
        }
        public void ClearTop1(int left, int top, int nexttop)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (top != nexttop)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine("___________________________________________________________________");
                top++;
            }
        }
        public void ClearTop2(int left, int top, int nexttop)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (top != nexttop)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine("_______________________");
                top++;
            }
        }     
    }
}
