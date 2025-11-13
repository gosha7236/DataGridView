using DataGridView.Classes;
using DataGridView.Forms;
using System.Drawing;

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
            RefreshTable();
            dataGridView1.CellDoubleClick += dgvItems_CellDoubleClick;
        }
        ///метод для обновления таблицы
        public void RefreshTable()
        {
            dataGridView1.Rows.Clear();

            foreach (var item in Storage.Items)
            {
                int rowIdx = dataGridView1.Rows.Add(
                    item.Name, item.Size, item.Material,
                    item.Quantity, item.MinLimit, item.Price, item.Total
                );

                // Подсветка при малом остатке
                if (item.Quantity <= item.MinLimit)
                    dataGridView1.Rows[rowIdx].DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var item = Storage.Items[e.RowIndex];
                AddForm edit = new AddForm();
                edit.ShowDialog();
                RefreshTable();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            RefreshTable();
        }
    }
}