using DataGridView.Classes;

namespace DataGridView.Forms
{
    /// <summary>
    /// форма для добавления товара
    /// </summary>
    public partial class AddForm : Form
    {
        private readonly int _editIndex = -1;
        private readonly ErrorProvider _error = new ErrorProvider();
        private Item _item;
        /// <summary>
        /// конструктор для формы
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            InitComboBoxes();
            _item = new Item();
        }
        /// <summary>
        /// конструктор формы с параметрами
        /// </summary>
        /// значение
        /// <param name="item"></param>
        /// индекс
        /// <param name="index"></param>
        public AddForm(Item item, int index)
        {
            InitializeComponent();
            InitComboBoxes();

            _editIndex = index;
            _item = item.Clone();

            txtName.Text = _item.Name;
            txtSize.Text = _item.Size;
            cmbMaterial.Text = _item.Material;
            Amount.Value = _item.Amount;
            MinCount.Value = _item.minCount;
            txtPrice.Text = _item.Price.ToString();
            txtAllPrice.Text = _item.Total.ToString("0.00");
        }

        private void InitComboBoxes()
        {
            txtSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool ValidateForm()
        {
            _error.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                _error.SetError(txtName, "Название обязательно!");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                _error.SetError(txtSize, "Выберите размер!");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(cmbMaterial.Text))
            {
                _error.SetError(cmbMaterial, "Выберите материал!");
                ok = false;
            }

            if (Amount.Value <= 0)
            {
                _error.SetError(Amount, "Количество должно быть больше 0!");
                ok = false;
            }

            if (int.Parse(txtPrice.Text) <= 0)
            {
                _error.SetError(txtPrice, "Цена должна быть больше 0!");
                ok = false;
            }

            return ok;
        }

        private void UpdateTotal()
        {
            decimal total = Amount.Value * int.Parse(txtPrice.Text);
            txtAllPrice.Text = total.ToString("0.00");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Amount_ValueChanged(object sender, EventArgs e) => UpdateTotal();

       private void txtPrice_TextChanged(object sender, EventArgs e) => UpdateTotal();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            _item.Name = txtName.Text.Trim();
            _item.Size = txtSize.Text;
            _item.Material = cmbMaterial.Text;
            _item.Amount = (int)Amount.Value;
            _item.minCount = (int)MinCount.Value;
            _item.Price = int.Parse(txtPrice.Text);

            if (_editIndex == -1)
            {
                Storage.AddItem(_item);
            }
            else
            {
                Storage.UpdateItem(_editIndex, _item);
            }

            DialogResult = DialogResult.OK;
            UpdateTotal();
        }
    }
    }
