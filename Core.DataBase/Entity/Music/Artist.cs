using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DataBase.Entity
{
    public class Artist
    {
        [Column("id_Artist")]
        public int id_artist { get; set; }

        [Column("ds_Name")]
        public string ds_name { get; set; }

        [Column("dt_Create")]
        public DateTime dt_create { get; set; }

        [Column("dt_Modified")]
        public DateTime? dt_modified { get; set; }
    }
}
