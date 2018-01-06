using System;

namespace X.Interfaces
{
    public interface IDataItem
    {
        int Id { get; set; }
        string Body { get; set; }
        DateTime InsertDate { get; set; }
        string Author { get; set; }
    }
}
