using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virtual_Keyboard
{
    public partial class FormModal : Form
    {
        public FormModal()
        {
            InitializeComponent();
        }

        public string RichTextBoxText
        {
            get { return modal_rtb.Text; }
        }

        public void CloseModal()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        int tabIndex = 0;

        private string getTabStr()
        {
            return "\t";
        }

        private string getTabs()
        {
            string result = "";
            string tabStr = getTabStr();
            for (int i = 0; i < tabIndex; i++)
            {
                result += tabStr;
            }
            Debug.WriteLine(result);
            return result;
        }

        private string getStringLocator()
        {
            string str = "⠀⠀⠀⠀⠀⠀⠀⠀⠀";
            string str2 = "**#**";
            return str;
        }

        private void reposCursor()
        {
            string strLocator = getStringLocator();
            int strLen = strLocator.Length;
            int locatorIndex = modal_rtb.Find(getStringLocator());
            if (locatorIndex != -1)
            {
                modal_rtb.Select(locatorIndex, strLen);
                modal_rtb.ScrollToCaret();
                //modal_rtb.SelectedText = string.Empty;
                modal_rtb.SelectionStart = locatorIndex;
                modal_rtb.SelectionLength = strLen; // Comprimento de "if ".
                modal_rtb.SelectionColor = Color.Blue; // Defina a cor desejada.
            }
        }

        private void modal_btn_if_Click(object sender, EventArgs e)
        {
            //reposCursorIntoModal();
            reposCursor();
            modal_rtb.Focus();
            string firstTab = tabIndex < 2 ? getTabs() : getTabStr();
            string code = firstTab + "if {(}   {)}\n" + getTabs() + "{{}\n" + getTabs() + getStringLocator() + "\n" + getTabs() + "{}}";
            //string code = "if (  )";
            SendKeys.SendWait(code);
            tabIndex++;
            //pointerNextPosition += 11;

        }



        private void modal_btn_for_Click(object sender, EventArgs e)
        {
            reposCursor();
            modal_rtb.Focus();
            string firstTab = tabIndex < 2 ? getTabs() : getTabStr();
            string code = firstTab + "for (int i = 0; i <= )";
            //string code = "if (  )";
            SendKeys.SendWait(code);
            tabIndex++;

        }

        private void modal_btn_switch_Click(object sender, EventArgs e)
        {

        }

        private void modal_btn_close_Click(object sender, EventArgs e)
        {
            CloseModal();
        }

    }
}
