using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_POS
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();


            DataTable table = new DataTable();
            table.Columns.Add("점포명");
            table.Columns.Add("2019");
            table.Columns.Add("2020");
            table.Columns.Add("2021");
            table.Columns.Add("2022");


            table.Rows.Add("CU",90,200,300,400);
            table.Rows.Add("GS25",16,140,565, 723);
            table.Rows.Add("세븐일레븐",17,46,210,330);
            table.Rows.Add("이마트24",85,113, 1050, 1330);


            dataGridView1.DataSource = table;
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //데이터 누적방지
            chart1.Series[0].Points.Clear();

            //2019
            int a = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            //2020
            int b = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //2021
            int c = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            //2022
            int d = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            chart1.Series[0].Points.AddXY(2019, a);
            chart1.Series[0].Points.AddXY(2020, b);
            chart1.Series[0].Points.AddXY(2021, c);
            chart1.Series[0].Points.AddXY(2022, d);

            chart1.Series[0].Name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " \n점포 수";



            //데이터 누적방지
            chart2.Series[0].Points.Clear();
            int rPos = dataGridView1.CurrentCell.ColumnIndex;
            int CU = int.Parse(dataGridView1.Rows[0].Cells[rPos].Value.ToString());
            int GS25 = int.Parse(dataGridView1.Rows[1].Cells[rPos].Value.ToString());
            int 세븐일레븐 = int.Parse(dataGridView1.Rows[2].Cells[rPos].Value.ToString());
            int 이마트24 = int.Parse(dataGridView1.Rows[3].Cells[rPos].Value.ToString());

            double sum = CU + GS25 + 세븐일레븐 + 이마트24;
            double cu = Math.Truncate ( CU / sum * 100.00) ;
            double gs25 = Math.Truncate (GS25 / sum * 100.00) ;
            double seven = Math.Truncate (세븐일레븐 / sum * 100.00) ;
            double emart = Math.Truncate (이마트24 / sum * 100.00);
            chart2.Series[0].Points.AddXY($"CU\n{cu}%", CU);
            chart2.Series[0].Points.AddXY($"GS25\n{gs25}%", GS25);
            chart2.Series[0].Points.AddXY($"세븐일레븐\n{seven}%", 세븐일레븐);
            chart2.Series[0].Points.AddXY($"이마트24\n{emart}%", 이마트24);

     



        }
    }
}
