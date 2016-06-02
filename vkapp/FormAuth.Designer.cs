namespace vkapp
{
    partial class FormAuth
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowserVK = new System.Windows.Forms.WebBrowser();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowserVK
            // 
            this.webBrowserVK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserVK.Location = new System.Drawing.Point(0, 26);
            this.webBrowserVK.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserVK.Name = "webBrowserVK";
            this.webBrowserVK.Size = new System.Drawing.Size(971, 412);
            this.webBrowserVK.TabIndex = 0;
            this.webBrowserVK.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserVK_DocumentCompleted);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAddress.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(971, 20);
            this.textBoxAddress.TabIndex = 1;
            // 
            // FormAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 438);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.webBrowserVK);
            this.Name = "FormAuth";
            this.Text = "FormAuth";
            this.Load += new System.EventHandler(this.FormAuth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserVK;
        private System.Windows.Forms.TextBox textBoxAddress;
    }
}

