using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace WarechouseInterface.Managers
{
    public class SqlConnectManager
    {
    /*    private string SqlConnection;
        public SqlConnectManager()
        {
            SqlConnection = ConfigurationManager.AppSettings.Get("SqlConnect");
        }

        public T ExecuteFirstOrDefault<T>(string query)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(SqlConnection))
                {
                    var result = cnn.QueryFirstOrDefault<T>(query, new DynamicParameters());

                    return result;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd Krytyczny!! {e}");
                return default;
            }
        }

        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(SqlConnection))
                {
                    var result = cnn.Query<T>(query, new DynamicParameters());

                    return result;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Błąd Krytyczny!! {e}");
                return null;
            }
        }*/
    }
}
