using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Net;
using System.Xml.Linq;

namespace pCourse1
{

    internal class SQL
    {
        private string connectString = "Server=localhost;Port=5432;Username=postgres;Password=154070120aa;Database=postgres";
        private string sqlString = "SELECT * FROM epass";
        private string sqlStringSurname = "SELECT num_lab, name_lab, address, responsible.fio FROM epass JOIN responsible ON epass.zav_id = responsible.id_lab WHERE responsible.fio LIKE";
        private string sqlStringNumLab = "SELECT num_lab,name_lab,address FROM epass WHERE num_lab = ";
        private string sqlStringAddress = "SELECT *\r\nFROM epass\r\nWHERE address LIKE ";
        private string[] address = new string[] { "ул Ленина, 89", "ул Конструкторов, 9" };
        private string sqlFullLab = "SELECT epass.id_lab,num_lab,name_lab,address,responsible.fio,furn_amount,techno_amount FROM epass JOIN responsible ON responsible.id_lab = epass.zav_id LEFT JOIN lab_amount ON lab_amount.id_lab = epass.id_lab WHERE epass.id_lab =";

        private NpgsqlConnection connectionSQL()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectString);
            connection.Open();
            return connection;
        }

        private NpgsqlCommand requestSQL(string sql) => new NpgsqlCommand(sql, connectionSQL());

        private string convertToSqlLikePercent(string sqlWord) => new string("'" + sqlWord + "%'");

        private string convertToSqlLike(string sqlWord) => new string("'" + sqlWord + "'");


        public void outputSQLFull()
        {
            NpgsqlDataReader sqlReader = requestSQL(sqlString).ExecuteReader();
            foreach (DbDataRecord rows in sqlReader)
            {
                Console.WriteLine("{0}\t|Номер кабинета -{1,4}|Название-{2,60}|\t{3,20}|", rows[0], rows[1], rows[2], rows[3]);
            }
            connectionSQL().Close();
        }


        public void outputSQLbySurname(string name)
        {
            string surname = convertToSqlLikePercent(name);
            NpgsqlDataReader sqlReader = requestSQL(sqlStringSurname + surname).ExecuteReader();
            foreach (DbDataRecord rows in sqlReader)
            {
                Console.WriteLine("{0,2}\t|{1,70}|{2,20}|{3,60}|", rows[0], rows[1], rows[2], rows[3]);
            }
        }

        public void outputSQLbyNumberLab(string number)
        {
            NpgsqlDataReader sqlReader = requestSQL(sqlStringNumLab + number).ExecuteReader();
            foreach (DbDataRecord rows in sqlReader)
            {
                Console.WriteLine("Номер лаборатории -{0,3}\t|{1,70}|Адрес -{2,20}|", rows[0], rows[1], rows[2]);
            }
        }

        public void outputSQLbyAddress(string index)
        {
            string address = string.Empty;
            address = convertToSqlLike(this.address[Convert.ToInt32(index)]);
            NpgsqlDataReader sqlReader = requestSQL(sqlStringAddress+address).ExecuteReader();
            foreach (DbDataRecord rows in sqlReader)
            {
                Console.WriteLine("{0}\t|Номер кабинета -{1,4}|Название-{2,60}|\t{3,20}|", rows[0], rows[1], rows[2], rows[3]);
            }
        }

        public void outputSQLFullLab(string index)
        {
            sqlFullLab += Convert.ToInt32(index);
            NpgsqlDataReader sqlReader = requestSQL(sqlFullLab).ExecuteReader();
            foreach (DbDataRecord rows in sqlReader)
            {
                Console.WriteLine("{0,2}|\t{1,4}|\t{2,60}|\t{3,40}|\t{4,20}|\t{5,20}|\t{6,20}|", rows[0], rows[1], rows[2], rows[3], rows[4], rows[5], rows[6]);
            }
        }


        






    }
}
