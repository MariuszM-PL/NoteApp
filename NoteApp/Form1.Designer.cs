namespace NoteApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.listNotes = new System.Windows.Forms.ListBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbTitle
            // 
            this.tbTitle.AccessibleName = "tbTitle";
            this.tbTitle.Location = new System.Drawing.Point(42, 45);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(112, 23);
            this.tbTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "btnAdd";
            this.btnAdd.Location = new System.Drawing.Point(42, 296);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(203, 62);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Note APP";
            // 
            // lblDate
            // 
            this.lblDate.AccessibleName = "lblDate";
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 259);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 15);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";
            // 
            // lblDateValue
            // 
            this.lblDateValue.AccessibleName = "lblDateValue";
            this.lblDateValue.AutoSize = true;
            this.lblDateValue.Location = new System.Drawing.Point(44, 260);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Size = new System.Drawing.Size(0, 15);
            this.lblDateValue.TabIndex = 7;
            // 
            // listNotes
            // 
            this.listNotes.AccessibleName = "listNotes";
            this.listNotes.FormattingEnabled = true;
            this.listNotes.ItemHeight = 15;
            this.listNotes.Location = new System.Drawing.Point(277, 88);
            this.listNotes.Name = "listNotes";
            this.listNotes.Size = new System.Drawing.Size(95, 169);
            this.listNotes.TabIndex = 8;
            this.listNotes.SelectedIndexChanged += new System.EventHandler(this.listNotes_SelectedIndexChanged);
            // 
            // txtNote
            // 
            this.txtNote.AccessibleName = "txtNote";
            this.txtNote.Location = new System.Drawing.Point(44, 87);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(201, 170);
            this.txtNote.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.listNotes);
            this.Controls.Add(this.lblDateValue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbTitle;
        private Label label1;
        private Button btnAdd;
        private Label label2;
        private Label lblDate;
        private Label lblDateValue;
        private ListBox listNotes;
        private TextBox txtNote;
    }
}