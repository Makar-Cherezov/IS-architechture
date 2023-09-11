using System;
using System.Collections.Generic;
using System.IO;

namespace ЛР_1_консоль
{
    class View
    {
        static void ResetConsole()
        {
            Console.Clear();
            Console.WriteLine(Graphics.GetLogo());
        }
        static void GreetUser()
        {
            ResetConsole();
            Console.WriteLine("Давайте начнём работу с DataHandler!\n");
        }
        static void PrintMenu()
        {
            Console.WriteLine("Что вы хотите сделать с файлом?" + '\n' +
            "Для выбора нажмите нужную кнопку:" + '\n' +
            "0. Выбрать файл для чтения и записи." + '\n' +
            "1. Вывести все строки файла. " + '\n' +
            "2. Вывести запись по номеру." + '\n' +
            "3. Записать новые данные в файл." + '\n' +
            "4. Удалить запись из файла." + '\n' +
            "esc. Завершить работу." + '\n');
        }
        static void PrintByNumber(Controller controller)
        {
            Console.WriteLine("Введите номер записи.");
            bool success = false;
            while (!success)
            {
                try
                {
                    int position = int.Parse(Console.ReadLine());
                    ResetConsole();
                    Console.WriteLine(controller.GetLineByNumber(position));
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неверный ввод. Введите целое положительное число.");
                }
            }
        }
        static void SaveNewData(Controller controller)
        {
            List<string> productData = new List<string>();
            Console.WriteLine("Введите название товара: ");
            productData.Add(Console.ReadLine());
            Console.WriteLine("Введите название продавца: ");
            productData.Add(Console.ReadLine());
            Console.WriteLine("Введите описание товара: ");
            productData.Add(Console.ReadLine());
            
            string price = "";
            while(!Validator.IsCorrectPrice(price))
            {
                Console.WriteLine("Введите стоимость товара, используйте запятую для отделения десятичной части: ");
                price = Console.ReadLine();
            }
            productData.Add(price);

            Console.WriteLine("Есть ли товар в наличии? true/false: ");
            productData.Add(Console.ReadLine());
            Console.WriteLine("Введите дату появления товара в формате дд.мм.гггг: ");
            productData.Add(Console.ReadLine());
            controller.SaveNewData(productData);
            Console.WriteLine("Запись добавлена!");
        }
        static void ChangePath(Controller controller)
        {
            Console.WriteLine("Введите путь до файла:");
            if (controller.SetAndCheckPath(Console.ReadLine()))
            {
                Console.WriteLine("Выбран файл " + Path.GetFileName(controller.Path));
            }
            else Console.WriteLine("Неверно введён путь или файд не существует.");
            
        }
        static void DeleteData(Controller controller)
        {
            Console.WriteLine("Введите номер строки для удаления: ");
            try
            {
                int pos = int.Parse(Console.ReadLine());
                controller.DeleteData(pos);
                ResetConsole();
                Console.WriteLine($"Запись по номеру {pos} удалена!\n");
            }
            catch
            {
                Console.WriteLine("Ввод некорректен или такой строки нет в файле!\n");
            }
        }
        
        static void ProcessUserAction(Controller controller)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    ResetConsole();
                    ChangePath(controller);
                    break;
                case ConsoleKey.D1: 
                case ConsoleKey.NumPad1:
                    ResetConsole();
                    Console.WriteLine(Graphics.GetLine());
                    Console.WriteLine(Path.GetFileName(controller.Path) + ':');
                    controller.GetFullData().ForEach(Console.WriteLine);
                    Console.WriteLine(Graphics.GetLine() + '\n');
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ResetConsole();
                    PrintByNumber(controller);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ResetConsole();
                    SaveNewData(controller);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    DeleteData(controller);
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine(Graphics.GetExit());
                    Environment.Exit(0);
                    break;

                default: 
                    Console.WriteLine("Неверный ввод. Введите цифру 1-5.\n");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            GreetUser();
            ChangePath(controller);
            do
            {
                PrintMenu();
                ProcessUserAction(controller);
            } while (true);
            
            
            
        }
    }
}
