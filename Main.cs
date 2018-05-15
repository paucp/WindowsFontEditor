using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFontEditor
{
    public partial class Main : Form
    {
        private const string fontSubsituteAdress = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontSubstitutes";
        private const string fontAdress = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
        private Font selectedFont;

        public Main()
        {
            InitializeComponent();
            buttonReset.Enabled = IsTweaked();
            buttonTweak.Enabled = !IsTweaked();      
            buttonSelect.Enabled = IsTweaked();         
        }
        private bool IsTweaked()       
          => string.IsNullOrEmpty(Registry.GetValue(fontAdress, "Segoe UI (TrueType)", null).ToString());        

        private void SetFontTweak()
        {
            Registry.SetValue(fontAdress, "Segoe UI (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Bold (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Bold Italic (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Italic (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Light (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Semibold (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Light (TrueType)", "");
            Registry.SetValue(fontAdress, "Segoe UI Symbol (TrueType)", "");
        }
        private void ResetFontTweak()
        {
            Registry.SetValue(fontAdress, "Segoe UI (TrueType)", "segoeui.ttf");
            Registry.SetValue(fontAdress, "Segoe UI Bold (TrueType)", "segoeuib.ttf");
            Registry.SetValue(fontAdress, "Segoe UI Bold Italic (TrueType)", "segoeuiz.ttf");
            Registry.SetValue(fontAdress, "Segoe UI Italic (TrueType)", "segoeuii.ttf");
            Registry.SetValue(fontAdress, "Segoe UI Light (TrueType)", "segoeuil.ttf");
            Registry.SetValue(fontAdress, "Segoe UI Semibold (TrueType)", "seguisb.ttf");       
            Registry.SetValue(fontAdress, "Segoe UI Symbol (TrueType)", "seguisym.ttf");
            Registry.SetValue(fontSubsituteAdress, "Segoe UI", "Segoe UI");
        }
        private void ChangeFont(string fontname)        
            => Registry.SetValue(fontSubsituteAdress, "Segoe UI", selectedFont.Name);

        
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.MinSize = 11;
            fontDialog.MaxSize = 11;
            fontDialog.FontMustExist = true;         
            fontDialog.ShowDialog();
            if (fontDialog.Font != null)
            {
                label2.Text = fontDialog.Font.Name;
                label2.Font = fontDialog.Font;
                selectedFont = fontDialog.Font;
                buttonSet.Enabled = true;
            }
            else buttonSet.Enabled = false;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {            
            buttonSet.Enabled = false;
            ChangeFont(selectedFont.Name);
            MessageBox.Show("Font set to: " + selectedFont.Name, "Font set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonTweak_Click(object sender, EventArgs e)
        {
            SetFontTweak();
            buttonTweak.Enabled = false;
            buttonReset.Enabled = true;
            buttonSelect.Enabled = true;           
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetFontTweak();
            buttonTweak.Enabled = true;
            buttonReset.Enabled = false;
            buttonSelect.Enabled = false;
            buttonSet.Enabled = false;
        }       
    }
}
