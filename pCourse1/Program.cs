using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using pCourse1;


namespace Programs
{
    class Program
    {
        

        static void Main(string[] args)
        {
            SQL sqlR = new SQL();
            ConsoleMessage.MainMessage();
            var a = Console.ReadKey();
            Console.Clear();
            switch (a.KeyChar)
            {
                case '1':
                    sqlR.outputSQLFull();
                    break;
                case '2':
                    Console.WriteLine("Запрос по фамилии");
                    sqlR.outputSQLbySurname(Console.ReadLine());
                    break;
                case '3':
                    Console.WriteLine("Запрос по номеру");
                    sqlR.outputSQLbyNumberLab(Console.ReadLine());
                    break;
                case '4':
                    Console.WriteLine("Выберите адрес\n 0 ул Ленина, 89\n 1 ул Конструкторов");
                    sqlR.outputSQLbyAddress(Console.ReadLine());
                    break;
                case '5':
                    Console.WriteLine("Выберите лабораторию по индексу");
                    sqlR.outputSQLFullLab(Console.ReadLine());
                    break;

            }






        }
    }
}