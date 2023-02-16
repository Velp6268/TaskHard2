using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHard2
{
    public class City
    {
        public City(int id, string name, double price, double transit, double nalog)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.transit = transit;
            this.nalog = nalog;
        }
        public City(int id, string name, double price, double transit)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.transit = transit;
            nalog = 1;
        }

        public override string ToString()
        {
            return $"{id} {name} {price} {transit} {nalog}";
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double transit { get; set; }
        public double nalog { get; set; }
    }
}