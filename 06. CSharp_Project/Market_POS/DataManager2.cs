using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Market_POS
{
    public class DataManager2
    {
        public static List<pos_stock> Stock = new List<pos_stock>();
        static DataManager2()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                DBHelper2.selectQuery();
                Stock.Clear();
                foreach (DataRow item in DBHelper2.dt.Rows)
                {
                    pos_stock st = new pos_stock();
                    st.no = int.Parse(item["no"].ToString());
                    st.i_name = (item["i_name"].ToString());
                    st.i_price = int.Parse(item["i_price"].ToString());
                    st.i_count = int.Parse(item["i_count"].ToString());
                    Stock.Add(st);
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
                DBHelper2.searchStock(valueToSearch);
                Stock.Clear();
                foreach (DataRow item in DBHelper2.dt.Rows)
                {
                    pos_stock st = new pos_stock();
                    st.no = int.Parse(item["no"].ToString());
                    st.i_name = (item["i_name"].ToString());
                    st.i_price = int.Parse(item["i_price"].ToString());
                    st.i_count = int.Parse(item["i_count"].ToString());
                    Stock.Add(st);
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "load");
            }
        }
    }
}
