using System.Threading.Tasks;

namespace TodoList;
public class CustomControlsGenerator
{
    private Form1 _form;
    private List<TaskTest> _tasksList;
    private List<Panel> _panelsList;
    private const int _PANEL_Y_COORDINATE_STEP = 75;
    private readonly string _panelName;
    private readonly string _taskNumberLabelName;
    private readonly string _taskDescriptionLabelName;
    private readonly string _removeButtonName;
    private readonly string _updataButtonName;
    private readonly string _taskDescriptionTextBoxName;
    private readonly string _checkBoxName;
    private readonly string _dateLabelName;
    private readonly string _confirmChangesButtonName;
    private readonly string _cancelChangesButtonName;
    private readonly string _cancelButtonImgPath;
    private Image _cancelButtonBackground;
    private readonly string _confirmButtonImgPath;
    private Image _confirmButtonBackground;
    public CustomControlsGenerator()
    {
        _confirmButtonImgPath = "../../../img/confirmButton.png";
        _cancelButtonImgPath = "../../../img/cancelButton.png";
        _cancelButtonBackground = Image.FromFile(_cancelButtonImgPath);
        _confirmButtonBackground = Image.FromFile(_confirmButtonImgPath);
        _panelName = "oneTaskPanel";
        _taskDescriptionLabelName = "descriptionLabel";
        _taskNumberLabelName = "taskNumberLabel";
        _updataButtonName = "updateButton";
        _removeButtonName = "removeButton";
        _checkBoxName = "isDoneCheckBox";
        _taskDescriptionTextBoxName = "descriptionTextBox";
        _dateLabelName = "dateLabel";
        _confirmChangesButtonName = "confirmChangesButtonName";
        _cancelChangesButtonName = "cancelChangesButtonName";
    }

    public void InitServiceFields(Form1 form, List<TaskTest> taskList, List<Panel> panelsList)
    {
        _form = form;
        _tasksList = taskList;
        _panelsList = panelsList;
    }
    public Panel CreateOneTaskPanel(TaskTest task, Panel lastPanel)
    {
        var panel = new Panel();
        panel.Location = new Point(lastPanel.Location.X, lastPanel.Location.Y + _PANEL_Y_COORDINATE_STEP);
        panel.Name = _panelName;
        panel.Size = lastPanel.Size;
        panel.TabIndex = task.Id;
        if (task.IsCompleted)
        {
            panel.BackColor = Color.YellowGreen;

        }
        var updateButton = CreateUpdateButton();
        panel.Controls.AddRange(new Control[] { CreateNumLabel(task), CreateDescriptionLabel(task),
            CreateRemoveButton(),updateButton,CreateDateLabel(task),
            CreateDescriptionTextBox(task),CreateCancelChangesButton(task),CreateConfirmChangesButton(task),CreateCheckBox(task,updateButton) });
        return panel;


    }
    private Button CreateRemoveButton()
    {
        var removeButton = new Button();
        removeButton.Location = new Point(742, 30);
        StylizingCommonButtonProp(removeButton, _removeButtonName);
        removeButton.Click += RemovePanel;
        return removeButton;
    }
    private Button CreateUpdateButton()
    {
        var updataButton = new Button();
        updataButton.Location = new Point(835, 30);
        StylizingCommonButtonProp(updataButton, _updataButtonName);
        updataButton.Click += UpdataDescription;
        return updataButton;
    }

    private CheckBox CreateCheckBox(TaskTest task, Button updateButton)
    {
        var checkBox = new CheckBox();
        checkBox.Location = new Point(570, 40);
        checkBox.Name = _checkBoxName;
        checkBox.Checked = task.IsCompleted;
        if (checkBox.Checked)
        {
            checkBox.Enabled = false;
            updateButton.Enabled = false;
        }
        checkBox.CheckedChanged += CheckedChanged;
        return checkBox;
    }
    private Label CreateNumLabel(TaskTest task)
    {
        var taskNumberLabel = new Label();
        taskNumberLabel.Location = new Point(17, 33);
        taskNumberLabel.Size = new Size(40, 25);
        taskNumberLabel.Name = _taskNumberLabelName;
        taskNumberLabel.Text = task.Id.ToString();
        taskNumberLabel.Font = new Font("Georgia", 12, FontStyle.Regular);
        taskNumberLabel.ForeColor = Color.BlanchedAlmond;
        return taskNumberLabel;
    }
    private Label CreateDescriptionLabel(TaskTest task)
    {
        var descriptionLabel = new Label();
        descriptionLabel.Size = new Size(300, 60);
        descriptionLabel.Location = new Point(120, 20);
        descriptionLabel.Name = _taskDescriptionLabelName;
        descriptionLabel.Text = task.Description;
        descriptionLabel.Font = new Font("Georgia", 10, FontStyle.Regular);
        descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
        return descriptionLabel;
    }
    private Label CreateDateLabel(TaskTest task)
    {
        var dateLabel = new Label();
        dateLabel.Location = new Point(1000, 17);
        dateLabel.Size = new Size(205, 60);
        dateLabel.Name = _dateLabelName;
        dateLabel.Text = task.DeadliteDate;
        dateLabel.TextAlign = ContentAlignment.MiddleCenter;
        dateLabel.Font = new Font("Georgia", 12, FontStyle.Regular);
        dateLabel.ForeColor = Color.BlanchedAlmond;
        return dateLabel;
    }


    private TextBox CreateDescriptionTextBox(TaskTest task)
    {
        var descriptionTextBox = new TextBox();
        descriptionTextBox.Size = new Size(200, 35);
        descriptionTextBox.Location = new Point(165, 30);
        descriptionTextBox.Name = _taskDescriptionTextBoxName;
        descriptionTextBox.Text = task.Description;
        descriptionTextBox.Font = new Font("Georgia", 12);

        descriptionTextBox.Visible = false;
        descriptionTextBox.TextChanged += (sender, e) =>
        {
            var descriptionTextBox = sender as TextBox;
            var panel = descriptionTextBox.Parent as Panel;
            var confirmButton = panel.Controls[_confirmChangesButtonName];

            if (TaskValidator.IsValidTask(descriptionTextBox.Text))
            {
                descriptionTextBox.BackColor = Color.White;
                confirmButton.Enabled = true;
                descriptionTextBox.ForeColor = Color.Black;

            }
            else
            {
                confirmButton.Enabled = false;
                descriptionTextBox.BackColor = Color.Red;
                descriptionTextBox.ForeColor = Color.White;

            }
        };

        return descriptionTextBox;
    }
    private Button CreateConfirmChangesButton(TaskTest task)
    {
        var confirmButton = new Button();
        confirmButton.Location = new Point(377, 32);
        StylizingChangeButton(confirmButton, _confirmChangesButtonName);
        confirmButton.Click += ClickCancelOrConfirmButton;
        return confirmButton;
    }
    private Button CreateCancelChangesButton(TaskTest task)
    {
        var cancelButton = new Button();
        cancelButton.Location = new Point(410, 32);
        StylizingChangeButton(cancelButton, _cancelChangesButtonName);
        cancelButton.Click += ClickCancelOrConfirmButton;

        return cancelButton;
    }

    private void RemovePanel(object sender, EventArgs e)
    {
        var button = sender as Button;
        var panel = button.Parent as Panel;
        var taskIndex = _panelsList.IndexOf(panel);
        _panelsList.RemoveAt(taskIndex);
        TodoDatabase.RemoveTaskById(_tasksList[taskIndex].Id);
        _tasksList.RemoveAt(taskIndex);
        _form.Controls.Remove(panel);
        RecalculationNewPanelsLocation(taskIndex);
        _form.UpdataLastPanel();
        OnePanelDispose(panel);

    }
    private void UpdataDescription(object sender, EventArgs e)
    {
        var updateButton = sender as Button;
        var form = updateButton.Parent;
        var removeButton = form.Controls[_removeButtonName] as Button;
        var descLabel = form.Controls[_taskDescriptionLabelName] as Label;
        var decsTextBox = form.Controls[_taskDescriptionTextBoxName] as TextBox;
        var checkBox = form.Controls[_checkBoxName] as CheckBox;
        var confirmChangesButton = form.Controls[_confirmChangesButtonName] as Button;
        var cancelChangesButton = form.Controls[_cancelChangesButtonName] as Button;
        confirmChangesButton.Visible = true;
        cancelChangesButton.Visible = true;
        descLabel.Visible = false;
        decsTextBox.Visible = true;
        updateButton.Enabled = false;
        removeButton.Enabled = false;
        checkBox.Enabled = false;


    }

    private void OnePanelDispose(Panel panel)
    {
        foreach (var control in panel.Controls)
        {
            var oneElement = control as Control;
            oneElement?.Dispose();
        }
        panel.Dispose();
    }
    private void RecalculationNewPanelsLocation(int index)
    {
        for (int i = index; i < _panelsList.Count; i++)
        {
            int currentXCoordinate = _panelsList[i].Location.X;
            int currentYCoordinate = _panelsList[i].Location.Y;
            _panelsList[i].Location = new Point(currentXCoordinate, currentYCoordinate - _PANEL_Y_COORDINATE_STEP);
        }

    }
    private void CheckedChanged(object sender, EventArgs e)
    {
        var checkBox = sender as CheckBox;
        var panel = checkBox.Parent as Panel;
        var updataButton = panel.Controls[_updataButtonName];
        var taskIndex = _panelsList.IndexOf(panel);
        _tasksList[taskIndex].IsCompleted = true;
        updataButton.Enabled = false;
        checkBox.Enabled = false;
        panel.BackColor = Color.YellowGreen;
        TodoDatabase.UpdateTask(_tasksList[taskIndex]);
    }
    private void StylizingCommonButtonProp(Button button, string buttonName)
    {
        button.Size = new Size(85, 40);
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Font = new Font("Impact", 10);
        if (buttonName == _removeButtonName)
        {
            button.Text = "Remove";
            button.BackColor = Color.Red;
            button.Name = _removeButtonName;
        }
        else
        {
            button.BackColor = Color.Green;
            button.Text = "Updata";
            button.Name = _updataButtonName;
        }

    }

    private void StylizingChangeButton(Button button, string buttonName)
    {
        button.Size = new Size(25, 25);
        button.BackColor = Color.White;
        button.Visible = false;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackgroundImageLayout = ImageLayout.Stretch;
        if (buttonName == _confirmChangesButtonName)
        {
            button.Name = _confirmChangesButtonName;
            button.BackgroundImage = _confirmButtonBackground;
        }
        else
        {
            button.Name = _cancelChangesButtonName;
            button.BackgroundImage = _cancelButtonBackground;
        }

    }
    private void ClickCancelOrConfirmButton(object sender, EventArgs e)
    {

        var button = sender as Button;
        var panel = button.Parent as Panel;
        var taskIndex = _panelsList.IndexOf(panel);
        var checkBox = panel.Controls[_checkBoxName] as CheckBox;
        var cancelButton = panel.Controls[_cancelChangesButtonName] as Button;
        var descTextBox = panel.Controls[_taskDescriptionTextBoxName] as TextBox;
        var descLabel = panel.Controls[_taskDescriptionLabelName] as Label;
        var updataButton = panel.Controls[_updataButtonName] as Button;
        var removeButton = panel.Controls[_removeButtonName] as Button;
        checkBox.Enabled = true;
        updataButton.Enabled = true;
        removeButton.Enabled = true;
        if (button.Name == _confirmChangesButtonName)
        {
            _tasksList[taskIndex].Description = descTextBox.Text;
            descLabel.Text = _tasksList[taskIndex].Description;
            TodoDatabase.UpdateTask(_tasksList[taskIndex]);
        }
        else
        {
            descLabel.Text = _tasksList[taskIndex].Description;
        }
        descTextBox.Visible = false;
        button.Visible = false;
        cancelButton.Visible = false;
        descLabel.Visible = true;
    }




}

