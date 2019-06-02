using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Directorys
    {

        public string Way(string str)
        {
            try
            {
                DirectoryInfo source = new DirectoryInfo(str);

                if (!source.Exists)
                    return null;
                else
                    return str;
            }
            catch (Exception)
            {
                return "1";

            }
        }
        public void MoveDirectorys(string str, string str2)
        {

            Directory.Move(str, str2);
            Console.WriteLine("\nDirectory moved to the specified address!");

        }
        public void CopyDirectorys(string fromDir, string toDir)
        {
            Directory.CreateDirectory(toDir);
            foreach (string s1 in Directory.GetFiles(fromDir))
            {
                string s2 = toDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(fromDir))
            {
                CopyDirectorys(s, toDir + "\\" + Path.GetFileName(s));
            }

        }
        public void DeleteDir(string str)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(str);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            Directory.Delete(str);

        }
        public void CreateDir(string str)
        {

            Directory.CreateDirectory(str);
        }
        public void RenameDir(string str, string name, string str2)
        {

            Directory.CreateDirectory(str + "\\" + str2);
            foreach (string s1 in Directory.GetFiles(str + "\\" + str2))
            {
                string s2 = str + "\\" + str2;
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(str))
            {
                CopyDirectorys(s, str + "\\" + str2);
            }
            DeleteDir(str + "\\" + name);

        }
        public void PrintAll(string str)
        {

            var res = Directory.EnumerateDirectories(str);
            Console.WriteLine("\nAll folders in the directory:");

            foreach (var i in res)
            {
                Console.WriteLine(Path.GetFileName(i));

            }

        }
    }
}
