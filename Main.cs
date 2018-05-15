using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFontEditor
{
    public partial class Main : Form
    {
        private const string registryAdress = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontSubstitutes";
        private Font selectedFont;
        public Main()
        {
            InitializeComponent();
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.MinSize = 11;
            fd.MaxSize = 11;
            fd.FontMustExist = true;          
            fd.ShowDialog();
            if (fd.Font != null)
            {
                label2.Text = fd.Font.Name;
                label2.Font = fd.Font;
                selectedFont = fd.Font;
                buttonAccept.Enabled = true;
            }
            else buttonAccept.Enabled = false;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Registry.SetValue(registryAdress, "Segoe UI", selectedFont.Name);
            buttonAccept.Enabled = false;
            MessageBox.Show("Font set to: " + selectedFont.Name, "Font set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
