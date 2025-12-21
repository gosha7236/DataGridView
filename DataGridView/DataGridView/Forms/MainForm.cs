using DataGridView.Forms;
using Entities;
using Services;
using Services.Contracts;
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
        private IStorageManager storageManager;
        private readonly BindingSource bindingSource = [];
        
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public MainForm(IStorageManager storageManager)
        {
            InitializeComponent();
            this.storageManager = storageManager;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            LoadData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // данные загружаем ТОЛЬКО в runtime
        }

        private void LoadData()
        {
            var items = storageManager.GetAll();
            bindingSource.DataSource = items.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Item item)
            {
                using var edit = new AddForm(item);

                if (edit.ShowDialog() == DialogResult.OK)
                    LoadData();
                storageManager.UpdateItem(edit._item);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
                storageManager.AddItem(form._item);
            OnUpdate();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            if (dataGridView1.SelectedRows[0].DataBoundItem is Item item)
            {
                using var edit = new AddForm(item);

                if (edit.ShowDialog() == DialogResult.OK)
                    storageManager.UpdateItem(edit._item);
                OnUpdate();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            if (dataGridView1.SelectedRows[0].DataBoundItem is Item item)
            {
                storageManager.RemoveItem(item.Id);
            }
            OnUpdate();
        }
        
        private void OnUpdate()
        {
            var items = storageManager.GetAll();
            bindingSource.DataSource = items.ToList();
            bindingSource.ResetBindings(false);
        }
    }
}