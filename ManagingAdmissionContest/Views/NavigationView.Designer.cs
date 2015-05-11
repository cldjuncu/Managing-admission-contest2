namespace ManagingAdmissionContest.Views
{
    partial class NavigationView
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
            this.formButton = new System.Windows.Forms.Button();
            this.publishResults = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formButton
            // 
            this.formButton.Location = new System.Drawing.Point(436, 150);
            this.formButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formButton.Name = "formButton";
            this.formButton.Size = new System.Drawing.Size(147, 31);
            this.formButton.TabIndex = 0;
            this.formButton.Text = "Form";
            this.formButton.UseVisualStyleBackColor = true;
            this.formButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // publishResults
            // 
            this.publishResults.Location = new System.Drawing.Point(436, 296);
            this.publishResults.Margin = new System.Windows.Forms.Padding(4);
            this.publishResults.Name = "publishResults";
            this.publishResults.Size = new System.Drawing.Size(147, 31);
            this.publishResults.TabIndex = 2;
            this.publishResults.Text = "Publish Results";
            this.publishResults.UseVisualStyleBackColor = true;
            this.publishResults.Click += new System.EventHandler(this.publishResults_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 224);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load from file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 587);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formButton);
            this.Controls.Add(this.publishResults);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Managing Faculty Admission Contest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button formButton;
        private System.Windows.Forms.Button publishResults;
        private System.Windows.Forms.Button button1;
    }
}