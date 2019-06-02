using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Files
    {
        public string WayFile(string str)
        {
            FileInfo source2 = new FileInfo(str);

            if (!source2.Exists)
                return null;
            else
                return str;

        }
        public void MoveFile(string str, string str2)
        {

            File.Move(str, str2);
        }
        public void CopyFile(string str, string str2)
        {
            File.Copy(str, str2);
            Console.WriteLine("\nFile copied to the specified address!");
        }
        public void DeleteFile(string str)
        {
            File.Delete(str);

        }
        public void CreateFile(string str)
        {
            FileStream fs = new FileStream(str, FileMode.CreateNew);
            fs.Close();

        }
        public void RenameFile(string str, string str2)
        {
            string name = Path.GetDirectoryName(str) + "\\" + str2 + Path.GetExtension(str);
            File.Move(str, name);
        }
        public void PrintAll(string str)
        {

            var res = Directory.EnumerateFiles(str);
            Console.WriteLine("\nAll files in the directory:");
            foreach (var i in res)
            {
                Console.WriteLine(Path.GetFileName(i));
            }

        }

    }
}
