namespace Virtual_Keyboard
{
    public partial class FormCondition : Form
    {
        string closeMode;
        public FormCondition(string txtLeft, string txtRigh)
        {
            InitializeComponent();
            SetLeftText(txtLeft);
            SetRightText(txtRigh);
            tb_center.Focus();
        }

        private void FormCondition_Load(object sender, EventArgs e)
        {

        }

        public string RichTextBoxText
        {
            get
            {
                string txt1 = tb_left.Text;
                string txt2 = tb_center.Text;
                string txt3 = tb_right.Text;
                return txt1 + txt2 + txt3;
            }
        }

        public string CloseMode
        {
            get
            {
                return closeMode;
            }

            set
            {
                closeMode = value;
            }
        }

        public void ClearAll()
        {
            tb_center.Clear();
        }

        public void FocusInputArea()
        {
            tb_center.Focus();
        }

        public void CloseModal()
        {
            this.DialogResult = DialogResult.Cancel;
            this.CloseMode = "cancel";
            this.Close();
        }

        public void SaveModal()
        {
            this.DialogResult = DialogResult.OK;
            this.CloseMode = "save";
            this.Close();
        }

        private void SetLeftText(string text)
        {
            tb_left.Text = text;
        }

        private void SetRightText(string text)
        {
            tb_right.Text = text;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveModal();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            CloseModal();
        }

        private void FormCondition_FormClosed(object sender, FormClosedEventArgs e)
        {
            tb_center.Text = string.Empty;
        }
    }
}
