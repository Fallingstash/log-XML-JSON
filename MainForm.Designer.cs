namespace FolderSyncApp {
  partial class MainForm {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent() {
      this.textSource = new System.Windows.Forms.TextBox();
      this.textTarget = new System.Windows.Forms.TextBox();
      this.btnBrowseSource = new System.Windows.Forms.Button();
      this.btnBrowseTarget = new System.Windows.Forms.Button();
      this.btnSync = new System.Windows.Forms.Button();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.chkSourcePriority = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // textSource
      // 
      this.textSource.Location = new System.Drawing.Point(12, 32);
      this.textSource.Name = "textSource";
      this.textSource.Size = new System.Drawing.Size(373, 20);
      this.textSource.TabIndex = 0;
      this.textSource.Text = "C:\\Folder1";
      // 
      // textTarget
      // 
      this.textTarget.Location = new System.Drawing.Point(415, 32);
      this.textTarget.Name = "textTarget";
      this.textTarget.Size = new System.Drawing.Size(373, 20);
      this.textTarget.TabIndex = 1;
      this.textTarget.Text = "C:\\Folder2";
      // 
      // btnBrowseSource
      // 
      this.btnBrowseSource.Location = new System.Drawing.Point(158, 86);
      this.btnBrowseSource.Name = "btnBrowseSource";
      this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
      this.btnBrowseSource.TabIndex = 2;
      this.btnBrowseSource.Text = "Обзор..";
      this.btnBrowseSource.UseVisualStyleBackColor = true;
      this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
      // 
      // btnBrowseTarget
      // 
      this.btnBrowseTarget.Location = new System.Drawing.Point(576, 86);
      this.btnBrowseTarget.Name = "btnBrowseTarget";
      this.btnBrowseTarget.Size = new System.Drawing.Size(75, 23);
      this.btnBrowseTarget.TabIndex = 3;
      this.btnBrowseTarget.Text = "Обзор..";
      this.btnBrowseTarget.UseVisualStyleBackColor = true;
      this.btnBrowseTarget.Click += new System.EventHandler(this.btnBrowseTarget_Click);
      // 
      // btnSync
      // 
      this.btnSync.Location = new System.Drawing.Point(259, 152);
      this.btnSync.Name = "btnSync";
      this.btnSync.Size = new System.Drawing.Size(291, 91);
      this.btnSync.TabIndex = 4;
      this.btnSync.Text = "Синхронизировать!";
      this.btnSync.UseVisualStyleBackColor = true;
      this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
      // 
      // txtLog
      // 
      this.txtLog.Location = new System.Drawing.Point(12, 249);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtLog.Size = new System.Drawing.Size(776, 189);
      this.txtLog.TabIndex = 5;
      // 
      // chkSourcePriority
      // 
      this.chkSourcePriority.AutoSize = true;
      this.chkSourcePriority.Checked = true;
      this.chkSourcePriority.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSourcePriority.Location = new System.Drawing.Point(2, 115);
      this.chkSourcePriority.Name = "chkSourcePriority";
      this.chkSourcePriority.Size = new System.Drawing.Size(251, 95);
      this.chkSourcePriority.TabIndex = 6;
      this.chkSourcePriority.Text = "Приоритет у первой папки. \r\nЕсли во второй, присутствуют такие файлы,\r\nкоторых не" +
    "т в первой, \r\nто они удаляются из второй.\r\nВ противном случае приоритет \r\nимеет " +
    "вторая папка.\r\n\r\n";
      this.chkSourcePriority.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.chkSourcePriority);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.btnSync);
      this.Controls.Add(this.btnBrowseTarget);
      this.Controls.Add(this.btnBrowseSource);
      this.Controls.Add(this.textTarget);
      this.Controls.Add(this.textSource);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textSource;
    private System.Windows.Forms.TextBox textTarget;
    private System.Windows.Forms.Button btnBrowseSource;
    private System.Windows.Forms.Button btnBrowseTarget;
    private System.Windows.Forms.Button btnSync;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.CheckBox chkSourcePriority;
  }
}

