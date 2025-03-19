using Serilog;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using VorodKhoroj.Classes;
using VorodKhoroj.Model;

namespace VorodKhoroj
{
    public partial class Frm_Main : Form
    {
        public OpenFileDialog OpenFile { get; set; }

        //   public string FileAddress;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void بازکردنفایلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile = new OpenFileDialog
            {
                Filter = @"Output Files|*.txt;*.dat;*"
            };
            try
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    DataConfiguration.LoadDataFromFile(OpenFile.FileName);
                    dataGridView1.DataSource = DataConfiguration.table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_applyfilter_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = DataManager.ApplyFilter(FromDateTime_txtbox.Text, toDateTime_txtbox.Text, userid_txtbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = userid_txtbox.Text = "";
            toDateTime_txtbox.Text = CommonHelpers.PersianCalenderDateNow();
            dataGridView1.DataSource = DataConfiguration.table;
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            toDateTime_txtbox.Text = CommonHelpers.PersianCalenderDateNow();
        }

    }
}
