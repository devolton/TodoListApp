using System.Drawing.Text;
using System.Numerics;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;
        CustomControlsGenerator _generator;
        private int _lastId = 0;

        private List<TaskTest> _tasks;
        public Form1()
        {
            InitializeComponent();
            _lastPanel = mainPanel;
            _generator = new CustomControlsGenerator(this);


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _tasks = TodoDatabase.GetAllTask().ToList();
            PrintTask(_tasks);
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


        private void PrintTask(IEnumerable<TaskTest> task)
        {
            foreach (var t in task)
            {
                MessageBox.Show(($" {t.Id} {t.Description} {t.IsCompleted} {t.DeadliteDate}"));
            }
        }
    }
}
