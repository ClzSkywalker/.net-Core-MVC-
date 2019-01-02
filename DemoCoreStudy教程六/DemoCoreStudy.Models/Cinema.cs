using System;

namespace DemoCoreStudy.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }//地址
        public int Capacity { get; set; }//容纳多少观众
    }
}
