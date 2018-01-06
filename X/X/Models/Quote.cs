using SQLite;
using System;
using X.Interfaces;

namespace X.Models
{

    [Table("quotes")]
    public class Quote : IDataItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public string Author { get; set; }
    }
}
