using System.Drawing.Text;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;
        CustomControlsGenerator _generator;
        private int _lastId = 0;

        public Form1()
        {
            InitializeComponent();
            _lastPanel = mainPanel;
            _generator = new CustomControlsGenerator(this);


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //загружаются таски
            TodoDatabase.UpdateTask(new TaskTest
            {
                Id = 1,
                Description = "rabotaet?",
                IsCompleted = false
            });
        }

        private void CreateOneTask(TaskTest task)
        {
          
            var panel = _generator.CreateOneTaskPanel(task, _lastPanel);
            _lastPanel = panel;
            Controls.Add(panel);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if(TaskValidator.IsValidTask(taskTextBox.Text))
            {

                var task = new TaskTest()
                {
                    Id = ++_lastId,
                    Description = taskTextBox.Text,
                    IsCompleted = false,
                    DeadliteDate = dateTimePicker.Value

                };


                CreateOneTask(task);
            }
            else
            {
                taskTextBox.BackColor = Color.Red;
            }
         
                
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            MessageBox.Show(dateTimePicker.Value.ToString("d"));
        }
    }
}
