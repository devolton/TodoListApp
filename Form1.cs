using System.Drawing.Text;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;
        CustomControlsGenerator _generator;

        public Form1()
        {
            InitializeComponent();
            _lastPanel = mainPanel;
            _generator = new CustomControlsGenerator();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //загружаются таски

        }

        private void CreateOneTask()
        {
            var task = new TaskTest()
            {
                Id = 2,
                Description = "Create new project",
                IsCompleted = true,
                DeadliteDate = DateTime.Now

            };
            var panel = _generator.CreateOneTaskPanel(task, _lastPanel);
            _lastPanel = panel;
            Controls.Add(panel);





        }




        private void button1_Click(object sender, EventArgs e)
        {
            CreateOneTask();
        }
    }
}
