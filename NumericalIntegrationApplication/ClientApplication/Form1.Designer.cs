namespace ClientApplication
{
    partial class Form1
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
            this.userFunctionTextBox = new System.Windows.Forms.TextBox();
            this.rectangleMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.trapezoidalRuleCheckBox = new System.Windows.Forms.CheckBox();
            this.simpsonsRuleCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type your function here";
            // 
            // userFunctionTextBox
            // 
            this.userFunctionTextBox.Location = new System.Drawing.Point(51, 56);
            this.userFunctionTextBox.Name = "userFunctionTextBox";
            this.userFunctionTextBox.Size = new System.Drawing.Size(341, 20);
            this.userFunctionTextBox.TabIndex = 1;
            this.userFunctionTextBox.UseWaitCursor = true;
            // 
            // rectangleMethodCheckBox
            // 
            this.rectangleMethodCheckBox.AutoSize = true;
            this.rectangleMethodCheckBox.Location = new System.Drawing.Point(51, 82);
            this.rectangleMethodCheckBox.Name = "rectangleMethodCheckBox";
            this.rectangleMethodCheckBox.Size = new System.Drawing.Size(114, 17);
            this.rectangleMethodCheckBox.TabIndex = 3;
            this.rectangleMethodCheckBox.Text = "Rectangle Method";
            this.rectangleMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // trapezoidalRuleCheckBox
            // 
            this.trapezoidalRuleCheckBox.AutoSize = true;
            this.trapezoidalRuleCheckBox.Location = new System.Drawing.Point(51, 105);
            this.trapezoidalRuleCheckBox.Name = "trapezoidalRuleCheckBox";
            this.trapezoidalRuleCheckBox.Size = new System.Drawing.Size(106, 17);
            this.trapezoidalRuleCheckBox.TabIndex = 4;
            this.trapezoidalRuleCheckBox.Text = "Trapezoidal Rule";
            this.trapezoidalRuleCheckBox.UseVisualStyleBackColor = true;
            // 
            // simpsonsRuleCheckBox
            // 
            this.simpsonsRuleCheckBox.AutoSize = true;
            this.simpsonsRuleCheckBox.Location = new System.Drawing.Point(51, 128);
            this.simpsonsRuleCheckBox.Name = "simpsonsRuleCheckBox";
            this.simpsonsRuleCheckBox.Size = new System.Drawing.Size(98, 17);
            this.simpsonsRuleCheckBox.TabIndex = 5;
            this.simpsonsRuleCheckBox.Text = "Simpson\'s Rule";
            this.simpsonsRuleCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 391);
            this.Controls.Add(this.simpsonsRuleCheckBox);
            this.Controls.Add(this.trapezoidalRuleCheckBox);
            this.Controls.Add(this.rectangleMethodCheckBox);
            this.Controls.Add(this.userFunctionTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userFunctionTextBox;
        private System.Windows.Forms.CheckBox rectangleMethodCheckBox;
        private System.Windows.Forms.CheckBox trapezoidalRuleCheckBox;
        private System.Windows.Forms.CheckBox simpsonsRuleCheckBox;
    }
}

