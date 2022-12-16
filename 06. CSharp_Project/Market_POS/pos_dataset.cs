using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_POS
{
    public class pos_dataset
    {
        public int no { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public DateTime c_num { get; set; }
    }
}
