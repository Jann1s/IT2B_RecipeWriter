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
        const String connStr = "server=37.120.171.52;port=8531;user=root;password=stenden11;database=mydb;persistsecurityinfo=True;SslMode=None;Convert Zero Datetime = True";

        public static void initAsync()
        {
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (MySqlException mse)
            {
                /*
                 * Either implement a logging system or use the debugger.
                 * 
                if (mse.Number == 0)
                {
                    await new MessageDialog(mse.ToString()).ShowAsync();
                    
                }
                else if (mse.Number == 1)
                {
                    await new MessageDialog("ERROR2").ShowAsync();
                }
                await new MessageDialog("ERROR3").ShowAsync();
                */
            }
        }
    }
}
