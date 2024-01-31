using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class ExtensionFunctions
    {

        const string ConnectionString = "Data Source=VATSYAYANA-WIN1;Initial Catalog=DB1; Integrated Security=true";

        public static DataTable RetrieveDataTable(this string tableName)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection))
                {

                    DataTable dataTable = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {

            List<T> list = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {

                T obj = new T();

                foreach (DataColumn col in dataTable.Columns)
                {

                    var property = typeof(T).GetProperty(col.ColumnName, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (property != null && row[col] != DBNull.Value)
                    {

                        property.SetValue(obj, Convert.ChangeType(row[col], property.PropertyType), null);
                    }
                }

                list.Add(obj);
            }

            return list;
        }

        public static DataTable ToDataTable<T>(this List<T> list)
        {

            DataTable dataTable = new DataTable();

            if (list.Count == 0)
                return dataTable;

            foreach (var property in typeof(T).GetProperties())
            {

                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (var item in list)
            {

                DataRow row = dataTable.NewRow();

                foreach (var property in typeof(T).GetProperties())
                {

                    row[property.Name] = property.GetValue(item);
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static void CreateTableInDB(this string tableName, DataTable dataTable)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand(GetCreateTableQuery(dataTable, tableName), connection))
                {

                    command.ExecuteNonQuery();
                }
            }
        }

        private static string GetCreateTableQuery(DataTable dataTable, string tableName)
        {

            string createTableQuery = $"CREATE TABLE {tableName} (";

            foreach (DataColumn column in dataTable.Columns)
            {

                createTableQuery += $"{column.ColumnName} {GetColumnDataType(column.DataType)}, ";
            }

            createTableQuery = createTableQuery.TrimEnd(',', ' ');
            createTableQuery += ")";

            return createTableQuery;
        }

        private static string GetColumnDataType(Type dataType)
        {
            
            if (dataType == typeof(decimal) || dataType == typeof(int))
            {

                return "numeric(18, 0)";
            }

            else if (dataType == typeof(string))
            {

                return "NVARCHAR(MAX)";
            }

            throw new ArgumentException($"Unsupported data type: {dataType}");
        }

        public static void InsertDataIntoDB(this string tableName, DataTable dataTable)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                foreach (DataRow row in dataTable.Rows)
                {

                    using (SqlCommand command = new SqlCommand(GetInsertDataQuery(row, tableName), connection))
                    {

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private static string GetInsertDataQuery(DataRow row, string tableName)
        {

            string columns = string.Join(", ", row.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            string values = string.Join(", ", row.ItemArray.Select(v => $"'{v}'"));

            return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        }
    }
}