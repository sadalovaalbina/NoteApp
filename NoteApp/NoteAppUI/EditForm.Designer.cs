
namespace NoteAppUI
{
    partial class EditForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.dateTimePickerCreated = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerModified = new System.Windows.Forms.DateTimePicker();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.noteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.MaximumSize = new System.Drawing.Size(92, 21);
            this.label1.MinimumSize = new System.Drawing.Size(92, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.MaximumSize = new System.Drawing.Size(92, 21);
            this.label3.MinimumSize = new System.Drawing.Size(92, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(349, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.MaximumSize = new System.Drawing.Size(92, 21);
            this.label4.MinimumSize = new System.Drawing.Size(92, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modified:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTitle.Location = new System.Drawing.Point(112, 15);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.MaximumSize = new System.Drawing.Size(771, 25);
            this.textBoxTitle.MinimumSize = new System.Drawing.Size(771, 25);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(771, 22);
            this.textBoxTitle.TabIndex = 4;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // dateTimePickerCreated
            // 
            this.dateTimePickerCreated.Enabled = false;
            this.dateTimePickerCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerCreated.Location = new System.Drawing.Point(112, 82);
            this.dateTimePickerCreated.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerCreated.MaximumSize = new System.Drawing.Size(199, 25);
            this.dateTimePickerCreated.MinimumSize = new System.Drawing.Size(199, 25);
            this.dateTimePickerCreated.Name = "dateTimePickerCreated";
            this.dateTimePickerCreated.Size = new System.Drawing.Size(199, 25);
            this.dateTimePickerCreated.TabIndex = 5;
            // 
            // dateTimePickerModified
            // 
            this.dateTimePickerModified.Enabled = false;
            this.dateTimePickerModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerModified.Location = new System.Drawing.Point(449, 82);
            this.dateTimePickerModified.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerModified.MaximumSize = new System.Drawing.Size(199, 25);
            this.dateTimePickerModified.MinimumSize = new System.Drawing.Size(199, 25);
            this.dateTimePickerModified.Name = "dateTimePickerModified";
            this.dateTimePickerModified.Size = new System.Drawing.Size(199, 25);
            this.dateTimePickerModified.TabIndex = 6;
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(675, 501);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 31);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(784, 501);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 31);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxText.Location = new System.Drawing.Point(16, 121);
            this.textBoxText.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxText.MaximumSize = new System.Drawing.Size(1644, 1519);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(867, 372);
            this.textBoxText.TabIndex = 10;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // comboBox
            // 
            this.comboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.noteBindingSource, "NoteCategory", true));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Work",
            "Home",
            "HealthAndSport",
            "People",
            "Docs",
            "Finance",
            "Other"});
            this.comboBox.Location = new System.Drawing.Point(112, 49);
            this.comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(199, 24);
            this.comboBox.TabIndex = 11;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // noteBindingSource
            // 
            this.noteBindingSource.DataSource = typeof(NoteApp.Note);
            // 
            // projectManagerBindingSource
            // 
            this.projectManagerBindingSource.DataSource = typeof(NoteApp.ProjectManager);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 546);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dateTimePickerModified);
            this.Controls.Add(this.dateTimePickerCreated);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(918, 593);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(918, 593);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add/Edit Note";
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreated;
        private System.Windows.Forms.DateTimePicker dateTimePickerModified;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.BindingSource noteBindingSource;
        private System.Windows.Forms.BindingSource projectManagerBindingSource;
    }
}