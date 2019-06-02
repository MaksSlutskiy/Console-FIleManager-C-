using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp9;
namespace ConsoleApp1
{
    class Interface
    {
        Disk disk = new Disk();
        public void Start()
        {
            Decor();          
            disk.DiskMenu();
        }

        public void Decor()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("╣ Welcome to the file manager from Maks!");                  
            Console.SetCursorPosition(72, 0);
            Console.WriteLine("╠");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("╬╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╦╬");           
            for (int i = 2; i < 37; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("╣╠");
                Console.SetCursorPosition(71, i);
                Console.WriteLine("╣╠");               

            }           
            Console.SetCursorPosition(0, 36);
            Console.WriteLine("╬╩╩╩╩╩╩╩╩╩╬╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╬╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╬╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╩╬");
            Console.SetCursorPosition(0, 37);
            Console.WriteLine("╣Tab-Files║ Delete[folder/file]║ F1-Take/F1-Move║ F3-Rename[folder/file]╠");
            Console.SetCursorPosition(0, 38);
            Console.WriteLine("╣Esc-Exit ║ Home-Command Promt ║ F2-Take/F2-Copy║ F4-Create[folder/file]╠");
            Console.SetCursorPosition(0, 39);
            Console.WriteLine("╚═════════╩════════════════════╩════════════════╩═══════════════════════╝");           
            Console.CursorVisible = false;          
        }
    }
}
