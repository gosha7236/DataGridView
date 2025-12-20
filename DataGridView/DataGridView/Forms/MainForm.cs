using DataGridView.Forms;
using Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DataGridView
{
    /// <summary>
    /// главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // данные загружаем ТОЛЬКО в runtime
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = StorageManager.Items.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var item = StorageManager.Items[e.RowIndex];
            using var edit = new AddForm(item, e.RowIndex);

            if (edit.ShowDialog() == DialogResult.OK)
                LoadData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            var item = StorageManager.Items[index];

            using var form = new AddForm(item, index);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            StorageManager.RemoveItem(index);
            LoadData();
        }
    }
}