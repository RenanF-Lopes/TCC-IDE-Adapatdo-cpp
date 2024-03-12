namespace Virtual_Keyboard
{
    partial class BackdropCmdArea
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
            tlp_container = new TableLayoutPanel();
            tb_status = new TextBox();
            tlp_container.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_container
            // 
            tlp_container.BackColor = Color.IndianRed;
            tlp_container.ColumnCount = 1;
            tlp_container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_container.Controls.Add(tb_status, 0, 1);
            tlp_container.Dock = DockStyle.Fill;
            tlp_container.Location = new Point(0, 0);
            tlp_container.Margin = new Padding(0);
            tlp_container.Name = "tlp_container";
            tlp_container.RowCount = 3;
            tlp_container.RowStyles.Add(new RowStyle(SizeType.Percent, 40.6666679F));
            tlp_container.RowStyles.Add(new RowStyle(SizeType.Percent, 46.22222F));
            tlp_container.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tlp_container.Size = new Size(800, 450);
            tlp_container.TabIndex = 1;
            tlp_container.Paint += tableLayoutPanel1_Paint;
            // 
            // tb_status
            // 
            tb_status.BackColor = Color.IndianRed;
            tb_status.BorderStyle = BorderStyle.None;
            tb_status.Dock = DockStyle.Fill;
            tb_status.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            tb_status.ForeColor = SystemColors.Window;
            tb_status.Location = new Point(0, 182);
            tb_status.Margin = new Padding(0);
            tb_status.Multiline = true;
            tb_status.Name = "tb_status";
            tb_status.ReadOnly = true;
            tb_status.Size = new Size(800, 207);
            tb_status.TabIndex = 0;
            tb_status.Text = "NÃO COMPILADO";
            tb_status.TextAlign = HorizontalAlignment.Center;
            // 
            // BackdropCmdArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlp_container);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BackdropCmdArea";
            Text = "BackdropCmdArea";
            tlp_container.ResumeLayout(false);
            tlp_container.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlp_container;
        private TextBox tb_status;
    }
}