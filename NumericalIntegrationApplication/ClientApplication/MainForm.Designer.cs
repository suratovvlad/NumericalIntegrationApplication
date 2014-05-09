namespace ClientApplication
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserFunctionTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.MethodsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ParamATextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ParamBTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Function";
            // 
            // UserFunctionTextBox
            // 
            this.UserFunctionTextBox.Location = new System.Drawing.Point(51, 56);
            this.UserFunctionTextBox.Name = "UserFunctionTextBox";
            this.UserFunctionTextBox.Size = new System.Drawing.Size(147, 20);
            this.UserFunctionTextBox.TabIndex = 1;
            this.UserFunctionTextBox.UseWaitCursor = true;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(51, 161);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Error";
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Location = new System.Drawing.Point(51, 135);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(147, 20);
            this.ErrorTextBox.TabIndex = 8;
            // 
            // MethodsComboBox
            // 
            this.MethodsComboBox.FormattingEnabled = true;
            this.MethodsComboBox.Items.AddRange(new object[] {
            "Rectangle Method",
            "Trapezoidal Rule",
            "Simpson\'s Rule",
            "All of these methods"});
            this.MethodsComboBox.Location = new System.Drawing.Point(51, 95);
            this.MethodsComboBox.Name = "MethodsComboBox";
            this.MethodsComboBox.Size = new System.Drawing.Size(147, 21);
            this.MethodsComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Method";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "a";
            // 
            // ParamATextBox
            // 
            this.ParamATextBox.Location = new System.Drawing.Point(224, 56);
            this.ParamATextBox.Name = "ParamATextBox";
            this.ParamATextBox.Size = new System.Drawing.Size(100, 20);
            this.ParamATextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "b";
            // 
            // ParamBTextBox
            // 
            this.ParamBTextBox.Location = new System.Drawing.Point(224, 95);
            this.ParamBTextBox.Name = "ParamBTextBox";
            this.ParamBTextBox.Size = new System.Drawing.Size(100, 20);
            this.ParamBTextBox.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 391);
            this.Controls.Add(this.ParamBTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ParamATextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MethodsComboBox);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.UserFunctionTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserFunctionTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.ComboBox MethodsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ParamATextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ParamBTextBox;
    }
}

