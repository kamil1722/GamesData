using System;
using System.ComponentModel.DataAnnotations;


namespace GamesData.Models
{
    //таблица GamesTable
    public class GamesTable
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name Game")]
        [StringLength(50)]
        public string NameGame { get; set; }

        [Required]
        [Display(Name = "Name Studio ")]
        [StringLength(50)]
        public string NameStudio { get; set; }

        [Display(Name = "Relize Date ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RelizeDate { get; set; }

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

        [Display(Name = "Name Game ")]
        public string NameGame { get; set; }

        [Display(Name = "Name Studio ")]
        public string NameStudio { get; set; }

        [Display(Name = "Name Genre ")]
        public string NameGenres { get; set; }
    }
}