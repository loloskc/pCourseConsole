using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pCourse1
{
    internal class ConsoleMessage
    {
        public static void MainMessage()
        {
            Console.ResetColor();
            Console.WriteLine("Нажми на нужную кнопку ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1");
            Console.ResetColor();
            Console.WriteLine(" - Полная таблица");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2");
            Console.ResetColor();
            Console.WriteLine(" - Запрос по ФИО заведуюещего");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3");
            Console.ResetColor();
            Console.WriteLine(" - Запрос по номеру лаборатории");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4");
            Console.ResetColor();
            Console.WriteLine(" - Запрос по адрес");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5");
            Console.ResetColor();
            Console.WriteLine(" - подробная ифнормация по лаборатории");
        }

        private void ClearingConsole()
        {
            Console.Clear();
            MainMessage();
        }
    }
}
