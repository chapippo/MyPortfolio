using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using System.Collections;

namespace Market_POS
{
    public partial class Form2 : Form
    {
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        DataTable table = new DataTable();
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            DataManager.Load();
            dataGridView1.DataSource = DataManager.Sales;

        }



        public void LoadData()
        {
            string connect = string.Format("Data Source={0};" +
              "Initial Catalog = {1};" +
              "Persist Security Info = True;" +
              "User ID=us;Password=1234",
              "192.168.0.106,1433", "MarketPos");
            conn = new SqlConnection(connect);

            try
            {
                conn.Open(); //db 연결

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

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }


    


        //검색
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("검색 정보를 입력해주세요");
            }
            else
            {
                try
                {
                    string valueToSearch = textBox1.Text;
                    MessageBox.Show($"{textBox1.Text}을 조회합니다.....");
                    dataGridView1.DataSource = null;
                    DataManager.Load(valueToSearch);
                    dataGridView1.DataSource = DataManager.Sales;

                }

                catch (Exception er)
                { MessageBox.Show(er.Message + " 조회 오류");  }

                finally
                { conn.Close();}
            }
        }


        //삭제
        private void button3_Click(object sender, EventArgs e)
        {
            string no = textBox2.Text;
            DBHelper.deleteSales(no);
            MessageBox.Show($"{no}이 삭제되었습니다.....");
            dataGridView1.DataSource = null;
            DataManager.Load();
            dataGridView1.DataSource = DataManager.Sales;
        }

        
        //새로고침
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataManager.Load();
            dataGridView1.DataSource = DataManager.Sales;

            try
            {
                //+"" 하든지 .ToString() 하기
                textBox2.Text = DataManager.Sales[0].no.ToString();
                textBox3.Text = DataManager.Sales[0].name.ToString();
                textBox4.Text = DataManager.Sales[0].count.ToString();
                textBox5.Text = DataManager.Sales[0].price.ToString();
                textBox6.Text = DataManager.Sales[0].total.ToString();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            if (DataManager.Sales.Count > 0)
            {
                dataGridView1.DataSource = DataManager.Sales;
            }
        }
      

        //수정하기
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("항목을 정확히 입력해주세요");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                int price = int.Parse(textBox5.Text);
                int count = int.Parse(textBox4.Text);
                int total = price * count;

                textBox5.Text = total.ToString();

                try
                {
                    string no = textBox2.Text.ToString();
                    string name = textBox3.Text.ToString();

                    DBHelper.modifySales(no, name, price, count, total);
                    MessageBox.Show($"{no} 상품이 수정되었습니다");

                    dataGridView1.DataSource = null;
                    DataManager.Load();
                    dataGridView1.DataSource = DataManager.Sales;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"  수정오류");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //종료
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //셀클릭
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            pos_dataset Sales =
            dataGridView1.CurrentRow.DataBoundItem as pos_dataset;

            textBox2.Text = Sales.no.ToString();
            textBox3.Text = Sales.name.ToString();
            textBox4.Text = Sales.count.ToString();
            textBox5.Text = Sales.price.ToString();
            textBox6.Text = Sales.total.ToString();
        }
    }
}
