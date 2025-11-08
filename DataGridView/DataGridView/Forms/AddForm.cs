using DataGridView.Classes;

namespace DataGridView.Forms
{
    public partial class AddForm : Form
    {
        private Item editingItem = null;

        public AddForm(Item? item = null)
        {
            InitializeComponent();
            editingItem = item;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            // Доступные материалы
            cmbMaterial.Items.AddRange(new string[]
            { "Медь", "Сталь", "Железо", "Хром" });

            // Размеры
            txtSize.Items.AddRange(new string[]
            { "20 мм", "30 мм", "40 мм", "50 мм" });

            if (editingItem != null) LoadItemData();

            Amount.ValueChanged += UpdateTotal;
            txtPrice.TextChanged += UpdateTotal;
        }

        private void LoadItemData()
        {
            txtName.Text = editingItem.Name;
            txtSize.Text = editingItem.Size;
            cmbMaterial.Text = editingItem.Material;
            Amount.Value = editingItem.Quantity;
            MinCount.Value = editingItem.MinLimit;
            txtPrice.Text = editingItem.Price.ToString();
            txtAllPrice.Text = editingItem.Total.ToString();
        }

        private void UpdateTotal(object? sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
                txtAllPrice.Text = (price * Amount.Value).ToString();
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Неверный формат цены!");
                return;
            }

            if (editingItem == null)
            {
                // Создание нового товара
                Item item = new Item()
                {
                    Name = txtName.Text,
                    Size = txtSize.Text,
                    Material = cmbMaterial.Text,
                    Quantity = (int)Amount.Value,
                    MinLimit = (int)MinCount.Value,
                    Price = price
                };
                Storage.Items.Add(item);
            }
            else
            {
                // Обновление
                editingItem.Name = txtName.Text;
                editingItem.Size = txtSize.Text;
                editingItem.Material = cmbMaterial.Text;
                editingItem.Quantity = (int)Amount.Value;
                editingItem.MinLimit = (int)MinCount.Value;
                editingItem.Price = price;
            }

            this.Close();
        }
    }
}