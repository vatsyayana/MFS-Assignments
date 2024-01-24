using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void ShowReadAndWriteMenu()
        {

            Console.WriteLine("What you want to do? Please choose from one of the options below (1 or 2):");
            Console.WriteLine("1. Read a file");
            Console.WriteLine("2. Write a file");
        }

        static void ReadAFile()
        {

            string fileName = "";
            Console.WriteLine("Please name the file you want to read:");
            fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {

                string readText = File.ReadAllText(fileName);
                Console.WriteLine(readText);
            }

            else
            {

                Console.WriteLine("File with the given name doesn't exist!");
            }
        }

        static void WriteAFile()
        {

            string fileName = "";
            Console.WriteLine("Please name the file you want to write into:");
            fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {

                int choiceOfUserInAppendAndOverwriteMenu = 0;
                Console.WriteLine("What you want to do? Please choose from one of the options below (1 or 2):");
                Console.WriteLine("1. Append");
                Console.WriteLine("2. Overwrite");
                choiceOfUserInAppendAndOverwriteMenu = Convert.ToInt32(Console.ReadLine());

                string writeText = "";
                Console.WriteLine("Please write what you want:");
                writeText = Console.ReadLine();

                if (choiceOfUserInAppendAndOverwriteMenu == 1)
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(writeText);
                    }
                    Console.WriteLine("File has been successfully appended!");
                }

                else if (choiceOfUserInAppendAndOverwriteMenu == 2)
                {

                    File.WriteAllText(fileName, writeText);
                    Console.WriteLine("File has been successfully overwritten!");
                }

                else
                {

                    Console.WriteLine("Please select an option (1 or 2) from the given menu!");
                }
            }

            else
            {

                string writeText = "";
                Console.WriteLine("A new file with the given name is created as no such file existed.");
                Console.WriteLine("Please write what you want:");
                writeText = Console.ReadLine();
                File.WriteAllText(fileName, writeText);
                Console.WriteLine("File has been succesfully written!");
            }
        }

        static void Main(string[] args)
        {

            bool choiceOfUserToDisplayReadAndWriteMenu = true;

            do
            {

                int choiceOfUserInReadAndWriteMenu = 0;
                ShowReadAndWriteMenu();
                choiceOfUserInReadAndWriteMenu = Convert.ToInt32(Console.ReadLine());

                if (choiceOfUserInReadAndWriteMenu == 1)
                {

                    ReadAFile();
                }

                else if (choiceOfUserInReadAndWriteMenu == 2)
                {

                    WriteAFile();
                }

                else
                {

                    continue;
                }

                Console.WriteLine("Do you want to perform any read or write opration? If yes, then enter 'true' otherwise enter 'false'.");
                choiceOfUserToDisplayReadAndWriteMenu = Convert.ToBoolean(Console.ReadLine());
            } while (choiceOfUserToDisplayReadAndWriteMenu);
            
        }
    }
}