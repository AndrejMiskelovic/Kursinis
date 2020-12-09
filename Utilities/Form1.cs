using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public partial class Form1 : Form
    {
        List<Utility> Utilities = new List<Utility>();
        public Form1()
        {
            InitializeComponent();
            DBConnection dBConnection = new DBConnection();           
            dBConnection.Contries(Utilities);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
           
            if(comboBox1.SelectedItem == "NaiveB")
            {
                NaiveB();
            }
            else if (comboBox1.SelectedItem == "KNN")
            {
                KNN();
            }
            else if (comboBox1.SelectedItem == "Simple")
            {
                SimpleA();
            }
        }
        private void SimpleA()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SimpleAp test = new SimpleAp();
            List<Utility> Results = test.SimpleApproachAlgorithm((float)(numericUpDown1.Value), (float)(numericUpDown2.Value), (float)(numericUpDown3.Value), (float)(numericUpDown5.Value));
            foreach (var item in Results)
            {
                lbResults.Items.Add(item.country + " | Water: " + item.water_m3 + " | Gas: " + item.gas_kWh + " | Electricity: " + item.electricity_kWh + " | Average: " + item.average);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label1.Text = "Execution time: " + elapsedMs.ToString() + " ms";
        }
        private void NaiveB()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            NaiveB test = new NaiveB();
            List<Utility> Results = test.NaiveBAlgorithm((float)(numericUpDown1.Value), (float)(numericUpDown2.Value), (float)(numericUpDown3.Value), (float)(numericUpDown5.Value));
            foreach (var item in Results)
            {
                lbResults.Items.Add(item.country + " | Water: " + item.water_m3 + " | Gas: " + item.gas_kWh + " | Electricity: " + item.electricity_kWh + " | Average: " + item.average);

            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label1.Text = "Execution time: " + elapsedMs.ToString() + " ms";
        }
        private void KNN()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            KNN kNN = new KNN();
            List<KNNSubUtility> result = kNN.KNNAlgorithm((float)(numericUpDown1.Value), (float)(numericUpDown2.Value), (float)(numericUpDown3.Value), (float)(numericUpDown5.Value));
            for (int i = 0; i < result.Count; i++)
            {
                lbResults.Items.Add(result[i].country + " | Water: " + result[i].water_m3 + " | Gas: " + result[i].gas_kWh + " | Electricity: " + result[i].electricity_kWh + " | Average: " + result[i].average + " | KNN: " + result[i].KNN.ToString("0.###"));
                
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            label1.Text = "Execution time: " + elapsedMs.ToString() + " ms";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
