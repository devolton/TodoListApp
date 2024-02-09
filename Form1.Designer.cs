using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TodoList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            taskTextBox = new TextBox();
            addTaskButton = new Button();
            dateTimePicker = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            mainPanel = new Panel();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(479, 9);
            label1.Name = "label1";
            label1.Size = new Size(337, 71);
            label1.TabIndex = 0;
            label1.Text = "To Do List";
            // 
            // taskTextBox
            // 
            taskTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            taskTextBox.Location = new Point(123, 95);
            taskTextBox.Margin = new Padding(3, 4, 3, 4);
            taskTextBox.Multiline = true;
            taskTextBox.Name = "taskTextBox";
            taskTextBox.PlaceholderText = "Task...";
            taskTextBox.Size = new Size(735, 45);
            taskTextBox.TabIndex = 1;
            taskTextBox.TextChanged += taskTextBox_TextChanged;
            // 
            // addTaskButton
            // 
            addTaskButton.BackColor = Color.Green;
            addTaskButton.FlatAppearance.BorderSize = 0;
            addTaskButton.FlatStyle = FlatStyle.Flat;
            addTaskButton.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            addTaskButton.ForeColor = SystemColors.Info;
            addTaskButton.Location = new Point(856, 95);
            addTaskButton.Margin = new Padding(3, 4, 3, 4);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(144, 45);
            addTaskButton.TabIndex = 3;
            addTaskButton.Text = "Add";
            addTaskButton.UseVisualStyleBackColor = false;
            addTaskButton.Click += button1_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(1036, 104);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(160, 27);
            dateTimePicker.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(2, 205);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.Location = new Point(12, 18);
            label3.Name = "label3";
            label3.Size = new Size(42, 31);
            label3.TabIndex = 6;
            label3.Text = "№";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label4.Location = new Point(201, 18);
            label4.Name = "label4";
            label4.Size = new Size(148, 31);
            label4.TabIndex = 7;
            label4.Text = "Descriptions";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label5.Location = new Point(541, 18);
            label5.Name = "label5";
            label5.Size = new Size(80, 31);
            label5.TabIndex = 8;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(793, 18);
            label6.Name = "label6";
            label6.Size = new Size(95, 31);
            label6.TabIndex = 9;
            label6.Text = "Actions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label7.Location = new Point(1053, 18);
            label7.Name = "label7";
            label7.Size = new Size(109, 31);
            label7.TabIndex = 10;
            label7.Text = "Deadline";
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(label7);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(label6);
            mainPanel.Location = new Point(2, 147);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1231, 89);
            mainPanel.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1227, 803);
            Controls.Add(mainPanel);
            Controls.Add(label2);
            Controls.Add(dateTimePicker);
            Controls.Add(addTaskButton);
            Controls.Add(taskTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox taskTextBox;
        private Button addTaskButton;
        private DateTimePicker dateTimePicker;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Panel mainPanel;
    }
}

