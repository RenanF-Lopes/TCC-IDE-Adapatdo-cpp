namespace Virtual_Keyboard
{
    partial class FormModal
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
            modal = new Panel();
            modal_rtb = new RichTextBox();
            modal_btn_close = new Button();
            modal_btn_for = new Button();
            modal_btn_switch = new Button();
            modal_btn_if = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // modal
            // 
            modal.AutoSize = true;
            modal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            modal.BorderStyle = BorderStyle.Fixed3D;
            modal.Location = new Point(-114, 229);
            modal.Margin = new Padding(2);
            modal.Name = "modal";
            modal.Size = new Size(4, 4);
            modal.TabIndex = 6;
            modal.Visible = false;
            // 
            // modal_rtb
            // 
            modal_rtb.AcceptsTab = true;
            modal_rtb.AutoWordSelection = true;
            modal_rtb.BackColor = SystemColors.InactiveCaption;
            modal_rtb.BorderStyle = BorderStyle.None;
            modal_rtb.BulletIndent = 4;
            modal_rtb.Dock = DockStyle.Fill;
            modal_rtb.EnableAutoDragDrop = true;
            modal_rtb.Font = new Font("Fira Code Medium", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point);
            modal_rtb.ForeColor = Color.Fuchsia;
            modal_rtb.Location = new Point(2, 2);
            modal_rtb.Margin = new Padding(2);
            modal_rtb.Name = "modal_rtb";
            modal_rtb.Size = new Size(711, 450);
            modal_rtb.TabIndex = 12;
            modal_rtb.Text = "";
            // 
            // modal_btn_close
            // 
            modal_btn_close.BackColor = Color.Red;
            modal_btn_close.Dock = DockStyle.Fill;
            modal_btn_close.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            modal_btn_close.ForeColor = SystemColors.ControlLightLight;
            modal_btn_close.Location = new Point(2, 2);
            modal_btn_close.Margin = new Padding(2);
            modal_btn_close.Name = "modal_btn_close";
            modal_btn_close.Size = new Size(149, 86);
            modal_btn_close.TabIndex = 11;
            modal_btn_close.Text = "×";
            modal_btn_close.UseVisualStyleBackColor = false;
            modal_btn_close.Click += modal_btn_close_Click;
            // 
            // modal_btn_for
            // 
            modal_btn_for.BackColor = Color.DeepPink;
            modal_btn_for.Dock = DockStyle.Fill;
            modal_btn_for.FlatAppearance.BorderColor = Color.Black;
            modal_btn_for.FlatAppearance.BorderSize = 4;
            modal_btn_for.FlatStyle = FlatStyle.Flat;
            modal_btn_for.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            modal_btn_for.ForeColor = Color.White;
            modal_btn_for.Location = new Point(2, 183);
            modal_btn_for.Margin = new Padding(2, 3, 2, 3);
            modal_btn_for.Name = "modal_btn_for";
            modal_btn_for.Size = new Size(149, 84);
            modal_btn_for.TabIndex = 10;
            modal_btn_for.Text = "For";
            modal_btn_for.UseVisualStyleBackColor = false;
            modal_btn_for.Click += modal_btn_for_Click;
            // 
            // modal_btn_switch
            // 
            modal_btn_switch.BackColor = Color.DeepPink;
            modal_btn_switch.Dock = DockStyle.Fill;
            modal_btn_switch.FlatAppearance.BorderColor = Color.Black;
            modal_btn_switch.FlatAppearance.BorderSize = 4;
            modal_btn_switch.FlatStyle = FlatStyle.Flat;
            modal_btn_switch.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            modal_btn_switch.ForeColor = Color.White;
            modal_btn_switch.Location = new Point(2, 273);
            modal_btn_switch.Margin = new Padding(2, 3, 2, 3);
            modal_btn_switch.Name = "modal_btn_switch";
            modal_btn_switch.Size = new Size(149, 84);
            modal_btn_switch.TabIndex = 9;
            modal_btn_switch.Text = "Switch";
            modal_btn_switch.UseVisualStyleBackColor = false;
            modal_btn_switch.Click += modal_btn_switch_Click;
            // 
            // modal_btn_if
            // 
            modal_btn_if.BackColor = Color.DeepPink;
            modal_btn_if.Dock = DockStyle.Fill;
            modal_btn_if.FlatAppearance.BorderColor = Color.Black;
            modal_btn_if.FlatAppearance.BorderSize = 4;
            modal_btn_if.FlatStyle = FlatStyle.Flat;
            modal_btn_if.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            modal_btn_if.ForeColor = Color.White;
            modal_btn_if.Location = new Point(2, 93);
            modal_btn_if.Margin = new Padding(2, 3, 2, 3);
            modal_btn_if.Name = "modal_btn_if";
            modal_btn_if.Size = new Size(149, 84);
            modal_btn_if.TabIndex = 6;
            modal_btn_if.Text = "If...Else";
            modal_btn_if.UseVisualStyleBackColor = false;
            modal_btn_if.Click += modal_btn_if_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.525774F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(modal_rtb, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(868, 454);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(button1, 0, 4);
            tableLayoutPanel2.Controls.Add(modal_btn_for, 0, 2);
            tableLayoutPanel2.Controls.Add(modal_btn_close, 0, 0);
            tableLayoutPanel2.Controls.Add(modal_btn_if, 0, 1);
            tableLayoutPanel2.Controls.Add(modal_btn_switch, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(715, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(153, 454);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(2, 362);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(149, 90);
            button1.TabIndex = 12;
            button1.Text = "Inserir código";
            button1.UseVisualStyleBackColor = false;
            // 
            // FormModal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 454);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(modal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormModal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormModal";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel modal;
        private RichTextBox modal_rtb;
        private Button modal_btn_close;
        private Button modal_btn_for;
        private Button modal_btn_switch;
        private Button modal_btn_if;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button1;
    }
}