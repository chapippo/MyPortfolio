using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_POS
{
    public class DBHelper2
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
                cmd.CommandText = "select * from stock_tb;";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "stock_tb");
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "stock");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "stock");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }

        //재고 추가
        public static void insertStock(string name, string price, string count)
        {
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = string.Format("INSERT INTO stock_tb(i_name,i_price,i_count) VALUES  ('{0}',{1},{2})", @name, @price, @count);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "stock error");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "stock error");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }

        //재고 내용 수정
        public static void modifyStock(string no, string name, string price, string count)
        {
            try
            {
                ConnectDB();



                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format(" UPDATE[MarketPos].[dbo].[stock_tb] SET i_name = '{1}', i_price = {2}, i_count = {3} " +
                  "WHERE no = {0};", @no, @name, @price, @count);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "modify error");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "modify error");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }


        //재고 삭제
        public static void deleteStock(string no)
        {
            try
            {
                ConnectDB();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format("DELETE  From [MarketPos].[dbo].[stock_tb] WHERE no = {0};", @no);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message + "   stock  delete");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "   stock  delete");
                return;
            }

            finally
            {
                conn.Close(); //db 연결 해제
            }
        }

        //재고검색조회
        public static void searchStock(string valueToSearch)
        {

            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = string.Format("SELECT* FROM[MarketPos].[dbo].[stock_tb] WHERE i_name ='{0}';", @valueToSearch);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "stock_tb");
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

        public static int NowStock(string name, string count)
        {
            int now_stock = 0;
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format("select i_count from [MarketPos].[dbo].[stock_tb] where i_name = '{0}';", @name);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "stock_tb");
                dt = ds.Tables[0];


                foreach (DataRow item in DBHelper2.dt.Rows)
                {
                    now_stock = int.Parse(item["i_count"].ToString());
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("stock오류");
            }
            finally
            {
                conn.Close();
            }
            return now_stock;
        }

        //구매시 재고수량 빼기
        public static void StockCount(string name, string count)
        {
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format("UPDATE[MarketPos].[dbo].[stock_tb] SET i_count =i_count - {1} WHERE i_name='{0}'; ", @name,@count);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("stock오류");
            }
            finally
            {
                conn.Close(); 
            }
        }

    }
}
