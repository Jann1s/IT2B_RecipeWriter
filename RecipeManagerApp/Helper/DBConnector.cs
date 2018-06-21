using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace RecipeManagerApp.Helper
{
    class DBConnector
    {

        public static MySqlConnection conn;
        const String connStr = "server=localhost;user=admin;password=admin;database=mydb;persistsecurityinfo=True;SslMode=None;Convert Zero Datetime = True";

        public static async Task initAsync()
        {
            conn = new MySqlConnection(connStr);
            try
            {

                conn.Open();

            }
            catch (MySqlException mse)
            {
                if (mse.Number == 0)
                {
                    await new MessageDialog(mse.ToString()).ShowAsync();
                    
                }
                else if (mse.Number == 1)
                {
                    await new MessageDialog("ERROR2").ShowAsync();
                }
                await new MessageDialog("ERROR3").ShowAsync();
            }
        }
    }
}
