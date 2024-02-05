using System.Drawing.Text;

namespace TodoList
{
    public partial class Form1 : Form
    {
        private Panel _lastPanel;

        public Form1()
        {
            InitializeComponent();
            _lastPanel = todoPanel;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //загружаются таски

        }

        private void CreateOneTask()
        {
            var panel = new Panel();
            panel.Location = new Point(_lastPanel.Location.X, _lastPanel.Location.Y + 75);
            panel.Name = "oneTaskPanel";
            panel.Size = _lastPanel.Size;
            Controls.Add(panel);
            var taskNumberLabel = new Label();
            taskNumberLabel.Location = new Point(11, 21);
            taskNumberLabel.Size = new Size(23, 25);
            taskNumberLabel.Name = "taskNumberLabel";
            taskNumberLabel.Text = "2";
            panel.Controls.Add(taskNumberLabel);
            var descriptionLabel = new Label();
            descriptionLabel.Size = new Size(160, 25);
            descriptionLabel.Location = new Point(165, 20);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Text = "Hello";
            panel.Controls.Add(descriptionLabel);
            var checkBox = new CheckBox();
            checkBox.Location = new Point(575, 21);
            checkBox.Size = new Size(18, 18);
            checkBox.Name = "isDoneCheckBox";
            panel.Controls.Add(checkBox);
            var removeButton = new Button();
            removeButton.Location = new Point(742, 17);
            removeButton.Size = new Size(85, 30);
            removeButton.Name = "removeButton";
            Controls.Add(panel);



        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOneTask();
        }
    }
}
