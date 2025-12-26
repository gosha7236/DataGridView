using DataGridView.Forms;
using Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IStorageManager storageManager;
        private readonly BindingSource bindingSource = new();

        public MainForm(IStorageManager storageManager)
        {
            InitializeComponent();
            this.storageManager = storageManager;

            // Настройка DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;

            // Подписка на события
            Shown += MainForm_Shown;
        }

        private async void MainForm_Shown(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            UseWaitCursor = true;
            try
            {
                var items = await storageManager.GetAllAsync();
                // Оборачиваем в BindingList для поддержки уведомлений (опционально, но удобно)
                bindingSource.DataSource = new BindingList<Item>(items.ToList());
                UpdateStatus(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        // Обновление статуса (без перезагрузки данных)
        private void UpdateStatus(IReadOnlyCollection<Item> items)
        {
            int positionsCount = items.Count;
            int totalAmount = items.Sum(i => i.Amount);
            decimal totalWithoutVat = items.Sum(i => i.Total);
            decimal totalWithVat = totalWithoutVat * 1.20m;

            lblItemsCount.Text = $"Позиций: {positionsCount}, Всего шт: {totalAmount}";
            lblTotalWithoutVat.Text = $"Без НДС: {totalWithoutVat:0.00} ₽";
            lblTotalWithVat.Text = $"С НДС (20%): {totalWithVat:0.00} ₽";
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Item item)
            {
                using var editForm = new AddForm(item);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await storageManager.UpdateItemAsync(editForm._item);
                    await LoadDataAsync(); // или обновить локально через BindingList
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await storageManager.AddItemAsync(form._item);
                await LoadDataAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            if (dataGridView1.SelectedRows[0].DataBoundItem is Item item)
            {
                using var editForm = new AddForm(item);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    await storageManager.UpdateItemAsync(editForm._item);
                    await LoadDataAsync();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            if (dataGridView1.SelectedRows[0].DataBoundItem is Item item)
            {
                var result = MessageBox.Show(
                    "Вы уверены, что хотите удалить эту запись?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await storageManager.RemoveItemAsync(item.Id);
                    await LoadDataAsync();
                }
            }
        }

        // Следующие обработчики оставлены пустыми (можно удалить, если не используются)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
    }
}