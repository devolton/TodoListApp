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
            label1 = new Label();
            taskTextBox = new TextBox();
            checkBox1 = new CheckBox();
            addTaskButton = new Button();
            dateTimePicker = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button2 = new Button();
            button3 = new Button();
            label10 = new Label();
            todoPanel = new Panel();
            mainPanel = new Panel();
            todoPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(479, -4);
            label1.Name = "label1";
            label1.Size = new Size(337, 71);
            label1.TabIndex = 0;
            label1.Text = "To Do List";
            // 
            // taskTextBox
            // 
            taskTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            taskTextBox.Location = new Point(266, 95);
            taskTextBox.Margin = new Padding(3, 4, 3, 4);
            taskTextBox.Multiline = true;
            taskTextBox.Name = "taskTextBox";
            taskTextBox.Size = new Size(613, 45);
            taskTextBox.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(574, 21);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 2;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // addTaskButton
            // 
            addTaskButton.BackColor = Color.Green;
            addTaskButton.Location = new Point(887, 95);
            addTaskButton.Margin = new Padding(3, 4, 3, 4);
            addTaskButton.Name = "addTaskButton";
            addTaskButton.Size = new Size(86, 47);
            addTaskButton.TabIndex = 3;
            addTaskButton.Text = "Add";
            addTaskButton.UseVisualStyleBackColor = false;
            addTaskButton.Click += button1_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(985, 100);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(228, 27);
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
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 18);
            label3.Name = "label3";
            label3.Size = new Size(43, 32);
            label3.TabIndex = 6;
            label3.Text = "№";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(160, 18);
            label4.Name = "label4";
            label4.Size = new Size(157, 32);
            label4.TabIndex = 7;
            label4.Text = "Descriptions";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(541, 18);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 8;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(793, 18);
            label6.Name = "label6";
            label6.Size = new Size(100, 32);
            label6.TabIndex = 9;
            label6.Text = "Actions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1068, 18);
            label7.Name = "label7";
            label7.Size = new Size(67, 32);
            label7.TabIndex = 10;
            label7.Text = "Date";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(12, 23);
            label8.Name = "label8";
            label8.Size = new Size(23, 25);
            label8.TabIndex = 11;
            label8.Text = "1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(163, 21);
            label9.Name = "label9";
            label9.Size = new Size(154, 25);
            label9.TabIndex = 12;
            label9.Text = "Вынести мусор";
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Location = new Point(742, 17);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 13;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Green;
            button3.Location = new Point(834, 17);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 14;
            button3.Text = "Execute";
            button3.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.DarkSeaGreen;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(994, 15);
            label10.Name = "label10";
            label10.Size = new Size(207, 25);
            label10.TabIndex = 15;
            label10.Text = "пятница. 14 февраля";
            // 
            // todoPanel
            // 
            todoPanel.Controls.Add(label9);
            todoPanel.Controls.Add(label10);
            todoPanel.Controls.Add(label8);
            todoPanel.Controls.Add(button3);
            todoPanel.Controls.Add(checkBox1);
            todoPanel.Controls.Add(button2);
            todoPanel.Location = new Point(2, 229);
            todoPanel.Margin = new Padding(3, 4, 3, 4);
            todoPanel.Name = "todoPanel";
            todoPanel.Size = new Size(1231, 68);
            todoPanel.TabIndex = 16;
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
            mainPanel.Size = new Size(1231, 68);
            mainPanel.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1227, 832);
            Controls.Add(mainPanel);
            Controls.Add(todoPanel);
            Controls.Add(label2);
            Controls.Add(dateTimePicker);
            Controls.Add(addTaskButton);
            Controls.Add(taskTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            todoPanel.ResumeLayout(false);
            todoPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox taskTextBox;
        private CheckBox checkBox1;
        private Button addTaskButton;
        private DateTimePicker dateTimePicker;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button2;
        private Button button3;
        private Label label10;
        private Panel todoPanel;
        private Panel mainPanel;
    }
}

