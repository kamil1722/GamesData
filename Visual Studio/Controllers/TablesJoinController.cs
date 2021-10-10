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
            ViewData["Results"] = TablesColumnsDisplay();
            return View();
        }

        public static List<JoinTables> TablesColumnsDisplay()
        {
            List<JoinTables> jt = new List<JoinTables>();
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
                            JoinTables jtobj = new JoinTables();
                            jtobj.NameGame = sdr["NameGame"].ToString();
                            jtobj.NameStudio = sdr["NameStudio"].ToString();
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
