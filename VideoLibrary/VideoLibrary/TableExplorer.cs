using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoLibrary
{
    public static class TableExplorer
    {

        private static readonly SqlConnectionStringBuilder SqlConStrBuild = new SqlConnectionStringBuilder()
        {
            DataSource = @"(LocalDB)\v11.0",
            AttachDBFilename = string.Format(@"D:\VideoLibrary\VideoLibrary\App_Data\VideoLibraryDB.mdf"),

            //AttachDBFilename = string.Format(@"{0}\App_Data\VideoLibraryDB.mdf", Application.StartupPath),
            // ----- при снятии коментария приложение работает
            // ----- работает для exe-файла из папки bin так как
            // ----- при каждой компиляции создается новый єкземпляр базы данных
            // ----- из папки app_data; для запуска через VS поменять строку подключения
            IntegratedSecurity = true
        };
        
        public static string Connection {
            get
            {
                return SqlConStrBuild.ConnectionString;
            }
        }
      
        private static Dictionary<string, SqlDataAdapter> adapters = new Dictionary<string, SqlDataAdapter>();

        public static DataTable SelectTable(string command, string tableName)
        {

            string sqlCommand = tableName + " " + command;

            DataTable table = new DataTable(tableName);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, Connection)
            {
                MissingSchemaAction = MissingSchemaAction.AddWithKey
            };

            adapter.Fill(table);
            foreach (DataColumn col in table.Columns)
            {
                col.ReadOnly = true;
            }

            return table;
        }

        

        public static List<string> GetVideoLibTableNames()
        {
            List<string> s = new List<string>();
            string command = string.Format("Use \"{0}\" SELECT Name FROM dbo.sysobjects WHERE (xtype = 'U')", SqlConStrBuild.AttachDBFilename);
            SqlDataAdapter adapter = new SqlDataAdapter(command, Connection);

            DataTable table = new DataTable();

            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
                s.Add(row[0].ToString());

            return s;
        }



        public static void GetWholeDB(DataSet VideoLib)
        {

            List<String> tables = GetVideoLibTableNames();
            string command = "";

            foreach (string table in tables)
            {
                command = string.Format("SELECT * FROM {0};", table);

                SqlDataAdapter adapter = new SqlDataAdapter(command, Connection);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                DataTable DBTable = new DataTable(table);
                adapter.FillSchema(DBTable, SchemaType.Mapped);

                foreach (DataColumn col in DBTable.Columns)
                {
                    if (col.AutoIncrement)
                    {
                        col.AutoIncrementSeed = -1;
                        col.AutoIncrementStep = -1;
                    }
                }

                adapter.Fill(DBTable);
                VideoLib.Tables.Add(DBTable);
                if (DBTable.PrimaryKey.Length != 0)
                    ConfigureTableAdapter(DBTable, adapter);
                if (adapters.Values.Count < VideoLib.Tables.Count)
                    adapters.Add(DBTable.TableName, adapter);
            }

            PerformRelations(VideoLib);
        }

        private static void PerformRelations(DataSet ds)
        {
            DataTable actors = ds.Tables["Actors"];
            DataTable movieActors = ds.Tables["MovieActors"];
            DataTable movies = ds.Tables["Movies"];
            DataTable directors = ds.Tables["Directors"];
            DataTable orders = ds.Tables["Orders"];
            DataTable orderDetails = ds.Tables["OrderDetails"];
            DataTable viewers = ds.Tables["Viewers"];


            ds.Relations.Add("Actors_MovieActors", actors.Columns["ActorID"], movieActors.Columns["ActorID"]);
            ds.Relations.Add("Movies_MovieActors", movies.Columns["MovieID"], movieActors.Columns["MovieID"]);
            ds.Relations.Add("Directors_Movies", directors.Columns["DirectorID"], movies.Columns["DirectorID"]);
            ds.Relations.Add("Movies_OrderDetails", movies.Columns["MovieID"], orderDetails.Columns["MovieID"]);
            ds.Relations.Add("Movies_Orders", movies.Columns["MovieID"], orders.Columns["MovieID"]);
            ds.Relations.Add("Viewers_Orders", viewers.Columns["ViewerID"], orders.Columns["ViewerID"]);
        }

        public static string DeleteTable(string tableName)
        {
            string command = "DROP TABLE " + tableName + " ";
            String result = "Table " + tableName + " was successfuly deleted!";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Connection))
                {
                    SqlCommand cmd = new SqlCommand(command, sqlConnection);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public static void UpdateTableDataSource(DataTable table)
        {
            try
            {
                adapters[table.TableName].Update(table);
                MessageBox.Show("Table " + table.TableName + " was successfuly updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateDataSource(DataSet vLib)
        {
            try
            {
                foreach (DataTable table in vLib.Tables)
                {
                    adapters[table.TableName].Update(table);
                }
                MessageBox.Show("Whole Database was successfuly updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static void adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                DataRow insertedRow = e.Row;
                DataColumn column = null;
                foreach (DataColumn col in e.Row.Table.Columns)
                {
                    if (!col.AutoIncrement) continue;
                    column = col; col.ReadOnly = false; col.AllowDBNull = true;
                }
                if (column != null)
                {
                    try
                    {
                        insertedRow[column.ColumnName] = e.Command.Parameters["New" + column.ColumnName].Value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        column.ReadOnly = true;
                    }
                }
            }
        }

        private static void ConfigureTableAdapter(DataTable table, SqlDataAdapter tabAdapter)
        {

            #region Configure Update Command

            StringBuilder cmdUpdate = new StringBuilder("UPDATE " + table.TableName + " SET");
            StringBuilder where = new StringBuilder(" WHERE ");
            DataColumn[] PKey = table.PrimaryKey;

            foreach (DataColumn col in table.Columns)
            {
                if (!col.AutoIncrement)
                    cmdUpdate.AppendFormat(" {0} = @{1}, ", col.ColumnName, col.ColumnName);

                if (PKey.Contains(col))
                {
                    if (PKey.Length > 1 && !col.Equals(PKey[0]))
                    {
                        where.AppendFormat(" AND {0} = @{1}", col.ColumnName, col.ColumnName);
                    }
                    else
                        where.AppendFormat(" {0} = @{1} ", col.ColumnName, col.ColumnName);
                }
            }
            cmdUpdate.Remove(cmdUpdate.Length - 2, 1);
            cmdUpdate.Append(where);

            tabAdapter.UpdateCommand = new SqlCommand(cmdUpdate.ToString(), tabAdapter.SelectCommand.Connection);

            var updateParameters = tabAdapter.UpdateCommand.Parameters;

            SqlDbType type = SqlDbType.NVarChar;
            int size = 20;

            foreach (DataColumn col in table.Columns)
            {

                if (col.DataType != typeof(String))
                {
                    size = 0;
                    if (col.DataType == typeof(Int32))
                        type = SqlDbType.Int;

                    if (col.DataType == typeof(DateTime))
                        type = SqlDbType.Date;

                    if (col.DataType == typeof(Decimal))
                        type = SqlDbType.Money;

                    if (col.DataType == typeof(Byte))
                        type = SqlDbType.TinyInt;
                }
                else
                {
                    type = SqlDbType.NVarChar;
                    size = 20;
                }

                updateParameters.Add(col.ColumnName, type, size, col.ColumnName);
            }

            #endregion

            #region Configure Delete Command

            StringBuilder cmdDelete = new StringBuilder("DELETE " + table.TableName + " WHERE ");

            if (PKey.Length != 0)
            {
                cmdDelete.AppendFormat(" {0} = @{1} ", PKey[0].ColumnName, PKey[0].ColumnName);

                if (PKey.Length > 1)
                {
                    for (int i = 1; i < PKey.Length; i++)
                        cmdDelete.AppendFormat(" AND {0} = @{1}", PKey[i].ColumnName, PKey[i].ColumnName);
                }
            }
            else
            {

            }
            tabAdapter.DeleteCommand = new SqlCommand(cmdDelete.ToString(), tabAdapter.SelectCommand.Connection);

            var deleteParameters = tabAdapter.DeleteCommand.Parameters;

            type = SqlDbType.Int;
            size = 0;

            foreach (DataColumn col in PKey)
            {
                deleteParameters.Add(col.ColumnName, type, size, col.ColumnName);
            }

            #endregion

            #region Configure Insert Command

            StringBuilder cmdInsert = new StringBuilder("INSERT " + table.TableName + " VALUES (");
            StringBuilder set = new StringBuilder("");

            foreach (DataColumn col in table.Columns)
            {
                if (col.AutoIncrement)
                    set.AppendFormat("); SET @New{0} = @@IDENTITY;", col.ColumnName);
                else
                    cmdInsert.AppendFormat(" @{0},", col.ColumnName);
            }

            cmdInsert.Remove(cmdInsert.Length - 1, 1);
            if (set.ToString() == "")
                cmdInsert.Append(");");
            cmdInsert.Append(set);

            tabAdapter.InsertCommand = new SqlCommand(cmdInsert.ToString(), tabAdapter.SelectCommand.Connection);

            var insertParameters = tabAdapter.InsertCommand.Parameters;

            foreach (DataColumn col in table.Columns)
            {
                if (col.DataType != typeof(String))
                {
                    size = 0;
                    if (col.DataType == typeof(Int32))
                        type = SqlDbType.Int;

                    if (col.DataType == typeof(DateTime))
                        type = SqlDbType.Date;

                    if (col.DataType == typeof(Decimal))
                        type = SqlDbType.Money;

                    if (col.DataType == typeof(Byte))
                        type = SqlDbType.TinyInt;
                }
                else
                {
                    type = SqlDbType.NVarChar;
                    size = 20;
                }

                if (!col.AutoIncrement)
                {
                    insertParameters.Add(col.ColumnName, type, size, col.ColumnName);
                }
                else
                {
                    var outputParameter = insertParameters.Add("New" + col.ColumnName, type);
                    outputParameter.Direction = ParameterDirection.Output;
                }
            }

            #endregion

            tabAdapter.RowUpdated += adapter_RowUpdated;
        }
    }
}
