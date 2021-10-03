using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace NestedJsonTestPomelo
{
    public class Blog
    {
        public string BlogId { get; set; }

        public DateTime InsertionTime { get; set; }
    }
}