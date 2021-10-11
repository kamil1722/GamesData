using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GamesData.Models;


namespace GamesData.Controllers
{
    //Контроллер для соединения таблиц 
    public class TablesJoinController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Results"] = ListJoinController.TablesColumnsDisplay();
            return View();
        }
    }
    public class ListJoinController
    {
        public static IList<GameGenre> TablesColumnsDisplay()
        {
            List<GameGenre> jt = new List<GameGenre>();
            string connection = "Data Source =LAPTOP-SK4D7Q04\\SQLEXPRESS; user = User1L; password=1722; Initial Catalog=Test7; Trusted_Connection=True;";
            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                using (SqlCommand sqlcomm = new SqlCommand("SELECT GamesTable.NameGame, GamesTable.NameStudio, GenresTable.NameGenres" +
                    " FROM GamesTable" +
                    " left JOIN GameGenre" +
                    " ON GameGenre.IdGame = GamesTable.ID" +
                    " left JOIN GenresTable" +
                    " ON GameGenre.IdGenre = GenresTable.ID"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sqlcomm.Connection = sqlconn;
                        sqlconn.Open();
                        sda.SelectCommand = sqlcomm;

                        SqlDataReader sdr = sqlcomm.ExecuteReader();
                        while (sdr.Read())
                        {
                            GameGenre jtobj = new GameGenre();
                            jtobj.NameGame = sdr["NameGame"].ToString();
                            jtobj.NameGenres = sdr["NameGenres"].ToString();
                            jt.Add(jtobj);
                        }
                    }
                    return jt;
                }
            }
        }
    }
}
