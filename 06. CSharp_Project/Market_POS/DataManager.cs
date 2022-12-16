using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_POS
{
    public class DataManager
    {
        public static List<pos_dataset> Sales = new List<pos_dataset>();
        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                DBHelper.selectQuery();
                Sales.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    pos_dataset pos = new pos_dataset();
                    pos.no = int.Parse(item["no"].ToString());
                    pos.name = (item["name"].ToString());
                    pos.price = int.Parse(item["price"].ToString());
                    pos.count = int.Parse(item["count"].ToString());
                    pos.total = int.Parse(item["total"].ToString());
                    pos.c_num = DateTime.Parse(item["c_num"].ToString());
                    Sales.Add(pos);
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "load");
            }
        }

        public static void Load(string valueToSearch)
        {
            try
            {
                DBHelper.searchData(valueToSearch);
                Sales.Clear();
                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    pos_dataset pos = new pos_dataset();
                    pos.no = int.Parse(item["no"].ToString());
                    pos.name = (item["name"].ToString());
                    pos.price = int.Parse(item["price"].ToString());
                    pos.count = int.Parse(item["count"].ToString());
                    pos.total = int.Parse(item["total"].ToString());
                    //   pos.c_cum = int.Parse(item[" c_cum"].ToString());
                    Sales.Add(pos);
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "load");
            }
        }
    }

}
