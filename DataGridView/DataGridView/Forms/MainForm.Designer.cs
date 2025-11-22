

namespace DataGridView
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel1 = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            label1 = new Label();
            Name = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            MinCount = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            AllPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Name, Size, Material, Amount, MinCount, Price, AllPrice });
            dataGridView1.Location = new Point(0, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(971, 495);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(971, 125);
            panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(241, 91);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(112, 91);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(123, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 91);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(336, 40);
            label1.Name = "label1";
            label1.Size = new Size(272, 39);
            label1.TabIndex = 0;
            label1.Text = "Просмотр товаров";
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Название";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 125;
            // 
            // Size
            // 
            Size.DataPropertyName = "Size";
            Size.HeaderText = "Размер";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.Width = 125;
            // 
            // Material
            // 
            Material.DataPropertyName = "Material";
            Material.HeaderText = "Материал";
            Material.MinimumWidth = 6;
            Material.Name = "Material";
            Material.Width = 125;
            // 
            // Amount
            // 
            Amount.DataPropertyName = "Amount";
            Amount.HeaderText = "Количество";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.Width = 125;
            // 
            // MinCount
            // 
            MinCount.DataPropertyName = "MinCount";
            MinCount.HeaderText = "Мин.количество";
            MinCount.MinimumWidth = 6;
            MinCount.Name = "MinCount";
            MinCount.Width = 125;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Цена";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.Width = 125;
            // 
            // AllPrice
            // 
            AllPrice.DataPropertyName = "AllPrice";
            AllPrice.HeaderText = "Общая цена";
            AllPrice.MinimumWidth = 6;
            AllPrice.Name = "AllPrice";
            AllPrice.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 621);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Panel panel1;
        private Label label1;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn MinCount;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn AllPrice;
    }
}
