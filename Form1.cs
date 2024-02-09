using System.Drawing.Text;
using System.Numerics;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;
        CustomControlsGenerator _generator;
        private int _lastId;
        private List<Panel> _panelsList;
        private List<TaskTest> _tasksList;
        public Form1()
        {
            InitializeComponent();
            _lastPanel = mainPanel;
            _panelsList = new List<Panel>();

            _generator = new CustomControlsGenerator();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _tasksList = TodoDatabase.GetAllTask().ToList() ?? new List<TaskTest>();
            foreach (var oneTask in _tasksList)
            {
                var panel = _generator.CreateOneTaskPanel(oneTask, _lastPanel);
                _panelsList.Add(panel);
                _lastPanel = panel;
                Controls.Add(panel);
            }
            _lastId = (_tasksList.Count != 0) ? _tasksList[_tasksList.Count - 1].Id : 0;
 

            _generator.InitServiceFields(this, _tasksList, _panelsList);
        }

        private void CreateOneTask(TaskTest task)
        {
            _tasksList.Add(task);
            TodoDatabase.AddTask(task);
            var panel = _generator.CreateOneTaskPanel(task, _lastPanel);
            _panelsList.Add(panel);
            _lastPanel = panel;
            Controls.Add(panel);


        }
        public void UpdataLastPanel() => _lastPanel = (_panelsList.Count != 0) ? _panelsList[_panelsList.Count - 1] : mainPanel;





        private void button1_Click(object sender, EventArgs e)
        {
            if (TaskValidator.IsValidTask(taskTextBox.Text) && TaskValidator.IsValidDeadlineDate(dateTimePicker.Value))
            {
                var task = new TaskTest()
                {
                    Id = ++_lastId,
                    Description = taskTextBox.Text,
                    IsCompleted = false,
                    DeadliteDate = dateTimePicker.Value.ToString("yyyy-MM-dd")

                };
                CreateOneTask(task);

            }
            else
            {
                taskTextBox.BackColor = Color.Red;
                taskTextBox.Text = "";
            }


        }




        private void taskTextBox_TextChanged(object sender, EventArgs e)
        {
            if (TaskValidator.IsValidTask(taskTextBox.Text) || taskTextBox.Text == "")
            {
                taskTextBox.BackColor = Color.White;

            }
            else
            {
                taskTextBox.BackColor = Color.Red;
            }
        }



    }
}
