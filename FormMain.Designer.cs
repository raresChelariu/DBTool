
namespace DBTool
{
    partial class FormMain
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonImportTableFromCSV = new System.Windows.Forms.Button();
            this.buttonFindDependecies = new System.Windows.Forms.Button();
            this.textBoxFunctional = new System.Windows.Forms.TextBox();
            this.textBoxMultivalued = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(50, 61);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(207, 216);
            this.textBoxInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Functional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Multivaluated";
            // 
            // buttonImportTableFromCSV
            // 
            this.buttonImportTableFromCSV.Location = new System.Drawing.Point(50, 304);
            this.buttonImportTableFromCSV.Name = "buttonImportTableFromCSV";
            this.buttonImportTableFromCSV.Size = new System.Drawing.Size(125, 30);
            this.buttonImportTableFromCSV.TabIndex = 4;
            this.buttonImportTableFromCSV.Text = "Import from CSV";
            this.buttonImportTableFromCSV.UseVisualStyleBackColor = true;
            this.buttonImportTableFromCSV.Click += new System.EventHandler(this.buttonImportTableFromCSV_Click);
            // 
            // buttonFindDependecies
            // 
            this.buttonFindDependecies.Location = new System.Drawing.Point(50, 340);
            this.buttonFindDependecies.Name = "buttonFindDependecies";
            this.buttonFindDependecies.Size = new System.Drawing.Size(125, 36);
            this.buttonFindDependecies.TabIndex = 5;
            this.buttonFindDependecies.Text = "Find dependencies";
            this.buttonFindDependecies.UseVisualStyleBackColor = true;
            this.buttonFindDependecies.Click += new System.EventHandler(this.buttonFindDependecies_Click);
            // 
            // textBoxFunctional
            // 
            this.textBoxFunctional.Location = new System.Drawing.Point(283, 61);
            this.textBoxFunctional.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFunctional.Multiline = true;
            this.textBoxFunctional.Name = "textBoxFunctional";
            this.textBoxFunctional.ReadOnly = true;
            this.textBoxFunctional.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFunctional.Size = new System.Drawing.Size(167, 216);
            this.textBoxFunctional.TabIndex = 6;
            // 
            // textBoxMultivaluated
            // 
            this.textBoxMultivalued.Location = new System.Drawing.Point(488, 61);
            this.textBoxMultivalued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMultivalued.Multiline = true;
            this.textBoxMultivalued.Name = "textBoxMultivaluated";
            this.textBoxMultivalued.ReadOnly = true;
            this.textBoxMultivalued.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMultivalued.Size = new System.Drawing.Size(167, 216);
            this.textBoxMultivalued.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 421);
            this.Controls.Add(this.textBoxMultivalued);
            this.Controls.Add(this.textBoxFunctional);
            this.Controls.Add(this.buttonFindDependecies);
            this.Controls.Add(this.buttonImportTableFromCSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonImportTableFromCSV;
        private System.Windows.Forms.Button buttonFindDependecies;
        private System.Windows.Forms.TextBox textBoxFunctional;
        private System.Windows.Forms.TextBox textBoxMultivalued;
    }
}