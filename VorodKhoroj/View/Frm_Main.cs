using System.Windows.Forms;

namespace VorodKhoroj
{
    public partial class Frm_Main : Form
    {
        public OpenFileDialog OpenFile { get; set; }

        public static DataTable Data = new();

        private Structure[] array;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            toDateTime_txtbox.Text = CommonHelpers.PersianCalenderDateNow();
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
                    FillDataGrid();
                    array = DataConfiguration.Records.DistinctBy(x => x.UserId).ToArray();
                    userid_txtbox.Items.AddRange(array);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGrid()
        {
            dataView.DataSource = Data.Rows.Count == 0
                ? Data = DataConfiguration.ConvertToDataTable(DataConfiguration.Records)
                : Data;
            dataView.Columns[0].HeaderText = "کاربر";
            dataView.Columns[1].HeaderText = "تاریخ و زمان";
            dataView.Columns[2].HeaderText = "ساعت نوع ورود";

            dataView.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
        }

        private void btn_applyfilter_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count == 0) return;

            try
            {
                var Filtered = DataManager.ApplyFilter(FromDateTime_txtbox.Text, toDateTime_txtbox.Text,
                   int.Parse(userid_txtbox.Text));
                dataView.DataSource = null;
                dataView.DataSource = DataConfiguration.ConvertToDataTable(Filtered);
                dataView.Columns[1].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            FromDateTime_txtbox.Text = userid_txtbox.Text = "";
            toDateTime_txtbox.Text = CommonHelpers.PersianCalenderDateNow();
            FillDataGrid();
        }

        private void مجموعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataView.Rows.Count == 0)
            {
                MessageBox.Show("داده ای وجود ندارد");
                return;
            }
            using (FrmFilter frm = new())
            {
                frm.FromDateTime_txtbox.Text = this.FromDateTime_txtbox.Text;
                frm.toDateTime_txtbox.Text = this.toDateTime_txtbox.Text;
                frm.userid_txtbox.Items.AddRange(array);
                frm.ShowDialog();
            }
        }

        private void dataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataView.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();

        }
    }
}
