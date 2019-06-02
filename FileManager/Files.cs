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
    class Files
    {
        Clear clear = new Clear();
        ConsoleKeyInfo key;
        public int MoveFile { get; set; } = 0;
        public int CopyFile { get; set; } = 0;
        public int Finish { get; set; } = 0;
        public int Finish2 { get; set; } = 0;
        string way;
        string nameDir;
        string copyName;
        string rename;
        string namePath;

        int top = 12;
        int left = 36;
        int sum1 = 0;
        int sum2 = 0;
        int sum3 = 0;

        public void FilesMenu(string str)
        {
            way = str;
            var allFiles = Directory.EnumerateFiles(way);

            Console.SetCursorPosition(left, top - 3);
            Console.WriteLine("╬──────────────────────┬────────┐");
            Console.SetCursorPosition(left, top - 2);
            Console.WriteLine("║                      │  File  │");
            Console.SetCursorPosition(left, top - 1);
            Console.WriteLine("╬──────────────────────┴────────┤");
            do
            {
                string DeleteName = "";
                foreach (var i in allFiles)
                {
                    if (Control(i) == true)
                    {
                        if (sum1 == sum2)
                        {
                            var date = Directory.GetCreationTime(i);
                            Console.SetCursorPosition(left + 3, 10);
                            Console.WriteLine(date);
                            DeleteName = i;
                            way = i;
                            rename = i;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        string result = "  " + Path.GetFileName(i);
                        if (result.Length > 30)
                        {
                            result = result.Insert(26, "...").Remove(29);

                        }
                        result = result + "│";

                        sum3 = result.Count();
                        for (int t = 0; t < 32 - sum3; t++)
                        {
                            result = " " + result;
                        }
                        result = "╬" + result;
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine(result);
                        sum1++;
                        top++;
                        if (sum1 == 23)
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(left, top);
                Console.WriteLine("╬───────────────────────────────┘");

                sum1 = 0;
                top = 12;
                if (allFiles.Count() == 0)
                {
                    nameDir = way;
                }
                else
                {
                    nameDir = Path.GetDirectoryName(way);
                }

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (sum2 + 1 < allFiles.Count() && sum2 + 1 < 23)
                        sum2++;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (sum2 > 0)
                        sum2--;
                }
                if (key.Key == ConsoleKey.Delete)
                {
                    Delete(DeleteName);
                    sum2 = 0;
                }
                if (key.Key == ConsoleKey.F1)
                {
                    Move();
                }
                if (key.Key == ConsoleKey.F2)
                {
                    Copy();

                }
                if (key.Key == ConsoleKey.F3)
                {
                    Rename();

                }
                if (key.Key == ConsoleKey.F4)
                {
                    Create();

                }
                if (key.Key == ConsoleKey.Home)
                {
                    Process.Start("CMD.exe");
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Process.Start(way);
                }
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Tab)
                {
                    sum2 = 0;
                    clear.ClearTop(left, top, 36);
                    clear.ClearTop(left + 1, top - 3, 12);
                    break;
                }

            } while (true);

        }

        public void Delete(string DeleteName)
        {
            try
            {

                File.Delete(DeleteName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ File deleted!");
                clear.ClearTop(left + 1, top, 36);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 8);
                Console.WriteLine("Select File!");
                Thread.Sleep(2000);
                clear.ClearTop(20, 8, 9);

            }
        }

        public void Move()
        {
            if (Finish == 0)
            {
                MoveFile = 1;
                copyName = way;
                Finish = 1;
                namePath = Path.GetFileName(copyName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ File is in the clipboard. Select a folder, click Tab and click F1!");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                nameDir = nameDir + "\\" + namePath;
                try
                {
                    File.Move(copyName, nameDir);
                    MoveFile = 0;
                    clear.ClearTop1(1, 0, 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("╣ File is moved!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Finish = 0;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(20, 8);
                    Console.WriteLine("Please take Tab to move file!");
                    Thread.Sleep(2000);
                    clear.ClearTop1(3, 8, 9);
                }
            }

        }

        public void Copy()
        {
            if (Finish2 == 0)
            {
                CopyFile = 1;
                copyName = way;
                Finish2 = 1;
                namePath = Path.GetFileName(copyName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ File is in the clipboard. Select a folder, click Tab and click F2!");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                nameDir = nameDir + "\\" + namePath;
                try
                {
                    FileStream fs = new FileStream(nameDir, FileMode.CreateNew);
                    fs.Close();
                    CopyFile = 0;
                    clear.ClearTop1(1, 0, 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("╣ File is copy!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Finish2 = 0;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(20, 8);
                    Console.WriteLine("File with this name already exists!");
                    Thread.Sleep(2000);
                    clear.ClearTop1(3, 8, 9);
                }
            }
        }

        void Rename()
        {
            Table("Rename");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
            ConsoleKeyInfo key2;
            string name = "";
            string extension;
            int sum = 0;
            int sum2 = left + 14;
            extension = Path.GetExtension(rename);
            Console.SetCursorPosition(left + 29, 5);
            Console.WriteLine(extension);
            Console.SetCursorPosition(left + 14, 5);

            while (true)
            {
                key2 = Console.ReadKey();
                if (key2.Key == ConsoleKey.Escape)
                {
                    sum = 1;
                    break;
                }
                if (key2.Key == ConsoleKey.Enter)
                    break;
                if (key2.Key == ConsoleKey.Backspace)
                {
                    if (sum2 > left + 14)
                    {
                        sum2--;
                        name = name.Remove(name.Length - 1);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("_");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(sum2, 5);

                }
                else
                {
                    name += key2.KeyChar.ToString();
                    sum2++;
                }

                if (name.Length == 15)
                    break;
            }
            if (sum == 0)
            {
                if (name == "")
                    name = "Untitled file";
                name = Path.GetDirectoryName(rename) + "\\" + name + extension;
                File.Move(rename, name);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ File rename!");
                Console.ForegroundColor = ConsoleColor.Red;
            }




            Console.CursorVisible = false;
            clear.ClearTop2(left + 12, 2, 7);


        }

        void Create()
        {
            Table("Create");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
            ConsoleKeyInfo key2;
            string name = "";
            int sum = 0;
            int sum2 = left + 14;
            Console.SetCursorPosition(left + 14, 5);

            while (true)
            {
                key2 = Console.ReadKey();
                if (key2.Key == ConsoleKey.Escape)
                {
                    sum = 1;
                    break;
                }
                if (key2.Key == ConsoleKey.Enter)
                    break;

                if (key2.Key == ConsoleKey.Backspace)
                {
                    if (sum2 > 50)
                    {
                        sum2--;
                        name = name.Remove(name.Length - 1);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("_");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(sum2, 5);
                }
                else
                {
                    name += key2.KeyChar.ToString();
                    sum2++;
                }

                if (name.Length == 15)
                    break;
            }
            if (sum == 0)
            {
                if (name == "")
                    name = "Untitled file";
                name = nameDir + "\\" + name;
                FileStream fs = new FileStream(name, FileMode.CreateNew);
                fs.Close();

                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ File create!");
                Console.ForegroundColor = ConsoleColor.Red;

            }
            Console.CursorVisible = false;
            clear.ClearTop2(48, 2, 7);
        }

        bool Control(string file)
        {

            FileAttributes attributes = File.GetAttributes(file);
            if (!((attributes & FileAttributes.System) == FileAttributes.System))
            {
                if (!((attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                    return true;
                else
                    return false;

            }
            else
                return false;
        }

        public void Table(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(48, 2);
            Console.WriteLine("╔═══════╦══════╦═══════");
            Console.SetCursorPosition(48, 3);
            Console.WriteLine("║       ║{0}║      ", str);
            Console.SetCursorPosition(48, 4);
            Console.WriteLine("║       ╚══════╝       ");
            Console.SetCursorPosition(48, 5);
            Console.WriteLine("║                      ");
            Console.SetCursorPosition(48, 6);
            Console.WriteLine("╚══════════════════════");
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
