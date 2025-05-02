using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSyncApp {
  public partial class MainForm : Form, IMainView {
    public MainForm() {
      InitializeComponent();
    }
    public string SourceFolder => textSource.Text;
    public string TargetFolder => textTarget.Text;
    public bool IsSourcePriority => chkSourcePriority.Checked;
    public event EventHandler SyncClicked;

    public void LogMessage(string message) {
      txtLog.AppendText(message + Environment.NewLine);
    }

    private void btnBrowseSource_Click(object sender, EventArgs e) {
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textSource.Text = folderDialog.SelectedPath;
      }
    }

    private void btnBrowseTarget_Click(object sender, EventArgs e) { 
      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      if (folderDialog.ShowDialog() == DialogResult.OK) {
        textTarget.Text = folderDialog.SelectedPath;
      }
    }

    private void btnSync_Click(object sender, EventArgs e) {
      SyncClicked?.Invoke(this, EventArgs.Empty);
    }
  }
}