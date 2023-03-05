namespace IvanovoServer
{
    partial class Server
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.textBoxLogServer = new System.Windows.Forms.TextBox();
            this.buttonBind = new System.Windows.Forms.Button();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.timerServer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Локальный порт:";
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(124, 13);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocalPort.TabIndex = 1;
            // 
            // textBoxLogServer
            // 
            this.textBoxLogServer.Location = new System.Drawing.Point(12, 39);
            this.textBoxLogServer.Multiline = true;
            this.textBoxLogServer.Name = "textBoxLogServer";
            this.textBoxLogServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogServer.Size = new System.Drawing.Size(307, 199);
            this.textBoxLogServer.TabIndex = 2;
            // 
            // buttonBind
            // 
            this.buttonBind.Location = new System.Drawing.Point(230, 10);
            this.buttonBind.Name = "buttonBind";
            this.buttonBind.Size = new System.Drawing.Size(89, 23);
            this.buttonBind.TabIndex = 3;
            this.buttonBind.Text = "Открыть порт";
            this.buttonBind.UseVisualStyleBackColor = true;
            this.buttonBind.Click += new System.EventHandler(this.buttonBind_Click);
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(326, 39);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(171, 199);
            this.listBoxClients.TabIndex = 4;
            // 
            // timerServer
            // 
            this.timerServer.Tick += new System.EventHandler(this.TimerServer_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 250);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.buttonBind);
            this.Controls.Add(this.textBoxLogServer);
            this.Controls.Add(this.textBoxLocalPort);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.TextBox textBoxLogServer;
        private System.Windows.Forms.Button buttonBind;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Timer timerServer;
    }
}

