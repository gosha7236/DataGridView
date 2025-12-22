using Entities;
using Services;
using Services.Contracts;
using System;
using System.Windows.Forms;

namespace DataGridView.Forms
{
    /// <summary>
    /// форма для добавления значения
    /// </summary>
    public partial class AddForm : Form
    {
        private readonly ErrorProvider _error = new ErrorProvider();
        public Item _item;
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            InitComboBoxes();
            _item = new Item();
        }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>

        public AddForm(Item item)
        {
            InitializeComponent();
            InitComboBoxes();

            _item = item;

            txtName.Text = _item.Name;
            txtSize.Text = _item.Size;
            cmbMaterial.Text = _item.Material;
            Amount.Value = _item.Amount;
            MinCount.Value = _item.MinCount;
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

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                _error.SetError(txtPrice, "Цена должна быть положительным числом!");
                ok = false;
            }

            return ok;
        }

        private void UpdateTotal()
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                decimal total = Amount.Value * price;
                txtAllPrice.Text = total.ToString("0.00");
            }
            else
            {
                txtAllPrice.Text = "0.00";
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            cmbMaterial.Items.AddRange(new string[] { "Медь", "Сталь", "Железо", "Хром" });
            txtSize.Items.AddRange(new string[] { "20 мм", "30 мм", "40 мм", "50 мм" });
        }

        private void UpdateTotal(object? sender, EventArgs e)
        {
            UpdateTotal();
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
            _item.MinCount = (int)MinCount.Value;

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
                price = 0;
            _item.Price = price;
            DialogResult = DialogResult.OK;
            UpdateTotal();
            this.Close();
        }
    }
}