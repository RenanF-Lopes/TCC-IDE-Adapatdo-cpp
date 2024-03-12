namespace Virtual_Keyboard
{
    partial class FormCondition
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btn_cancel = new Button();
            tb_center = new TextBox();
            tb_right = new TextBox();
            tb_left = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_save = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.DimGray;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.375F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.875F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(tb_center, 1, 1);
            tableLayoutPanel1.Controls.Add(tb_right, 2, 1);
            tableLayoutPanel1.Controls.Add(tb_left, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 41.70693F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5861359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 41.70693F));
            tableLayoutPanel1.Size = new Size(800, 211);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
            tableLayoutPanel3.Controls.Add(btn_cancel, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 65.85366F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 34.1463432F));
            tableLayoutPanel3.Size = new Size(312, 82);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Crimson;
            btn_cancel.Dock = DockStyle.Fill;
            btn_cancel.FlatStyle = FlatStyle.Popup;
            btn_cancel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancel.ForeColor = Color.WhiteSmoke;
            btn_cancel.Location = new Point(3, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(238, 48);
            btn_cancel.TabIndex = 1;
            btn_cancel.Text = "CANCELAR";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // tb_center
            // 
            tb_center.BackColor = Color.MidnightBlue;
            tb_center.Dock = DockStyle.Fill;
            tb_center.Font = new Font("Fira Code", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            tb_center.ForeColor = Color.White;
            tb_center.Location = new Point(318, 88);
            tb_center.Margin = new Padding(0);
            tb_center.Name = "tb_center";
            tb_center.Size = new Size(179, 35);
            tb_center.TabIndex = 1;
            tb_center.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_right
            // 
            tb_right.BorderStyle = BorderStyle.FixedSingle;
            tb_right.Dock = DockStyle.Fill;
            tb_right.Font = new Font("Fira Code", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            tb_right.Location = new Point(497, 88);
            tb_right.Margin = new Padding(0);
            tb_right.Name = "tb_right";
            tb_right.ReadOnly = true;
            tb_right.Size = new Size(303, 35);
            tb_right.TabIndex = 2;
            tb_right.Text = "; i++) {";
            // 
            // tb_left
            // 
            tb_left.BorderStyle = BorderStyle.FixedSingle;
            tb_left.Dock = DockStyle.Fill;
            tb_left.Font = new Font("Fira Code", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            tb_left.Location = new Point(0, 88);
            tb_left.Margin = new Padding(0);
            tb_left.Name = "tb_left";
            tb_left.ReadOnly = true;
            tb_left.Size = new Size(318, 35);
            tb_left.TabIndex = 3;
            tb_left.Text = "for (int i = 0; i <= ";
            tb_left.TextAlign = HorizontalAlignment.Right;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.6936028F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 97.3064F));
            tableLayoutPanel2.Controls.Add(btn_save, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(500, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 64.63415F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35.3658524F));
            tableLayoutPanel2.Size = new Size(297, 82);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.LimeGreen;
            btn_save.Dock = DockStyle.Fill;
            btn_save.FlatStyle = FlatStyle.Popup;
            btn_save.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_save.ForeColor = Color.WhiteSmoke;
            btn_save.Location = new Point(11, 3);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(283, 47);
            btn_save.TabIndex = 0;
            btn_save.Text = "SALVAR";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // FormCondition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 211);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FormCondition";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormCondition";
            Load += FormCondition_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btn_cancel;
        private TextBox tb_right;
        private TextBox tb_left;
        private Button btn_save;
        private TableLayoutPanel tableLayoutPanel2;
        public TextBox tb_center;
    }
}