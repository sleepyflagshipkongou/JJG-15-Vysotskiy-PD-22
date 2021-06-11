using System;
using System.IO;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainPath = @".\rootFolder";
            const sbyte FOLDERS_AMOUNT = 100;
            const string FOLDER_NAME = "Folder_";

            DirectoryInfo directory = new DirectoryInfo(mainPath);
            if(!directory.Exists)
                directory.Create();

            for (int i = 0; i < FOLDERS_AMOUNT; i++)
                directory.CreateSubdirectory(FOLDER_NAME + i);

            Console.WriteLine($"В директории {Path.GetFullPath(mainPath)} было создано {FOLDERS_AMOUNT} папок,");
            Console.WriteLine("Нажмите любую клавишу что би удалить их . . . ");
            Console.ReadKey();

            for (int i = 0; i < FOLDERS_AMOUNT; i++)
                Directory.Delete(mainPath + @"\" + FOLDER_NAME + i);

            string tempPath = ".";
            sbyte folderCounter = 0;

            for (int i = 0; i < FOLDERS_AMOUNT; i++)
            {
                tempPath += (@"\" + FOLDER_NAME + i);
                try
                {
                    directory.CreateSubdirectory(tempPath);
                    folderCounter++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }

            Console.WriteLine($"В директории {Path.GetFullPath(mainPath)} было создано {folderCounter} папок, вложених одна в одну.");
            Console.WriteLine("Нажмите любую клавишу что би удалить их . . . ");
            Console.ReadKey();

            Directory.Delete(mainPath + @"\" + FOLDER_NAME + 0, true);
                
            Console.ReadKey();
        }
    }
}
