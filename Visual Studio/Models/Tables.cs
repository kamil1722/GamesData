using System;
using System.ComponentModel.DataAnnotations;

namespace GamesData.Models
{
    //таблица GamesTable
    public class GamesTable
    {
        public int ID { get; set; }
        [Display(Name = "Name Game ")]
        public string NameGame { get; set; }
        [Display(Name = "Name Studio ")]
        public string NameStudio { get; set; }

    }
    //таблица GenresTable
    public class GenresTable
    {
        public int ID { get; set; }
        [Display(Name = "Name Genre ")]
        public string NameGenres { get; set; }

    }
    //таблица  GenresTable для контроллера
    public class JoinTables
    {
        public int ID { get; set; }
        public int IdGame { get; set; }
        public int IdGenre { get; set; }
        [Display(Name = "Name Game ")]
        public string NameGame { get; set; }
        [Display(Name = "Name Studio ")]
        public string NameStudio { get; set; }
        [Display(Name = "Name Genre ")]
        public string NameGenres { get; set; }
    }
}
