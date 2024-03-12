using System.Diagnostics;
using WindowsInput;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;
using Mini_IDE_CPP.Utils;

namespace Virtual_Keyboard
{
    public partial class Form1 : Form
    {
        Control controlFocus;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;
        private Color COLOR_RESERVED_WORDS = Color.HotPink;
        private Color COLOR_METHOD_WORDS = Color.FromArgb(6, 189, 42);
        private Color COLOR_WRAPPERS_WORDS = Color.Orange;
        private Color COLOR_CONST_WORDS = Color.FromArgb(110, 110, 240);
        private Color COLOR_COMMADOT_WORDS = Color.FromArgb(66, 220, 255);
        private Color COLOR_STRINGS_WORDS = Color.FromArgb(240, 240, 110);
        private Color COLOR_DECLARATION_WORDS = Color.FromArgb(66, 245, 245);
        private Color COLOR_NUMBER_WORDS = Color.FromArgb(132, 83, 245);
        private Color color_tb_inputCmd = Color.FromArgb(232, 240, 250);

        private InputSimulator simulator = new InputSimulator();
        private BackdropCmdArea backdropCmdArea = new();

        private Process processResult;
        private StreamWriter streamWriter;

        Timer timerColorizeRTB = new();

        public Form1()
        {
            MinGW mingw = new();
            mingw.Install();

            InitializeComponent();
            TopMost = false;
            int toolWidth = 1158;
            int toolHeight = 661;
            Screen primaryScreen = Screen.PrimaryScreen;
            Rectangle workingArea = primaryScreen.WorkingArea;
            int taskbarHeight = primaryScreen.Bounds.Height - workingArea.Height;

            int toolLeft = (workingArea.Width - toolWidth) / 2;
            int toolTop = workingArea.Bottom - toolHeight;
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(toolLeft, toolTop);
            Size = new System.Drawing.Size(toolWidth, toolHeight);


            chk_capsLock.FlatAppearance.CheckedBackColor = Color.FromArgb(195, 180, 20);

            rtb_codeArea.Focus();

            controlFocus = rtb_codeArea;

            tb_cmdInput.BackColor = color_tb_inputCmd;

            string textToFind = "return 0;";
            int position = rtb_codeArea.Find(textToFind);

            if (position != -1)
            {
                rtb_codeArea.SelectionStart = position - 2;
                rtb_codeArea.SelectionLength = 0;
            }

            ColorizeRtb(rtb_codeArea);

            SwitchToBackdropCmdArea();

            timerColorizeRTB.Interval = 5;
            timerColorizeRTB.Tick += (object sender, EventArgs e) =>
            {
                ColorizeRtb(rtb_codeArea);
                timerColorizeRTB.Stop();
            };

        }

        private void InitMinGWx()
        {
            // Especifique o caminho completo do arquivo .bat
            string caminhoBat = @"initMingw.bat";

            // Verifique se o arquivo .bat existe
            if (System.IO.File.Exists(caminhoBat))
            {
                if (Directory.Exists("MinGW")) return;
                // Configurar o processo para executar o arquivo .bat
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = caminhoBat,
                    UseShellExecute = true,
                    CreateNoWindow = true // Defina como true para ocultar a janela do console
                };

                try
                {
                    // Iniciar o processo
                    using (Process processo = new Process { StartInfo = psi })
                    {
                        processo.Start();
                        processo.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void SwitchToBackdropCmdArea()
        {
            backdropCmdArea.TopLevel = false;
            backdropCmdArea.Parent = splitContainer1.Panel2;
            backdropCmdArea.Dock = DockStyle.Fill;
            panel_cmdAreaContainer.Hide();
            backdropCmdArea.Show();
        }

        private void SwitchToCmdArea()
        {
            panel_cmdAreaContainer.Parent = splitContainer1.Panel2;
            panel_cmdAreaContainer.Dock = DockStyle.Fill;
            backdropCmdArea.Hide();
            panel_cmdAreaContainer.Show();
        }


        public void AppendText(RichTextBox box, Color color, string text)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public void FocusInputArea()
        {
            rtb_codeArea.Focus();
        }

        private void RequestFocus()
        {
            if (controlFocus == rtb_codeArea)
            {
                FocusInputArea();
            }
            else if (controlFocus is FormCondition fc)
            {
                fc.FocusInputArea();
            }
            else if (controlFocus is TextBox tb) { tb.Focus(); }


        }

        private void Alphabet(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RequestFocus();

            if (chk_capsLock.Checked == true)
            {
                SendKeys.Send((btn.Text).ToUpper());
            }
            else
            {
                SendKeys.Send((btn.Text).ToLower());
            }
        }

        private void chk_capsLock_CheckedChanged(object sender, EventArgs e)
        {
            var allControls = tableLayoutPanel6.Controls.OfType<Control>()
                .Concat(tlp_keyboard5.Controls.OfType<Control>())
                .Concat(tableLayoutPanel10.Controls.OfType<Control>());
            foreach (Control control in allControls)
            {
                if (control is Button button && button.Text.Length == 1 && char.IsLetter(button.Text[0]))
                {
                    if (chk_capsLock.Checked == true)
                    {
                        button.Text = button.Text.ToUpper();
                        button.ForeColor = Color.FromArgb(20, 190, 125);
                    }
                    else
                    {
                        button.Text = button.Text.ToLower();
                        button.ForeColor = Color.FromArgb(0, 0, 0);
                    }
                }
            }
        }

        private void chk_capsLock_Click(object sender, EventArgs e)
        {
            chk_capsLock.Checked = !chk_capsLock.Checked;
        }

        private void btn_singleQuote_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("\'");
        }

        private void btn_doubleQuotes_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("\"");
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{+}");
        }

        private void btn_tilde_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{~}");
        }

        private void btn_caret_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.Send("{^}");
        }

        private void btn_percent_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{%}");
        }

        private void btn_ampersand_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{&}");
        }

        private void btn_openParenthesis_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{(}");
        }

        private void btn_closeParenthesis_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{)}");
        }

        private void btn_openBrace_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{{}");
        }

        private void btn_closeBrace_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{}}");
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait(".");
        }

        private void btn_leftArrow_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{LEFT}");
        }

        private void btn_downArrow_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{DOWN}");
        }

        private void btn_rightArrow_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{RIGHT}");
        }

        private void btn_upArrow_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{UP}");
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            RequestFocus();
            int cursorPosition = rtb_codeArea.SelectionStart;
            int lineTabs = getTabInLine(cursorPosition);

            SendKeys.SendWait("{ENTER}" + getTabs(lineTabs));
        }

        private void btn_esc_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{ESC}");
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{DEL}");
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{END}");
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{HOME}");
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{BACKSPACE}");
        }

        private void btn_space_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait(" ");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
            {
                RequestFocus();
            }
        }

        private void ClearRTBCmd()
        {
            rtb_cmd.Text = string.Empty;
        }

        private void btn_compile_Click(object sender, EventArgs e)
        {
            processResult?.Kill();
            processResult?.Close();
            ClearRTBCmd();

            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;

            SwitchToBackdropCmdArea();
            backdropCmdArea.SetIsCompiling();
            string content = rtb_codeArea.Text;
            string fileName = "teste.cpp";
            string resultFileName = "resultado.exe";


            try
            {
                // Compilando código
                File.WriteAllText(fileName, content);

                string comandoGCC = "g++.exe";
                string argumentos = $"-o ../../{resultFileName} ../../{fileName}";

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = diretorioBase + @"MinGW\bin";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.StandardInput.WriteLine($"{comandoGCC} {argumentos}");
                process.StandardInput.WriteLine("exit");

                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    process.Close();
                    backdropCmdArea.SetIsCompileFail();
                    return;
                }
                process.Close();
                backdropCmdArea.SetIsCompiled();

                // Executando arquivo .exe
                processResult = new Process();
                processResult.StartInfo.FileName = resultFileName;
                processResult.StartInfo.UseShellExecute = false;
                processResult.StartInfo.RedirectStandardOutput = true;
                processResult.StartInfo.RedirectStandardInput = true;
                processResult.StartInfo.CreateNoWindow = true;
                processResult.OutputDataReceived += ProcessOutputHandler;

                Timer timer = new();
                timer.Interval = 450;
                timer.Tick += (object sender, EventArgs e) =>
                {
                    SwitchToCmdArea();
                    processResult.Start();
                    streamWriter = processResult.StandardInput;
                    processResult.BeginOutputReadLine();

                    tb_cmdInput.Focus();
                    timer.Stop();
                };
                timer.Start();


            }
            catch (Exception ex)
            {
                SwitchToBackdropCmdArea();
                backdropCmdArea.SetIsCompileFail();
            }
        }

        private void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //rtb_cmd.AppendText(outLine.Data + Environment.NewLine);
            AppendText(rtb_cmd, Color.White, outLine.Data + Environment.NewLine);
            rtb_cmd.ScrollToCaret();
        }

        private void SendUserInput()
        {
            string userInput = tb_cmdInput.Text;
            streamWriter.WriteLine(userInput);
            //rtb_cmd.AppendText(userInput + Environment.NewLine);
            AppendText(rtb_cmd, Color.FromArgb(240, 255, 125), userInput + Environment.NewLine);
            rtb_cmd.ScrollToCaret();
            tb_cmdInput.Text = String.Empty;
        }


        private void btn_cmdSendInput_Click(object sender, EventArgs e)
        {
            SendUserInput();
        }

        private void tb_cmdInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendUserInput();
            }
        }

        private void tb_cmdInput_Enter(object sender, EventArgs e)
        {
            tb_cmdInput.BackColor = Color.FromArgb(150, 250, 155);
            controlFocus = tb_cmdInput;
        }

        private void tb_cmdInput_Leave(object sender, EventArgs e)
        {
            tb_cmdInput.BackColor = color_tb_inputCmd;
        }

        private void btn_forLoop_Click(object sender, EventArgs e)
        {
            FormCondition form = new("for (int i = 0; i <= ", "; i++) {\n");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                string restCode = "\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs) + "{}}";
                SendKeys.SendWait(restCode + "{UP}{END}");
            }

            OpenModalCondition(form, IdentCode);
        }

        private void btn_ifElse_Click(object sender, EventArgs e)
        {
            FormCondition form = new("if ( ", ") {");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                string restCode = "\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs) + "{}} else {{}\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs) + "{}}";

                SendKeys.SendWait(restCode + "{UP}{UP}{UP}{END}");
            }

            OpenModalCondition(form, IdentCode);
        }

        private void btn_if_Click(object sender, EventArgs e)
        {
            FormCondition form = new("if ( ", ") {");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                string restCode = "\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs) + "{}}";

                SendKeys.SendWait(restCode + "{UP}{END}");
            }

            OpenModalCondition(form, IdentCode);
        }

        private void btn_tab_Click(object sender, EventArgs e)
        {
            RequestFocus();
            SendKeys.SendWait("{TAB}");
        }

        private void btn_int_Click(object sender, EventArgs e)
        {
            RequestFocus();
            //InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("int ");
        }

        private void btn_char_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("char ");
        }

        private void btn_float_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("float ");
        }

        private void btn_bool_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("bool ");
        }

        private void btn_cin_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("cin >> ");
        }

        private void btn_cout_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("cout <<  << endl;");
            SendKeys.SendWait("{LEFT}{LEFT}{LEFT}{LEFT}{LEFT}{LEFT}{LEFT}{LEFT}{LEFT}");
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("return;");
            SendKeys.SendWait("{LEFT}");
        }

        private void btn_include_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("#include <>");
            SendKeys.SendWait("{LEFT}");
        }

        private void btn_length_Click(object sender, EventArgs e)
        {
            RequestFocus();
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.TextEntry("<< endl;");
            btn_enter_Click(sender, e);
        }

        private int CountTabs(string linha)
        {
            return linha.Split('\t').Length - 1;
        }

        private int getTabInLine(int index)
        {
            int line = rtb_codeArea.GetLineFromCharIndex(index);
            string linha = rtb_codeArea.Lines[line];
            return CountTabs(linha);
        }

        private string getTabStr()
        {
            return "\t";
        }

        private string getTabs(int tabIndex)
        {
            string result = "";
            string tabStr = getTabStr();
            for (int i = 0; i < tabIndex; i++)
            {
                result += tabStr;
            }
            return result;
        }

        private void OpenModalCondition(FormCondition form, Action identCode)
        {
            Control currentControlOnPanel1 = splitContainer1.Panel1.Controls[0];

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            currentControlOnPanel1.Hide();
            form.Parent = splitContainer1.Panel1;
            form.Show();
            controlFocus = form;
            form.Enter += (object sender, EventArgs e) =>
            {
                controlFocus = form;
            };
            RequestFocus();

            int cursorPosition = rtb_codeArea.SelectionStart;
            int lineTabs = getTabInLine(cursorPosition);

            void OnCloseFor(object sender, EventArgs e)
            {
                rtb_codeArea.Show();
                controlFocus = rtb_codeArea;
                if (form.CloseMode == "save")
                {
                    string code = form.RichTextBoxText;

                    RequestFocus();

                    int cursorPosition = rtb_codeArea.SelectionStart;
                    int lineTabs = getTabInLine(cursorPosition);

                    rtb_codeArea.SelectionLength = 0;
                    rtb_codeArea.SelectionStart = cursorPosition;

                    SendKeys.SendWait("\n" + getTabs(lineTabs));

                    simulator.Keyboard.TextEntry(code);
                    identCode();
                }
            }

            form.FormClosed += OnCloseFor;

        }

        private void Form_Enter(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ColorizeStringsRTB(RichTextBox RTB, Color color, string pattern)
        {

            foreach (Match match in Regex.Matches(RTB.Text, pattern))
            {
                RTB.Select(match.Index, match.Length);
                RTB.SelectionColor = color;
            }
        }

        public void ColorizeRtb(RichTextBox RTB)
        {
            SendMessage(RTB.Handle, WM_SETREDRAW, false, 0);
            int selectionStart = RTB.SelectionStart;
            RTB.SelectAll();
            RTB.SelectionColor = RTB.ForeColor;

            string patternDeclaration = @"(struct|class) \w+";
            string patternNumbers = @"\d+";
            string[] wordsReserved = { "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand", "bitor", "bool", "break", "case", "catch", "char", "char16_t", "char32_t", "cin", "class", "compl", "concept", "const", "const_cast", "consteval", "constexpr", "constinit", "continue", "cout", "co_await", "co_return", "co_yield", "decltype", "default", "delete", "do", "double", "dynamic_cast", "else", "enum", "explicit", "export", "extern", "false", "float", "for", "friend", "goto", "if", "inline", "int", "long", "mutable", "namespace", "new", "noexcept", "not", "not_eq", "nullptr", "operator", "or", "or_eq", "private", "protected", "public", "register", "reinterpret_cast", "requires", "return", "short", "signed", "sizeof", "static", "static_assert", "static_cast", "struct", "switch", "template", "this", "thread_local", "throw", "true", "try", "typedef", "typeid", "typename", "union", "unsigned", "using", "void", "volatile", "wchar_t", "while", "xor", "xor_eq" };
            string[] wordsUsed = { "<", ">", "include", "/", @"\\", "@", "#", "=", "!", "~", @"\|" };
            string patternObject = @"[a-zA-Z]+(\.|->)";
            string[] wordWrappers = { "{", "}", @"\(", @"\)", @"\[", @"\]" };
            string[] wordConst = { @"\*", @"\+", "-", @"\.", "%", "&", "," };
            string wordPointers = "->";

            ColorizeStringsRTB(RTB, COLOR_DECLARATION_WORDS, patternDeclaration);
            ColorizeStringsRTB(RTB, COLOR_NUMBER_WORDS, patternNumbers);

            foreach (string word in wordsReserved)
            {
                int index = 0;
                while (index < RTB.Text.LastIndexOf(word))
                {
                    string pattern = @"(?<=^|\n| |\t|\*)" + word + @"(\W)";
                    ColorizeStringsRTB(RTB, COLOR_RESERVED_WORDS, @pattern);
                    index = RTB.Text.IndexOf(word, index) + 1;
                }
            }


            foreach (string word in wordsUsed)
            {
                ColorizeStringsRTB(RTB, COLOR_RESERVED_WORDS, word);
            }


            ColorizeStringsRTB(RTB, COLOR_CONST_WORDS, patternObject);

            foreach (string word in wordWrappers)
            {
                ColorizeStringsRTB(RTB, COLOR_WRAPPERS_WORDS, word);
            }


            foreach (string word in wordConst)
            {
                ColorizeStringsRTB(RTB, COLOR_CONST_WORDS, word);
            }

            ColorizeStringsRTB(RTB, COLOR_COMMADOT_WORDS, ";");
            ColorizeStringsRTB(RTB, COLOR_STRINGS_WORDS, "(\\x22|\\x27).*?(\\1)");
            ColorizeStringsRTB(RTB, COLOR_RESERVED_WORDS, wordPointers);

            RTB.SelectionStart = selectionStart;
            RTB.SelectionLength = 0;

            SendMessage(RTB.Handle, WM_SETREDRAW, true, 0);
            RTB.Invalidate();
        }

        private void rtb_codeArea_TextChanged(object sender, EventArgs e)
        {
            timerColorizeRTB.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                processResult.Kill();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_while_Click(object sender, EventArgs e)
        {
            FormCondition form = new("while ( ", ") {");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                string restCode = "\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs) + "{}}";

                SendKeys.SendWait(restCode + "{UP}{END}");
            }

            OpenModalCondition(form, IdentCode);
        }

        private void btn_dowhile_Click(object sender, EventArgs e)
        {
            FormCondition form = new("do {" + "} while ( ", " )");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                string restCode = "{HOME}{RIGHT}{RIGHT}{RIGHT}{RIGHT}{RIGHT}\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs);

                SendKeys.SendWait(restCode + "{UP}{END}");
            }

            OpenModalCondition(form, IdentCode);
        }

        void ApagarLinha()
        {
            if (controlFocus == rtb_codeArea)
            {
                int inicio = rtb_codeArea.GetFirstCharIndexOfCurrentLine();
                int fim = rtb_codeArea.GetFirstCharIndexFromLine(rtb_codeArea.GetLineFromCharIndex(rtb_codeArea.SelectionStart) + 1);
                if (fim == -1) fim = rtb_codeArea.Text.Length;
                rtb_codeArea.Select(inicio, fim - inicio);
                rtb_codeArea.SelectedText = "";
                SendKeys.SendWait("{UP}{END}");
            }
            else if (controlFocus is FormCondition fc)
            {
                fc.ClearAll();
            }
            else if (controlFocus is TextBox tb) { tb.Clear(); }
        }


        private void btn_switch_Click(object sender, EventArgs e)
        {
            FormCondition form = new("switch(", ") " +
                "{case : break; " +
                "default: }");

            void IdentCode()
            {
                int cursorPosition = rtb_codeArea.SelectionStart;
                int lineTabs = getTabInLine(cursorPosition);

                rtb_codeArea.SelectionLength = 0;
                rtb_codeArea.SelectionStart = cursorPosition;
                SendKeys.SendWait("{END}");
                int cursorPosition2 = rtb_codeArea.SelectionStart;
                rtb_codeArea.SelectionStart = cursorPosition2 - 24;
                SendKeys.SendWait("\n" + getTabs(lineTabs + 1));

                int cursorPosition3 = rtb_codeArea.SelectionStart;
                rtb_codeArea.SelectionStart = cursorPosition3 + 6;
                SendKeys.SendWait("\n" + getTabs(lineTabs + 2));

                int cursorPosition4 = rtb_codeArea.SelectionStart;
                rtb_codeArea.SelectionStart = cursorPosition4 + 7;
                SendKeys.SendWait("\n\n" + getTabs(lineTabs + 1));

                int cursorPosition5 = rtb_codeArea.SelectionStart;
                rtb_codeArea.SelectionStart = cursorPosition5 + 9;
                SendKeys.SendWait("\n" + getTabs(lineTabs));

                //string restCode = "\n" + getTabs(lineTabs + 1) + "\n" + getTabs(lineTabs);

                SendKeys.SendWait("{UP}{UP}{UP}{UP}{END}{LEFT}");
            }

            OpenModalCondition(form, IdentCode);
        }

        private void btn_deleteRow_Click(object sender, EventArgs e)
        {
            RequestFocus();
            ApagarLinha();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rtb_codeArea_Enter(object sender, EventArgs e)
        {
            controlFocus = rtb_codeArea;
        }
    }

}