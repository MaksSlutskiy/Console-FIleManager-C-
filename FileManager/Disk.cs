using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Disk
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        ConsoleKeyInfo key;
        Directorys directorys = new Directorys();
        Clear clear = new Clear();
        int top = 2;
        int startleft=3;
        int left = 3;      
        int sum1 = 0;
        int sum2 = 0;
       
        public void DiskMenu()
        {                                     
            do
            {
                foreach (DriveInfo d in allDrives)
                {
                    if (Control(d) == true)
                    {
                        if (sum1 == sum2)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("╔═══════════╗");
                        Console.SetCursorPosition(left, top + 1);
                        Console.WriteLine("║           ║");
                        Console.SetCursorPosition(left, top + 2);
                        Console.WriteLine("║ Drive {0} ║", d.Name);
                        Console.SetCursorPosition(left, top + 3);
                        Console.WriteLine("║           ║");
                        Console.SetCursorPosition(left, top + 4);
                        Console.WriteLine("╚═══╤═══╤═══╝");
                        Console.SetCursorPosition(left, top + 5);
                        Console.WriteLine("   ██───██   ");
                        Console.CursorVisible = false;

                        if (sum1 == sum2)
                        {

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.SetCursorPosition(startleft + 5, top + 7);
                            Console.WriteLine("╒═════════════════════════════════════════════════╕");
                            Console.SetCursorPosition(startleft + 5, top + 8);
                            Console.WriteLine("     Drive name : {0} ", d.Name);
                            Console.SetCursorPosition(startleft + 5, top + 9);
                            Console.WriteLine("     Drive type: {0} ", d.DriveType);
                            Console.SetCursorPosition(startleft + 5, top + 10);
                            Console.WriteLine("     File system: {0} ", d.IsReady == true ? d.DriveFormat : "Unknown");
                            Console.SetCursorPosition(startleft + 5, top + 11);
                            Console.WriteLine("     Available space bytes: {0} ", d.IsReady == true ? d.AvailableFreeSpace.ToString() : "Unknown");
                            Console.SetCursorPosition(startleft + 5, top + 12);
                            Console.WriteLine("     Total available space bytes: {0} ", d.IsReady == true ? d.TotalFreeSpace.ToString() : "Unknown");
                            Console.SetCursorPosition(startleft + 5, top + 13);
                            Console.WriteLine("     Total size of drive bytes: {0} ", d.IsReady == true ? d.TotalSize.ToString() : "Unknown");
                            Console.SetCursorPosition(startleft + 5, top + 14);
                            Console.WriteLine("╘═════════════════════════════════════════════════╛");

                        }
                        left += 15;
                        sum1++;
                    }
                }                            
                left = startleft;
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (sum2 + 1 < sum1)
                        sum2++;
                }
                sum1 = 0;
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (sum2 > 0)
                        sum2--;
                }
                if (key.Key == ConsoleKey.Home)
                {
                    Process.Start("CMD.exe");
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    
                        clear.ClearTop1(startleft, 9, 17);
                        directorys.way = allDrives[sum2].Name;
                        directorys.Dir();                    
                }
                clear.ClearTop1(startleft, 8, 16);

            } while (true);          
        }
        bool Control(DriveInfo d)
        {

            if (d.DriveType.ToString() == "Fixed")
            {
                return true;
            }
            else
                return false;  
        }
    }
}
