using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MSHTML;

namespace LiveSwitch.TextControl
{
    public partial class EditorForm : Form
    {
        private string _filename = null;

        public EditorForm()
        {
            InitializeComponent();
            editor.Tick += new Editor.TickDelegate(editor_Tick);
        }

        private void editor_Tick()
        {
            undoToolStripMenuItem.Enabled = editor.CanUndo();
            redoToolStripMenuItem.Enabled = editor.CanRedo();
          
            cutToolStripMenuItem.Enabled = editor.CanCut();
            copyToolStripMenuItem.Enabled = editor.CanCopy();
            pasteToolStripMenuItem.Enabled = editor.CanPaste();
            imageToolStripMenuItem.Enabled = editor.CanInsertLink();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _filename = null;
            Text = null;
            editor.BodyHtml = string.Empty;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filename == null)
            {
                if (!SaveFileDialog())
                    return;
            }
            SaveFile(_filename);
        }



        private bool SaveFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = "dlc";
                dlg.Filter = "DLOC files (*.dloc;*.dlc)|*.dloc;*.dlc";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                    return true;
                }
                else
                    return false;
            }
        }

        private void SaveFile(string filename)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.Write(editor.DocumentText);
                writer.Flush();
                writer.Close();
            }
        }

        private void LoadFile(string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                editor.Html = reader.ReadToEnd();
                Text = editor.DocumentTitle;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "DLOC files (*.dloc;*.dlc)|*.dloc;*.dlc";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                }
                else
                    return;
            }
            LoadFile(_filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog())
                SaveFile(_filename);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SearchDialog dlg = new SearchDialog(editor))
            {
                dlg.ShowDialog(this);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }



        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Print();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertBreak();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertImage();
        }

        private void editor_Load(object sender, EventArgs e)
        {
            if (_filename == null)
            {
                if (!SaveFileDialog())
                    return;
            }
            SaveFile(_filename);
        }


        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.White;
        }

        private void ediToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            ediToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void ediToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            ediToolStripMenuItem.ForeColor = Color.White;
        }

        private void insertToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            insertToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void insertToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            insertToolStripMenuItem.ForeColor = Color.White;
        }
        //
        private void newToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            newToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void newToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            newToolStripMenuItem.ForeColor = Color.White;
        }
        //
        private void openToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            openToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void openToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            openToolStripMenuItem.ForeColor = Color.White;
        }
        //
        private void saveToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            saveToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void saveToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            saveToolStripMenuItem.ForeColor = Color.White;
        }

        private void saveAsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void saveAsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.ForeColor = Color.White;
        }

        private void printToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            printToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void printToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            printToolStripMenuItem.ForeColor = Color.White;
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.White;
        }
        //
        private void undoToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            undoToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void undoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            undoToolStripMenuItem.ForeColor = Color.White;
        }

        private void redoToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            redoToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void redoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            redoToolStripMenuItem.ForeColor = Color.White;
        }

        private void cutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            cutToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void cutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            cutToolStripMenuItem.ForeColor = Color.White;
        }

        private void copyToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            copyToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void copyToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            copyToolStripMenuItem.ForeColor = Color.White;
        }

        private void pasteToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void pasteToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.ForeColor = Color.White;
        }

        private void selectAllToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void selectAllToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem.ForeColor = Color.White;
        }

        private void findToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            findToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void findToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            findToolStripMenuItem.ForeColor = Color.White;
        }

        private void breakToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            breakToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void breakToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            breakToolStripMenuItem.ForeColor = Color.White;
        }

        private void imageToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            imageToolStripMenuItem.ForeColor = Color.Indigo;
        }

        private void imageToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            imageToolStripMenuItem.ForeColor = Color.White;
        }
        

    }
}