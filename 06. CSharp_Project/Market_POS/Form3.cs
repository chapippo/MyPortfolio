using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Market_POS
{
    public partial class Form3 : Form
    {
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        DataTable table = new DataTable();

        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;
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

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        

        }

        //뒤로가기
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //재고 검색
        private void button2_Click(object sender, EventArgs e)
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
                    DataManager2.Load(valueToSearch);
                    dataGridView1.DataSource = DataManager2.Stock;

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message + " 조회 오류");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //추가
        private void button3_Click(object sender, EventArgs e)
        {

            string i_name = textBox3.Text.ToString();
            string i_price = textBox4.Text.ToString();
            string i_count = textBox5.Text.ToString();
            DBHelper2.insertStock( i_name, i_price, i_count);
            MessageBox.Show($"{i_name}이 추가되었습니다!!!!!!");

            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        //수정
        private void button4_Click(object sender, EventArgs e)
        {
            string no = textBox2.Text.ToString();
            string i_name = textBox3.Text.ToString();
            string i_price = textBox4.Text.ToString();
            string i_count = textBox5.Text.ToString();
            DBHelper2.modifyStock(no, i_name, i_price, i_count);

            MessageBox.Show($"코드:{no} 상품명:{i_name}이 수정되었습니다!!!!!!");

            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


        }

        //삭제
        private void button5_Click(object sender, EventArgs e)
        {
            string no = textBox2.Text;
            DBHelper2.deleteStock(no);
            MessageBox.Show($"{no}이 삭제되었습니다.....");
            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;
        }

        //새로고침
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;

            try
            {
                textBox2.Text = DataManager2.Stock[0].no.ToString();
                textBox3.Text = DataManager2.Stock[0].i_name.ToString();
                textBox4.Text = DataManager2.Stock[0].i_price.ToString();
                textBox5.Text = DataManager2.Stock[0].i_count.ToString();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            if (DataManager2.Stock.Count > 0)
            {
                dataGridView1.DataSource = DataManager2.Stock;
            }
        }

        //+&&&
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pos_stock Stock =
              dataGridView1.CurrentRow.DataBoundItem as pos_stock;

            textBox2.Text = Stock.no.ToString();
            textBox3.Text = Stock.i_name.ToString();
            textBox4.Text = Stock.i_price.ToString();
            textBox5.Text = Stock.i_count.ToString();

        }

    }
}
