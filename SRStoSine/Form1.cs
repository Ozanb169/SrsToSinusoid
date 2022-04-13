using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
namespace SRStoSine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double asrs = Convert.ToDouble(textBox1.Text);
            double vsrs = Convert.ToDouble(textBox2.Text); 
            double dsrs = Convert.ToDouble(textBox3.Text);
            double a2 = (asrs * 0.5);
            double v1 = (2 * vsrs / 3);
            double v2 = v1;
            double t1 = (((Math.PI)*v1)/(2*a2));
            double t2 = ((2*dsrs*(0.001)/v1)-t1);
            double a4 = (-(Math.PI) * v1 / (2 * t2));
            dataGridView1.Columns.Add("Time[s]","Time[s]");
            dataGridView1.Columns.Add("Acceleration [m/s2]", "Acceleration [m/s2]");

            textBox4.Text = String.Format("{0:N4}", (a2)); 
            textBox5.Text = String.Format("{0:N4}", (v1)); 
            textBox6.Text = String.Format("{0:N4}", (v2)); 
            textBox7.Text = String.Format("{0:N4}", (t1));
            textBox8.Text = String.Format("{0:N4}", (t2)); 
            textBox9.Text = String.Format("{0:N4}", (a4));

            int time_data_length = 500;
            double time_data_start = (0.0001);
            double[] time_data = new double[time_data_length];
            chart1.Series.Add("a");

            for (int i=0; i<time_data_length; i++)
            {
                time_data[i] = (time_data_start + (i * 0.0001));
            }

            double[] acceleration_data = new double[time_data_length];
            for (int i = 0; i < time_data_length; i++)
            {
                if (time_data[i]<=t1)
                {
                    acceleration_data[i] = (a2 * Math.Sin(((Math.PI) / t1)*time_data[i]));
                }
                else if (time_data[i] <= (t1 + t2))
                {
                    acceleration_data[i] = (a4 * Math.Sin(((Math.PI) / t2) * (time_data[i] - t1)));
                }
                else
                {
                    acceleration_data[i] = 0;
                }
                dataGridView1.Rows.Add(new object[] { time_data[i], acceleration_data[i] });
                chart1.Series[0].Points.AddXY(time_data[i], acceleration_data[i]);
            }
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}