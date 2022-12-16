using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_POS
{
    public partial class Form4 : Form
    {
        List<string> x = new List<string>();
        List<string> y = new List<string>();
        public Form4()
        {
            InitializeComponent();
            StreamReader file = new StreamReader("인천물가정보_20210907.csv", Encoding.Default);

            DataTable table = new DataTable();

            table.Columns.Add("품 목 명");
            table.Columns.Add("조사규격(통계청 기준)");
            table.Columns.Add("전월금액(평균값)");
            table.Columns.Add("전월값(평균)");
            table.Columns.Add("금액(평균값)");
            table.Columns.Add("전월대비상승율");
            table.Columns.Add("데이터기준일자");

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();

                string[] data = line.Split(',');
                table.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);

                y.Add(data[0]);
                y.Add(data[1]);
                y.Add(data[2]);
                y.Add(data[3]);
                y.Add(data[4]);
                y.Add(data[5]);
                y.Add(data[6]);
            }
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (textBox1.Text.ToString() == (dataGridView1.Rows[i].Cells[0].Value.ToString()))
                {
                    int a = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    int b = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    string c = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    MessageBox.Show(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    chart1.Series[0].Name = "변동";
                    chart1.Series[0].Points.AddXY("전월평균", a);
                    chart1.Series[0].Points.AddXY("이달평균", b);

                    chart1.Series[0].Points[1].Color = Color.LightSeaGreen;

                    label2.Text = "전월평균: " + a;
                    label3.Text = "이달평균: " + b;
                    label1.Text = "변동치: " + c;

                    if (double.Parse(c) > 0)
                    {
                        label1.ForeColor = Color.Blue;
                    }
                    else
                    {
                        label1.ForeColor = Color.Red;
                    }
                }
            }
            textBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
