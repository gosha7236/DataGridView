using DataGridView.Forms;
using System;
using System.Windows.Forms;
using System.Linq;
namespace DataGridView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            // загрузим данные
            StorageManager.Load();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            // привязываем к списку. Для автоматических обновлений лучше BindingList.
            dataGridView1.DataSource = StorageManager.Items.ToList(); // ToList чтобы snapshot
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = StorageManager.Items[e.RowIndex];
                var edit = new AddForm(item, e.RowIndex);
                if (edit.ShowDialog() == DialogResult.OK)
                    LoadData();
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
            var item = StorageManager.Items[index];

            var form = new AddForm(item, index);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}