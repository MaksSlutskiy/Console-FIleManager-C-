using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Begin
    {
        //Cd cd = new Cd();
        Directorys directorys = new Directorys();
        Files files = new Files();
        string command { get; set; }
        string way { get; set; } = "C:\\Windows\\System32";
        int ptr = 0;
        Dictionary<int, string> keys = new Dictionary<int, string>();
        public Begin()
        {

            keys.Add(1, "cd");
            keys.Add(2, "info");
            keys.Add(3, "dirmove");
            keys.Add(4, "filemove");
            keys.Add(5, "dircopy");
            keys.Add(6, "filecopy");
            keys.Add(7, "delfile");
            keys.Add(8, "deldir");
            keys.Add(9, "crfile");
            keys.Add(10, "crdir");
            keys.Add(11, "refile");
            keys.Add(12, "redir");
            keys.Add(13, "clear");
            keys.Add(14, "help");
        }

        public void Start()
        {
            Console.WriteLine("Maxoft Winux [Version 0.0.0.1]\n(m) Corporation Maksoft presents,2019. Your rights are not protected(-_-)");
            do
            {

                Console.Write($"\n{way}>");
                command = Console.ReadLine();
                String[] elements = Regex.Split(command, " ");
                int sum = 0;

                elements[0] = elements[0].ToLower();
                var res = from i in keys
                          where i.Value.Contains(elements[0])
                          select i.Key;
              
                foreach (var i in res)
                {
                    if (i == 1)
                    {
                        for (int j = 2; j < elements.Count(); j++)
                        {
                            elements[1] = elements[1] + " " + elements[j];
                        }
                        if (ptr == 1)
                        {
                            if (!way.Contains(elements[1]))
                                elements[1] = way + "\\" + elements[1];
                            else
                                ptr = 0;
                        }
                        if (directorys.Way(elements[1]) == "1")
                        {
                            Console.WriteLine("Repeated enter address (use followed transition by directory!).");
                        }
                        else if (directorys.Way(elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            way = directorys.Way(elements[1]);
                            ptr = 1;
                        }
                    }
                    if (i == 2)
                    {
                        directorys.PrintAll(way);
                        files.PrintAll(way);

                    }
                    if (i == 3)
                    {

                        if (directorys.Way(elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else if (directorys.Way(elements[2]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            directorys.MoveDirectorys(elements[1], elements[2]);
                            Console.WriteLine("Dictionary moved to the specified address!");
                        }
                    }
                    if (i == 4)
                    {
                        if (files.WayFile(elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid file path, try again.");
                        }
                        else if (files.WayFile(elements[2]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            files.MoveFile(elements[1], elements[2]);
                            Console.WriteLine("\nFile moved to the specified address!");
                        }
                    }
                    if (i == 5)
                    {
                        if (directorys.Way(elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else if (directorys.Way(elements[2]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            directorys.CopyDirectorys(elements[1], elements[2]);
                            Console.WriteLine("Directory copied to the specified address.");
                        }
                    }
                    if (i == 6)
                    {
                        if (files.WayFile(elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid file path, try again.");
                        }
                        else if (files.WayFile(elements[2]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            files.CopyFile(elements[1], elements[2]);
                            Console.WriteLine("\nFile copied to the specified address.");
                        }
                    }
                    if (i == 7)
                    {
                        for (int j = 2; j < elements.Count(); j++)
                        {
                            elements[1] = elements[1] + " " + elements[j];

                        }
                        if (files.WayFile(way + "\\" + elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid file path, try again.");
                        }
                        else
                        {
                            files.DeleteFile(way + "\\" + elements[1]);
                            Console.WriteLine("\nFile deleted.");
                        }
                    }
                    if (i == 8)
                    {
                        for (int j = 2; j < elements.Count(); j++)
                        {
                            elements[1] = elements[1] + " " + elements[j];

                        }
                        if (directorys.Way(way + "\\" + elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            directorys.DeleteDir(way + "\\" + elements[1]);
                            Console.WriteLine("Directory deleted.");
                        }
                    }
                    if (i == 9)
                    {
                        for (int j = 2; j < elements.Count(); j++)
                        {
                            elements[1] = elements[1] + " " + elements[j];

                        }

                        files.CreateFile(way + "\\" + elements[1]);
                        Console.WriteLine("File created.");
                    }
                    if (i == 10)
                    {
                        for (int j = 2; j < elements.Count(); j++)
                        {
                            elements[1] = elements[1] + " " + elements[j];

                        }

                        directorys.CreateDir(way + "\\" + elements[1]);
                        Console.WriteLine("Directory created.");
                    }
                    if (i == 11)
                    {
                        if (files.WayFile(way + "\\" + elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid file path, try again.");
                        }                        
                        else
                        {
                            files.RenameFile(way + "\\" + elements[1], elements[2]);
                            Console.WriteLine("File rename.");
                        }                       
                    }
                    if (i == 12)
                    {
                        if (directorys.Way(way + "\\" + elements[1]) == null)
                        {
                            Console.WriteLine("\nInvalid directory path, try again.");
                        }
                        else
                        {
                            directorys.RenameDir(way, elements[1], elements[2]);
                            Console.WriteLine("Directory rename.");
                        }
                    }
                    if (i==13)
                    {
                        Console.Clear();

                    }
                    if(i==14)
                    {
                        Commands();
                    }
                    sum = 1;
                }
                if (sum == 0)
                    Console.WriteLine("\nThere is no this command!\n");

            } while (true);
        }
        void Commands()
        {
            Console.WriteLine("\n\nAll commands:\n\ncd - [way] | moving through directories");
            Console.WriteLine("\ninfo | shows all folders and files along this way"); 
            Console.WriteLine("\nclear | clear display\n\nhelp | All commands");
            Console.WriteLine("\ndirmove [FullWayFrom] [FullWayWhere] | Move folder");
            Console.WriteLine("\nfilemove [FullWayFrom] [FullWayWhere] | Move file");
            Console.WriteLine("\ndircopy [FullWayFrom] [FullWayWhere] | Copy folder");
            Console.WriteLine("\nfilecopy [FullWayFrom] [FullWayWhere] | Copy file");
            Console.WriteLine("\ndelfile [Name] | Delete file");
            Console.WriteLine("\ndeldir [Name] | Delete folder");
            Console.WriteLine("\ncrfile [Name] | Create file");
            Console.WriteLine("\ncrdir [Name] | Create folder");
            Console.WriteLine("\nrefile [Name] | Rename file");
            Console.WriteLine("\nredir [Name] | Rename folder");
        }


    }
}
