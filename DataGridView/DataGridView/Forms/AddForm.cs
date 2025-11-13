using DataGridView.Classes;

namespace DataGridView.Forms
{
    /// <summary>
    /// форма для добавления товара
    /// </summary>
    public partial class AddForm : Form
    {
        private Item _item;
        private int _editIndex = -1;
       /// <summary>
       /// конструктор для формы
       /// </summary>
        public AddForm()
        {
            InitializeComponent();
            this.Text = "Добавить товар";
        }
        /// <summary>
        /// конструктор формы с параметрами
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public AddForm(Item item, int index)
        {
            InitializeComponent();
            _item = item;
            _editIndex = index;
            this.Text = "Редактировать товар";
            FillForm();
        }

        private void FillForm()
        {
            if (_item != null)
            {
                txtName.Text = _item.Name;
                txtSize.Text = _item.Size;
                cmbMaterial.Text = _item.Material;
                Amount.Value = _item.Quantity;
                MinCount.Value = _item.MinLimit;
                txtPrice.Text = _item.Price.ToString();
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            // Доступные материалы
            cmbMaterial.Items.AddRange(new string[]
            { "Медь", "Сталь", "Железо", "Хром" });

            // Размеры
            txtSize.Items.AddRange(new string[]
            { "20 мм", "30 мм", "40 мм", "50 мм" });
        }

        private void UpdateTotal(object? sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
                txtAllPrice.Text = (price * Amount.Value).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var quantity = (int)Amount.Value;
                var price = int.Parse(txtPrice.Text);
                var total = quantity * (int)price;

                var newItem = new Item(
                    txtName.Text.Trim(),
                    txtSize.Text.Trim(),
                    cmbMaterial.Text.Trim(),
                    quantity,
                    (int)MinCount.Value,
                    price,
                    total
                );

                if (_editIndex >= 0)
                {
                    // Редактирование существующего товара
                    Storage.UpdateItem(_editIndex, newItem);
                }
                else
                {
                    // Добавление нового товара
                    Storage.AddItem(newItem);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название товара", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPrice.Text.Length <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}