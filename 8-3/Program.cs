using System;
using System.IO;

namespace DirectoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCatalogs();
            Count();
        }
        static void ShowFoulderSize (string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize} байт");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace} байт");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
        }
        static void GetCatalogs()
        {

            string dirName = @"/";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Папки: ");
                string[] dirs = Directory.GetDirectories(dirName);

                foreach (string d in dirs)
                {
                    Console.WriteLine(d);

                }

                Console.WriteLine();
                Console.WriteLine("Файлы: ");
                string[] files = Directory.GetFiles(dirName);

                foreach (string s in files)
                    Console.WriteLine(s);

            }
        }
        static void Count()
        {

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/");
                if (dirInfo.Exists)
                {
                    Console.WriteLine($"Кол-во папок и файлов: {dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length}");
                }
                DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                if (!newDirectory.Exists)
                    newDirectory.Create();
                Console.WriteLine("Новый директорий создан");
                DirectoryInfo delInfo = new DirectoryInfo(@"/newDirectory");
                delInfo.Delete(true);
                Console.WriteLine("Директорий удален");
                Console.WriteLine($"Кол-во папок и файлов: {dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}