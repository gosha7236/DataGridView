namespace DataGridView.Forms
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtSize = new ComboBox();
            cmbMaterial = new ComboBox();
            Amount = new NumericUpDown();
            MinCount = new NumericUpDown();
            txtPrice = new TextBox();
            txtAllPrice = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)Amount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinCount).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(414, 65);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // txtSize
            // 
            txtSize.FormattingEnabled = true;
            txtSize.Location = new Point(414, 113);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(151, 28);
            txtSize.TabIndex = 1;
            // 
            // cmbMaterial
            // 
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(414, 154);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(151, 28);
            cmbMaterial.TabIndex = 2;
            // 
            // Amount
            // 
            Amount.Location = new Point(415, 199);
            Amount.Name = "Amount";
            Amount.Size = new Size(150, 27);
            Amount.TabIndex = 3;
            // 
            // MinCount
            // 
            MinCount.Location = new Point(415, 243);
            MinCount.Name = "MinCount";
            MinCount.Size = new Size(150, 27);
            MinCount.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(414, 288);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 5;
            // 
            // txtAllPrice
            // 
            txtAllPrice.Location = new Point(415, 342);
            txtAllPrice.Name = "txtAllPrice";
            txtAllPrice.Size = new Size(125, 27);
            txtAllPrice.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Location = new Point(352, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(128, 255, 255);
            label1.Location = new Point(240, 68);
            label1.Name = "label1";
            label1.Size = new Size(168, 20);
            label1.TabIndex = 8;
            label1.Text = "Наименование товара";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(128, 255, 255);
            label2.Location = new Point(340, 116);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 9;
            label2.Text = "Размер";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(128, 255, 255);
            label3.Location = new Point(330, 154);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 10;
            label3.Text = "Материал";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(128, 255, 255);
            label4.Location = new Point(240, 201);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 11;
            label4.Text = "Количество на складе";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(128, 255, 255);
            label5.Location = new Point(160, 245);
            label5.Name = "label5";
            label5.Size = new Size(249, 20);
            label5.TabIndex = 12;
            label5.Text = "Минимальный предел количества";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(128, 255, 255);
            label6.Location = new Point(291, 288);
            label6.Name = "label6";
            label6.Size = new Size(117, 20);
            label6.TabIndex = 13;
            label6.Text = "Цена (без НДС)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(128, 255, 255);
            label7.Location = new Point(240, 345);
            label7.Name = "label7";
            label7.Size = new Size(166, 20);
            label7.TabIndex = 14;
            label7.Text = "Общая сумма товаров";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtAllPrice);
            Controls.Add(txtPrice);
            Controls.Add(MinCount);
            Controls.Add(Amount);
            Controls.Add(cmbMaterial);
            Controls.Add(txtSize);
            Controls.Add(txtName);
            Name = "AddForm";
            Text = "AddForm";
            Load += AddForm_Load;
            ((System.ComponentModel.ISupportInitialize)Amount).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private ComboBox txtSize;
        private ComboBox cmbMaterial;
        private NumericUpDown Amount;
        private NumericUpDown MinCount;
        private TextBox txtPrice;
        private TextBox txtAllPrice;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}