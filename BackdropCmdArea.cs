namespace Virtual_Keyboard
{
    public partial class BackdropCmdArea : Form
    {
        private Color colorNotCompiled = Color.FromArgb(96, 180, 240);
        private Color colorCompiling = Color.FromArgb(232, 232, 104);
        private Color colorCompiled = Color.FromArgb(78, 232, 104);
        private Color colorCompileFail = Color.FromArgb(222, 22, 22);

        public BackdropCmdArea()
        {
            InitializeComponent();
            SetIsNotCompiled();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetIsNotCompiled()
        {
            tlp_container.BackColor = colorNotCompiled;
            tb_status.BackColor = colorNotCompiled;
            tb_status.Text = "Não compilado";
        }

        public void SetIsCompiling()
        {
            tlp_container.BackColor = colorCompiling;
            tb_status.BackColor = colorCompiling;
            tb_status.Text = "Compilando...";
        }

        public void SetIsCompiled()
        {
            tlp_container.BackColor = colorCompiled;
            tb_status.BackColor = colorCompiled;
            tb_status.Text = "Compilado com sucesso";
        }

        public void SetIsCompileFail()
        {
            tlp_container.BackColor = colorCompileFail;
            tb_status.BackColor = colorCompileFail;
            tb_status.Text = "Falha na compilação. Verifique seu código fonte!";
        }
    }
}
