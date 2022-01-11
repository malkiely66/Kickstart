namespace KickStarter
{
    partial class KickStartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Islands_btn = new System.Windows.Forms.Button();
            this.Input_File_lbl = new System.Windows.Forms.Label();
            this.input_File_txt = new System.Windows.Forms.TextBox();
            this.Input_File_btn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Reload_Input_btn = new System.Windows.Forms.Button();
            this.Save_to_File = new System.Windows.Forms.Button();
            this.Input_txt = new System.Windows.Forms.TextBox();
            this.Input_Data_lbl = new System.Windows.Forms.Label();
            this.Launch_UDP_btn = new System.Windows.Forms.Button();
            this.Output_txt = new System.Windows.Forms.TextBox();
            this.Output_lbl = new System.Windows.Forms.Label();
            this.UDP_IP_txt = new System.Windows.Forms.TextBox();
            this.UDP_Delay_txt = new System.Windows.Forms.TextBox();
            this.UDP_Port_txt = new System.Windows.Forms.TextBox();
            this.Rerions_btn = new System.Windows.Forms.Button();
            this.Rerions2_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Islands_btn
            // 
            this.Islands_btn.Location = new System.Drawing.Point(12, 32);
            this.Islands_btn.Name = "Islands_btn";
            this.Islands_btn.Size = new System.Drawing.Size(78, 20);
            this.Islands_btn.TabIndex = 2;
            this.Islands_btn.Text = "Islands";
            this.Islands_btn.UseVisualStyleBackColor = true;
            this.Islands_btn.Click += new System.EventHandler(this.Islands_btn_Click);
            // 
            // Input_File_lbl
            // 
            this.Input_File_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Input_File_lbl.AutoSize = true;
            this.Input_File_lbl.Location = new System.Drawing.Point(139, 403);
            this.Input_File_lbl.Name = "Input_File_lbl";
            this.Input_File_lbl.Size = new System.Drawing.Size(50, 13);
            this.Input_File_lbl.TabIndex = 27;
            this.Input_File_lbl.Text = "Input File";
            // 
            // input_File_txt
            // 
            this.input_File_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.input_File_txt.Location = new System.Drawing.Point(142, 423);
            this.input_File_txt.Name = "input_File_txt";
            this.input_File_txt.Size = new System.Drawing.Size(442, 20);
            this.input_File_txt.TabIndex = 28;
            this.input_File_txt.Text = "C:\\Temp\\KickStarterIn\\Islands-in.txt";
            this.input_File_txt.LostFocus += new System.EventHandler(this.Input_File_txt_LostFocus);
            // 
            // Input_File_btn
            // 
            this.Input_File_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Input_File_btn.Location = new System.Drawing.Point(597, 423);
            this.Input_File_btn.Name = "Input_File_btn";
            this.Input_File_btn.Size = new System.Drawing.Size(78, 20);
            this.Input_File_btn.TabIndex = 30;
            this.Input_File_btn.Text = "Select File";
            this.Input_File_btn.UseVisualStyleBackColor = true;
            this.Input_File_btn.Click += new System.EventHandler(this.Input_File_btn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // Reload_Input_btn
            // 
            this.Reload_Input_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Reload_Input_btn.Location = new System.Drawing.Point(142, 451);
            this.Reload_Input_btn.Name = "Reload_Input_btn";
            this.Reload_Input_btn.Size = new System.Drawing.Size(136, 23);
            this.Reload_Input_btn.TabIndex = 31;
            this.Reload_Input_btn.Text = "Reload Input from File";
            this.Reload_Input_btn.UseVisualStyleBackColor = true;
            this.Reload_Input_btn.Click += new System.EventHandler(this.Reload_Data_btn_Click);
            // 
            // Save_to_File
            // 
            this.Save_to_File.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save_to_File.Location = new System.Drawing.Point(448, 451);
            this.Save_to_File.Name = "Save_to_File";
            this.Save_to_File.Size = new System.Drawing.Size(136, 23);
            this.Save_to_File.TabIndex = 32;
            this.Save_to_File.Text = "Save Input to File";
            this.Save_to_File.UseVisualStyleBackColor = true;
            this.Save_to_File.Click += new System.EventHandler(this.Save_to_File_Click);
            // 
            // Input_txt
            // 
            this.Input_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Input_txt.Location = new System.Drawing.Point(142, 32);
            this.Input_txt.Multiline = true;
            this.Input_txt.Name = "Input_txt";
            this.Input_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Input_txt.Size = new System.Drawing.Size(453, 349);
            this.Input_txt.TabIndex = 40;
            this.Input_txt.Text = "1 0 1 0 1 0 1\r\n1 0 1 0 1 0 1\r\n1 0 1 0 1 0 1\r\n1 0 1 0 1 0 1\r\n1 0 1 0 1 0 1\r\n1 0 1 " +
    "0 1 0 1\r\n1 1 1 1 1 1 1";
            // 
            // Input_Data_lbl
            // 
            this.Input_Data_lbl.AutoSize = true;
            this.Input_Data_lbl.Location = new System.Drawing.Point(139, 12);
            this.Input_Data_lbl.Name = "Input_Data_lbl";
            this.Input_Data_lbl.Size = new System.Drawing.Size(57, 13);
            this.Input_Data_lbl.TabIndex = 41;
            this.Input_Data_lbl.Text = "Input Data";
            // 
            // Launch_UDP_btn
            // 
            this.Launch_UDP_btn.Location = new System.Drawing.Point(12, 67);
            this.Launch_UDP_btn.Name = "Launch_UDP_btn";
            this.Launch_UDP_btn.Size = new System.Drawing.Size(78, 23);
            this.Launch_UDP_btn.TabIndex = 42;
            this.Launch_UDP_btn.Text = "Launch UDP";
            this.Launch_UDP_btn.UseVisualStyleBackColor = true;
            this.Launch_UDP_btn.Click += new System.EventHandler(this.Launch_UDP_btn_Click);
            // 
            // Output_txt
            // 
            this.Output_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output_txt.Location = new System.Drawing.Point(601, 32);
            this.Output_txt.Multiline = true;
            this.Output_txt.Name = "Output_txt";
            this.Output_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Output_txt.Size = new System.Drawing.Size(488, 349);
            this.Output_txt.TabIndex = 43;
            // 
            // Output_lbl
            // 
            this.Output_lbl.AutoSize = true;
            this.Output_lbl.Location = new System.Drawing.Point(598, 12);
            this.Output_lbl.Name = "Output_lbl";
            this.Output_lbl.Size = new System.Drawing.Size(39, 13);
            this.Output_lbl.TabIndex = 44;
            this.Output_lbl.Text = "Output";
            // 
            // UDP_IP_txt
            // 
            this.UDP_IP_txt.Location = new System.Drawing.Point(12, 96);
            this.UDP_IP_txt.Name = "UDP_IP_txt";
            this.UDP_IP_txt.Size = new System.Drawing.Size(59, 20);
            this.UDP_IP_txt.TabIndex = 45;
            this.UDP_IP_txt.Text = "127.0.0.1";
            // 
            // UDP_Delay_txt
            // 
            this.UDP_Delay_txt.Location = new System.Drawing.Point(119, 96);
            this.UDP_Delay_txt.Name = "UDP_Delay_txt";
            this.UDP_Delay_txt.Size = new System.Drawing.Size(18, 20);
            this.UDP_Delay_txt.TabIndex = 46;
            this.UDP_Delay_txt.Text = "10";
            // 
            // UDP_Port_txt
            // 
            this.UDP_Port_txt.Location = new System.Drawing.Point(76, 96);
            this.UDP_Port_txt.Name = "UDP_Port_txt";
            this.UDP_Port_txt.Size = new System.Drawing.Size(40, 20);
            this.UDP_Port_txt.TabIndex = 47;
            this.UDP_Port_txt.Text = "32123";
            // 
            // Rerions_btn
            // 
            this.Rerions_btn.Location = new System.Drawing.Point(22, 141);
            this.Rerions_btn.Name = "Rerions_btn";
            this.Rerions_btn.Size = new System.Drawing.Size(75, 23);
            this.Rerions_btn.TabIndex = 48;
            this.Rerions_btn.Text = "Rerions";
            this.Rerions_btn.UseVisualStyleBackColor = true;
            this.Rerions_btn.Click += new System.EventHandler(this.Regions_btn_Click);
            // 
            // Rerions2_btn
            // 
            this.Rerions2_btn.Location = new System.Drawing.Point(22, 170);
            this.Rerions2_btn.Name = "Rerions2_btn";
            this.Rerions2_btn.Size = new System.Drawing.Size(75, 23);
            this.Rerions2_btn.TabIndex = 49;
            this.Rerions2_btn.Text = "Rerions2";
            this.Rerions2_btn.UseVisualStyleBackColor = true;
            this.Rerions2_btn.Click += new System.EventHandler(this.Rerions2_btn_Click);
            // 
            // KickStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 520);
            this.Controls.Add(this.Rerions2_btn);
            this.Controls.Add(this.Rerions_btn);
            this.Controls.Add(this.UDP_Port_txt);
            this.Controls.Add(this.UDP_Delay_txt);
            this.Controls.Add(this.UDP_IP_txt);
            this.Controls.Add(this.Output_lbl);
            this.Controls.Add(this.Output_txt);
            this.Controls.Add(this.Launch_UDP_btn);
            this.Controls.Add(this.Input_Data_lbl);
            this.Controls.Add(this.Input_txt);
            this.Controls.Add(this.Save_to_File);
            this.Controls.Add(this.Reload_Input_btn);
            this.Controls.Add(this.Input_File_btn);
            this.Controls.Add(this.input_File_txt);
            this.Controls.Add(this.Input_File_lbl);
            this.Controls.Add(this.Islands_btn);
            this.Name = "KickStartForm";
            this.Text = "KickStarter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Islands_btn;
        private System.Windows.Forms.Label Input_File_lbl;
        private System.Windows.Forms.TextBox input_File_txt;
        private System.Windows.Forms.Button Input_File_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button Reload_Input_btn;
        private System.Windows.Forms.Button Save_to_File;
        private System.Windows.Forms.TextBox Input_txt;
        private System.Windows.Forms.Label Input_Data_lbl;
        private System.Windows.Forms.Button Launch_UDP_btn;
        private System.Windows.Forms.Label Output_lbl;
        public System.Windows.Forms.TextBox Output_txt;
        private System.Windows.Forms.TextBox UDP_IP_txt;
        private System.Windows.Forms.TextBox UDP_Delay_txt;
        private System.Windows.Forms.TextBox UDP_Port_txt;
        private System.Windows.Forms.Button Rerions_btn;
        private System.Windows.Forms.Button Rerions2_btn;
    }
}

