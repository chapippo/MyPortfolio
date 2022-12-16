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

namespace Market_POS
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
            //행 생성
            DBHelper.selectQuery();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Price", typeof(string));
            table.Columns.Add("Count", typeof(string));
            table.Columns.Add("Total", typeof(string));

            dataGridView1.DataSource = table;
            numericUpDown1.Value = 1;


        }
        private void printMsg()
        {
            MessageBox.Show("버튼");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //string sqlcon = "Data Source = 192.168.0.106; Initial Catalog= DataBase; User "

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void 판매내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void 재고현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void 물가조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //행 지우기
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }

            //합계창에 수정된 값 넣기
            decimal all = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                all += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
            }

            textBox3.Text = all.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("항목을 정확히 입력해주세요");
                textBox1.Clear();
            }
            else
            {
                //합계를 구하기 위해 품목명과 가격을 정의하고 total로 합침
                //decimal price = decimal.Parse(textBox2.Text);
                decimal price = DBHelper.getPrice(textBox1.Text);
                decimal count = numericUpDown1.Value;
                decimal total = price * count;

                //text박스내의 정보를 표에 삽입
                table.Rows.Add(textBox1.Text, price, numericUpDown1.Value, total);
                dataGridView1.DataSource = table;

                //text박스의 정보 초기화
                textBox1.Clear();
                numericUpDown1.Value = 1;

                //합계
                decimal all = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    all += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                }
                textBox3.Text = all.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //각 행의 정보를 반복문으로 불러온다
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string Price = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string Count = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string Total = dataGridView1.Rows[i].Cells[3].Value.ToString();



                int nowStock = DBHelper2.NowStock(Name, Count);
                if (nowStock >= int.Parse(Count))
                {
                    DBHelper2.StockCount(Name, Count);
                }
                else
                {
                    MessageBox.Show($"{Name}의 재고가 부족합니다.");
                    dataGridView1.Rows.RemoveAt(i);
                    continue;
                }


                DBHelper.insertSales(Name, Price, Count, Total);



            }
            textBox3.Text = "0";
            MessageBox.Show("계산되었습니다.");

            //합계창 초기화
            dataGridView1.DataSource = null;

        }

        private void 점포수ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }
    }
}
