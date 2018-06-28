using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace RecipeManagerApp.Helper
{
    public class RecipeDAO
    {

        public static bool AddRecipeAsync(Recipe r)
        {
            String query = @"INSERT INTO recipes VALUES (NULL, '" + r.title + "', '" + r.description + "' , " + RecipeManager.instance.GetCurrentUser().id + ");";
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            cmd.ExecuteNonQuery();

            IngredientDAO.AddIngredient((int)cmd.LastInsertedId , r);

            DBConnector.conn.Close();
            return true;
        }

        public static List<Recipe> GetAll(int userid)
        {
            List<Recipe> r = new List<Recipe>();
            String query = @"SELECT * FROM recipes WHERE users_id = " + userid;
            DBConnector.initAsync();
            MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                r.Add(new Recipe(reader["description"] + "", reader["title"] + ""));
                
                r.ElementAt(r.Count-1).id = int.Parse(reader["idrecipes"]+"");
                r.ElementAt(r.Count-1).ingredients = IngredientDAO.GetAll((r.ElementAt(r.Count - 1).id));
                
            }

            return r;
        }
    }

    

    //public List<House> getFreeHouses(DateTime arrival, DateTime departure)
    //{
    //    List<House> houses = new List<House>();

    //    String arrstr = arrival.Year + "-" + arrival.Month + "-" + arrival.Day;
    //    String depstr = departure.Year + "-" + departure.Month + "-" + departure.Day;
    //    String query = @"SELECT * FROM Houses , Reservation WHERE '" + arrstr + @"' NOT BETWEEN Reservation.date_in AND Reservation.date_out OR '" + depstr
    //        + @"' NOT BETWEEN Reservation.date_in AND Reservation.date_out";
    //    System.Windows.Forms.MessageBox.Show(arrival + "");
    //    System.Windows.Forms.MessageBox.Show(arrival.ToShortDateString());
    //    DBConnector.init();
    //    MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
    //    MySqlDataReader reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        System.Windows.Forms.MessageBox.Show(reader["idHouses"] + "");
    //    }

    //    return houses;
    //}

    //public bool deleteHouse(House h)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool deleteHouse(int sid)
    //{
    //    throw new NotImplementedException();
    //}

    ////public bool disablehouse(int id, datetime from, datetime until)
    ////{
    ////    house h = getbyid(id);
    ////    string query = "insert into disabledhouse values ('" + from + "' , '" + until + "' , " + h.houseid + " , " + h.housetypeid + ")";

    ////}

    //public List<House> getAll()
    //{
    //    List<House> houses = new List<House>();
    //    String query = @"SELECT * FROM Houses LEFT JOIN HouseType ON Houses.HouseType_idHouseType = HouseType.idHouseType";
    //    DBConnector.init();
    //    MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
    //    MySqlDataReader reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        houses.Add(new House(
    //            int.Parse(reader["idHouses"] + ""),
    //            int.Parse(reader["HouseType_idHouseType"] + ""),
    //            reader["HouseTypeName"] + "",
    //            int.Parse(reader["maxPeople"] + ""),
    //            float.Parse(reader["defaultPrice"] + "")
    //            ));
    //    }
    //    for (int i = 0; i < houses.Count; i++)
    //    {
    //        System.Windows.Forms.MessageBox.Show(houses.Count.ToString());
    //    }
    //    return houses;
    //}

    //public House getById(int id)
    //{
    //    String query = @"SELECT * FROM Houses WHERE idHouses = " + id + @" LEFT JOIN HouseType ON Houses.HouseType_idHouseType = HouseType.idHouseType";
    //    DBConnector.init();
    //    MySqlCommand cmd = new MySqlCommand(query, DBConnector.conn);
    //    MySqlDataReader dataReader = cmd.ExecuteReader();
    //    House h = new House();
    //    while (dataReader.Read())
    //    {
    //        h.HouseId = int.Parse(dataReader["idHouses"] + "");
    //        h.Typeid = int.Parse(dataReader["HouseType_idHouses"] + "");
    //        h.HouseName = dataReader["HouseTypeName"] + "";
    //        h.MaxPeople = int.Parse(dataReader["maxPeople"] + "");
    //        h.DefaultPrice = float.Parse(dataReader["defaultPrice"] + "");
    //    }
    //    return h;
    //}

    //public bool updateHouse(House h)
    //{
    //    throw new NotImplementedException();
    //}
}
