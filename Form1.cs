using System.Drawing.Text;
using System.Numerics;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;
        CustomControlsGenerator _generator;
        private int _lastId = 0;
        private List<Panel> _panelsList;
        private List<TaskTest> _taskList;

        private List<TaskTest> _tasks;
        public Form1()
        {
            InitializeComponent();
            _lastPanel = mainPanel;
            _panelsList = new List<Panel>();
            _taskList = new List<TaskTest>();
            _generator = new CustomControlsGenerator(this, _taskList, _panelsList);



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _tasks = TodoDatabase.GetAllTask().ToList();
            PrintTask(_tasks);
        }

        private void CreateOneTask(TaskTest task)
        {
            _taskList.Add(task);
            var panel = _generator.CreateOneTaskPanel(task, _lastPanel);
            _panelsList.Add(panel);
            _lastPanel = panel;
            Controls.Add(panel);


        }
        public void UpdataLastPanel()=>_lastPanel=(_panelsList.Count != 0) ? _panelsList[_panelsList.Count - 1] : mainPanel;
        




        private void button1_Click(object sender, EventArgs e)
        {
            if (TaskValidator.IsValidTask(taskTextBox.Text) && TaskValidator.IsValidDeadlineDate(dateTimePicker.Value))
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


        private void PrintTask(IEnumerable<TaskTest> task)
        {
            foreach (var t in task)
            {
                MessageBox.Show(($" {t.Id} {t.Description} {t.IsCompleted} {t.DeadliteDate}"));
            }
        }
    }
}
