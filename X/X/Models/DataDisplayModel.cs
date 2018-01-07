using System;

namespace X.Models
{
    public class DataDisplayModel
    {
        public int Id { get; set; }
        public DataType DataType { get; set; }
        public string Body { get; set; }
        public DateTime InsertDate { get; set; }
        public string BgColor { get; set; }
        public string TextColor { get; set; }
        public string Author { get; set; }

    }

    public enum DataType
    {
        Joke,
        Quote
    }
}
