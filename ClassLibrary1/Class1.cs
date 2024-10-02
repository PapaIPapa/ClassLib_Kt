using System;
using System.IO;
namespace ClassLibrary1
{
    public class FileHandler
    {
        public string ReadTextFile(string filePath)
        {
            string fileContent = "";
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                try
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        fileContent += ("\n" + line);
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
                finally
                {
                    sr.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            return fileContent;
        }
        public void WriteTextFile(string filePath, string fileContent)
        {
            string[] allContent = fileContent.Split("\n");
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                try
                {
                    for (int i = 1; i < allContent.Length; i++)
                    {
                        sw.WriteLine(allContent[i]);
                    }
                }
                finally
                {
                    sw.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
        public void WriteFile(string filePath, string content)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Файл не найден.", filePath);
                }
                else
                {
                    Console.WriteLine("Файл найден");
                    WriteTextFile(filePath, content);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void CheckedOperation()
        {
            int a = int.MaxValue;
            int b = 1;
            checked
            {
                int result = a + b;
                Console.WriteLine("Checked: Результат операции сложения: " + result);
            }
        }
        public void UncheckedOperation()
        {
            int a = int.MaxValue;
            int b = 1;
            unchecked
            {
                int result = a + b;
                Console.WriteLine("Unchecked: Результат операции сложения: " + result);
            }
        }
    }

}
