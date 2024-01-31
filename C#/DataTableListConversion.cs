using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Data;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;

namespace ConsoleApp2
{
    public class Friends
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }

    class DataTableListConversion
    {
        static void Main(string[] args)
        {

            string tableName = "Friends";
            DataTable dataTable = tableName.RetrieveDataTable();
            foreach (DataRow dataRow in dataTable.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    Console.WriteLine(item);
                }
            }

            List<Friends> friendList = dataTable.ToList<Friends>();
            foreach (var x in friendList)
            {

                Console.WriteLine($"Name: {x.Name}, Gender: {x.Gender}, Age: {x.Age}");
            }

            DataTable dataTable2 = friendList.ToDataTable();
            foreach (DataRow dataRow in dataTable2.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {

                    Console.WriteLine(item);
                }
            }

            string tableName2 = "[Friends Forever]";
            tableName2.CreateTableInDB(dataTable2);
            tableName2.InsertDataIntoDB(dataTable2);

            Console.ReadLine();
        }    
    }
}