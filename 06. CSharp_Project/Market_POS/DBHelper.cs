using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;

namespace Market_POS
{
    public class DBHelper
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;


        //DB연결
        public static void ConnectDB()
        {//접속해주는 함수
            try
            {
                string connect = string.Format("Data Source={0};" +
                "Initial Catalog = {1};" +
                "Persist Security Info = True;" +
                "User ID=us;Password=1234",
                "192.168.0.106,1433", "MarketPos");
                conn = new SqlConnection(connect);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connect Fail");
            }
        }

        //데이터 선택
        public static void selectQuery()
        {
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = "select * from sales_tb;";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "sales_tb");
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "select");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "select");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }

        //데이터 추가
        public static void insertSales(string name, string price, string count, string total)
        {
            
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = string.Format("INSERT INTO sales_tb(name,price,count,total,c_num) VALUES  ('{0}',{1},{2},{3},GETDATE())", @name, @price, @count, @total);
                cmd.ExecuteNonQuery();
             
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "insert");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "insert");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }


        //데이터 삭제
        public static void deleteSales(string no)
        {
            try
            {
                ConnectDB();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format("DELETE  From [MarketPos].[dbo].[sales_tb] WHERE no = {0};", @no);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "delete");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "delete");
                return;
            }

            finally
            {
                conn.Close(); //db 연결 해제
            }
        }

        //데이터 수정
        public static void modifySales(string no, string name, int price, int count, int total)
        {
            try
            {
                ConnectDB();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format(" UPDATE[MarketPos].[dbo].[sales_tb] SET name = '{1}', price = {2}, count = {3}, total = {4} " +
                    "WHERE no = {0};", @no, @name, @price, @count, total);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "modify");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "modify");
            }
            finally
            {
                conn.Close();
            }
        }
        //데이터 조회
        public static void searchData(string valueToSearch)
        {

            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = string.Format("SELECT* FROM[MarketPos].[dbo].[sales_tb] WHERE CONCAT(name, price, count, total) LIKE '%" + valueToSearch + "%';");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "sales_tb");
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("오류");
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }



        }

        public static int getPrice(string valueToSearch)
        {
            int price = 0;
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = string.Format("SELECT i_price FROM[MarketPos].[dbo].[stock_tb] WHERE i_name = '" + valueToSearch + "';");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "sales_tb");
                dt = ds.Tables[0];

                foreach (DataRow item in DBHelper.dt.Rows)
                {
                    price = int.Parse(item[0].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("오류");
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
            return price;
        }
    }
}
