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
            Console.WriteLine("Давайте начнём работу с DataHandler! " +
                "Какой файл вы хотите открыть?");
        }
        static void PrintMenu()
        {
            Console.WriteLine("Что вы хотите сделать с файлом?" + '\n' +
            "Для выбора нажмите нужную кнопку:" + '\n' +
            "0. Выбрать файл для чтения и записи." + '\n' +
            "1. Вывести все строки файла. " + '\n' +
            "2. Вывести запись по номеру." + '\n' +
            "3. Записать новые данные в файл." + '\n' +
            "4. Удалить записи из файла." + '\n' +
            "5. Изменить записи в файле" + '\n' +
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
            Console.WriteLine("Введите стоимость товара, используйте запятую для отделения десятичной части: ");
            productData.Add(Console.ReadLine());
            Console.WriteLine("Есть ли товар в наличии? true/false: ");
            productData.Add(Console.ReadLine());
            Console.WriteLine("Введите дату появления товара в формате дд.мм.гггг: ");
            productData.Add(Console.ReadLine());
            controller.SaveNewData(productData);
            Console.WriteLine("Запись добавлена!");
        }
        static void ChangePath(Controller controller)
        {
            Console.WriteLine(controller.SetAndCheckPath(Console.ReadLine()));
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
                    Console.WriteLine(Path.GetFileName(controller.Path) + ':');
                    controller.GetFullData().ForEach(Console.WriteLine);
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
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                default: 
                    Console.WriteLine("Неверный ввод. Введите цифру 1-5.");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            GreetUser();
            ChangePath(controller);
            ConsoleKeyInfo cki;
            do
            {
                PrintMenu();
                ProcessUserAction(controller);
            } while (true);
            
            
            
        }
    }
}
