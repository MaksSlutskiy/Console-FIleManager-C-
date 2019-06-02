using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp9;

namespace ConsoleApp1
{
    class Directorys
    {
        Files files = new Files();
        Clear clear = new Clear();
        ConsoleKeyInfo key;
        public string way;
        string nameDir;
        string copyName;
        string namePath;
        string rename;
        string create;

        int top = 12;
        int left = 4;
        int sum1 = 0;
        int sum2 = 0;
        int sum3 = 0;
        int finish = 0;
        int finish2 = 0;

        public void Dir()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var allDirectory = Directory.EnumerateDirectories(way);

            Console.SetCursorPosition(left, top - 3);
            Console.WriteLine("┌────────┬──────────────────────╬");
            Console.SetCursorPosition(left, top - 2);
            Console.WriteLine("│ Folder │                      ║");
            Console.SetCursorPosition(left, top - 1);
            Console.WriteLine("├────────┴──────────────────────╬");

            do
            {
                string deleteName = "";

                foreach (var i in allDirectory)
                {
                    if (Control(i) == true)
                    {
                        if (sum1 == sum2)
                        {
                            var date = Directory.GetCreationTime(i);
                            Console.SetCursorPosition(left + 12, 10);
                            Console.WriteLine(date);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Green;

                            deleteName = i;
                            rename = i;
                            way = i;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        string result = Path.GetFileName(i);

                        if (result.Length > 30)
                        {
                            result = result.Insert(26, "...").Remove(29);

                        }
                        result = "│  " + result;
                        sum3 = result.Count();

                        for (int t = 0; t < 32 - sum3; t++)
                        {
                            result += " ";
                        }
                        result += "╬";
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine(result);
                        Console.CursorVisible = false;
                        sum1++;
                        top++;
                        if (sum1 == 23)
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(left, top);
                Console.WriteLine("└───────────────────────────────╬");

                if (allDirectory.Count() == 0)
                {
                    nameDir = way;
                }
                else
                {
                    nameDir = Path.GetDirectoryName(way);
                }
                top = 12;
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (sum2 + 1 < sum1 && sum2 + 1 < 23)
                        sum2++;
                }
                sum1 = 0;
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (sum2 > 0)
                        sum2--;
                }
                if (key.Key == ConsoleKey.Delete)
                {
                    Delete(deleteName);
                    sum2 = 0;
                }
                if (key.Key == ConsoleKey.F1)
                {
                    if (files.MoveFile == 0)
                        MoveDir();
                    else
                        files.Move();
                }
                if (key.Key == ConsoleKey.F2)
                {
                    if (files.CopyFile == 0)
                        CopyDir();
                    else
                        files.Copy();
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
                try
                {
                    if (key.Key == ConsoleKey.Tab)
                    {
                        files.FilesMenu(nameDir);
                        Console.SetCursorPosition(left, top - 3);

                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine("File not available!");
                    Thread.Sleep(2000);
                    clear.ClearTop(29, 8, 9);

                }

                if (key.Key == ConsoleKey.Escape)
                {
                    clear.ClearTop(left, top, 36);
                    sum2 = 0;
                    nameDir = Path.GetDirectoryName(way);
                    create = Path.GetDirectoryName(create);
                    break;
                }

                try
                {
                    if (key.Key == ConsoleKey.Enter)
                    {
                        clear.ClearTop(left, top, 36);
                        sum2 = 0;
                        create = way;
                        Dir();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(29, 8);
                    Console.WriteLine("Folder not available!");
                    Thread.Sleep(2000);
                    clear.ClearTop(29, 8, 9);
                }

            } while (true);
        }

        void Delete(string DeleteName)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(DeleteName);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                Directory.Delete(DeleteName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ Folder deleted!");
                Console.ForegroundColor = ConsoleColor.Red;
                clear.ClearTop(left, top, 36);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 8);
                Console.WriteLine("Select Folder!");
                Thread.Sleep(2000);
                clear.ClearTop(20, 8, 9);
            }
        }

        void MoveDir()
        {
            if (finish == 0)
            {
                copyName = way;
                finish = 1;
                namePath = Path.GetFileName(copyName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ Folder is in the clipboard. Select a location and click F1!");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                nameDir = nameDir + "\\" + namePath;
                try
                {
                    Directory.Move(copyName, nameDir);
                    clear.ClearTop1(1, 0, 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("╣ Folder is moved!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    finish = 0;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine("You can not move a directory into itself!");
                    Thread.Sleep(2000);
                    clear.ClearTop1(10, 8, 9);
                }
            }
        }

        void CopyDir()
        {
            if (finish2 == 0)
            {
                copyName = way;
                finish2 = 1;
                namePath = Path.GetFileName(copyName);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ Folder is in the clipboard. Select a location and click F2!");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                nameDir = nameDir + "\\" + namePath;
                try
                {
                    Directory.CreateDirectory(nameDir);
                    clear.ClearTop1(1, 0, 1);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("╣ Folder is copy!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    finish2 = 0;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(10, 8);
                    Console.WriteLine("Сopy error!");
                    Thread.Sleep(2000);
                    clear.ClearTop1(10, 8, 9);
                }
            }
        }

        void Rename()
        {
            ConsoleKeyInfo key2;
            string name = "";
            int sum = 0;
            int sum2 = 50;
            files.Table("Rename");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
            Console.SetCursorPosition(50, 5);

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
                    name = "Untitled folder";
                name = Path.GetDirectoryName(rename) + "\\" + name;
                Directory.Move(rename, name);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ Folder rename!");
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.CursorVisible = false;
            clear.ClearTop2(48, 2, 7);
        }

        void Create()
        {
            string name = "";
            int sum = 0;
            int sum2 = 50;
            files.Table("Create");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
            ConsoleKeyInfo key2;
            Console.SetCursorPosition(50, 5);

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
                    name = "Untitled folder";
                name = create + "\\" + name;
                Directory.CreateDirectory(name);
                clear.ClearTop1(1, 0, 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("╣ Folder create!");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.CursorVisible = false;
            clear.ClearTop2(48, 2, 7);

        }

        bool Control(string folder)
        {
            FileAttributes attributes = File.GetAttributes(folder);

            if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
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
            else
                return false;
        }
    }
}
