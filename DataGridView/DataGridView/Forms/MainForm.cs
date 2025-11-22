using DataGridView.Forms;
using System;
using System.Windows.Forms;

namespace DataGridView
{
    /// <summary>
    /// класс основной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// конструктор класса
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Storage.Items;
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = Storage.Items[e.RowIndex];
                var edit = new AddForm();
                edit.ShowDialog();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            var item = Storage.Items[index];

            var form = new AddForm(item, index);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            Storage.RemoveItem(index);
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}