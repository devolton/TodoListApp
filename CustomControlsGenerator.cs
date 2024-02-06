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
    public CustomControlsGenerator(Form1 form, List<TaskTest> taskList, List<Panel> panelsList)
    {
        _form = form;
        _tasksList = taskList;
        _panelsList = panelsList;
        _panelName = "oneTaskPanel";
        _taskDescriptionLabelName = "descriptionLabel";
        _taskNumberLabelName = "taskNumberLabel";
        _updataButtonName = "updateButton";
        _removeButtonName = "removeButton";
        _checkBoxName = "isDoneCheckBox";
        _taskDescriptionTextBoxName = "descriptionTextBox";
        _dateLabelName = "dateLabel";
    }
    public Panel CreateOneTaskPanel(TaskTest task, Panel lastPanel)
    {
        var panel = new Panel();
        panel.Location = new Point(lastPanel.Location.X, lastPanel.Location.Y + _PANEL_Y_COORDINATE_STEP);
        panel.Name = _panelName;
        panel.Size = lastPanel.Size;
        panel.TabIndex = task.Id;
        panel.Controls.AddRange(new Control[] { CreateNumLabel(task), CreateDescriptionLabel(task),
            CreateCheckBox(task),CreateRemoveButton(),CreateUpdateButton(),CreateDateLabel(task),CreateDescriptionTextBox(task) });
        return panel;


    }
    private Button CreateRemoveButton()
    {
        var removeButton = new Button();
        removeButton.Location = new Point(742, 17);
        removeButton.Size = new Size(85, 30);
        removeButton.BackColor = Color.Red;
        removeButton.Name = _removeButtonName;
        removeButton.Text = "Remove";
        removeButton.Click += RemovePanel;
        return removeButton;
    }
    private Button CreateUpdateButton()
    {
        var updataButton = new Button();
        updataButton.Location = new Point(835, 17);
        updataButton.Size = new Size(85, 30);
        updataButton.BackColor = Color.Green;
        updataButton.Text = "Update...";
        updataButton.Name = _updataButtonName;
        updataButton.Click += UpdataDescription;
        return updataButton;
    }

    private CheckBox CreateCheckBox(TaskTest task)
    {
        var checkBox = new CheckBox();
        checkBox.Location = new Point(575, 21);
        checkBox.Size = new Size(18, 18);
        checkBox.Name = _checkBoxName;
        checkBox.Checked = task.IsCompleted;
        return checkBox;
    }
    private Label CreateNumLabel(TaskTest task)
    {
        var taskNumberLabel = new Label();
        taskNumberLabel.Location = new Point(11, 21);
        taskNumberLabel.Size = new Size(23, 25);
        taskNumberLabel.Name = _taskNumberLabelName;
        taskNumberLabel.Text = task.Id.ToString();
        return taskNumberLabel;
    }
    private Label CreateDescriptionLabel(TaskTest task)
    {
        var descriptionLabel = new Label();
        descriptionLabel.Size = new Size(160, 25);
        descriptionLabel.Location = new Point(165, 20);
        descriptionLabel.Name = _taskDescriptionLabelName;
        descriptionLabel.Text = task.Description;
        return descriptionLabel;
    }
    private Label CreateDateLabel(TaskTest task)
    {
        var dateLabel = new Label();
        dateLabel.Location = new Point(995, 17);
        dateLabel.Size = new Size(205, 25);
        dateLabel.Name =_dateLabelName;
        dateLabel.Text = task.DeadliteDate.ToString("d");
        return dateLabel;
    }


    private TextBox CreateDescriptionTextBox(TaskTest task)
    {
        var descriptionTextBox = new TextBox();
        descriptionTextBox.Size = new Size(160, 25);
        descriptionTextBox.Location = new Point(165, 20);
        descriptionTextBox.Name = _taskDescriptionTextBoxName;
        descriptionTextBox.Text = task.Description;
        descriptionTextBox.Visible = false;

        return descriptionTextBox;
    }

    private void RemovePanel(object sender, EventArgs e)
    {
        var button = sender as Button;
        var panel = button.Parent as Panel;
        var taskIndex = _panelsList.IndexOf(panel);
        _panelsList.RemoveAt(taskIndex);
        _tasksList.RemoveAt(taskIndex);
        //add delete from database
        _form.Controls.Remove(panel);
        RecalculationNewPanelsLocation(taskIndex);
        OnePanelDispose(panel);

    }
    private void UpdataDescription(object sender, EventArgs e)
    {
        var updateButton = sender as Button;
        var form = updateButton.Parent;
        var descLabel = form.Controls[_taskDescriptionLabelName] as Label;
        var decsTextBox = form.Controls[_taskDescriptionTextBoxName] as TextBox;
        if (descLabel.Visible)
        {
            descLabel.Visible = false;
            decsTextBox.Visible = true;
        }
        else
        {
            descLabel.Visible = true;
            decsTextBox.Visible = false;
        }
    }
    private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
    {
        //add changing Task at database

    }

    private void OnePanelDispose(Panel panel)
    {
        foreach(var control in panel.Controls)
        {
            var oneElement = control as Control;
            oneElement?.Dispose();
        }
        panel.Dispose();
    }
    private void RecalculationNewPanelsLocation(int index)
    {
        for(int i = index; i < _panelsList.Count; i++)
        {
            int currentXCoordinate = _panelsList[i].Location.X;
            int currentYCoordinate = _panelsList[i].Location.Y;
            _panelsList[i].Location = new Point(currentXCoordinate, currentYCoordinate -_PANEL_Y_COORDINATE_STEP);
        }
        
    }


}

