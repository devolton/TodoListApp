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
        _panelsList=panelsList;
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

    private CheckBox CreateCheckBox(TaskTest task,Button updateButton)
    {
        var checkBox = new CheckBox();
        checkBox.Location = new Point(575, 21);
        checkBox.Size = new Size(18, 18);
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
        taskNumberLabel.Location = new Point(11, 21);
        taskNumberLabel.Size = new Size(40, 25);
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
        dateLabel.Text = task.DeadliteDate;
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
            else{
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
        confirmButton.Size = new Size(25, 25);
        confirmButton.Location = new Point(340, 20);
        confirmButton.BackColor = Color.White;
        confirmButton.Visible = false;
        confirmButton.FlatStyle = FlatStyle.Flat;
        confirmButton.FlatAppearance.BorderSize = 0;
        confirmButton.Name = _confirmChangesButtonName;
        confirmButton.BackgroundImageLayout = ImageLayout.Stretch;
        confirmButton.BackgroundImage = _confirmButtonBackground;
        confirmButton.Click += (sender, e) =>
        {
        
            var button = sender as Button;
            var panel = button.Parent as Panel;
            var cancelButton = panel.Controls[_cancelChangesButtonName] as Button;
            var descTextBox = panel.Controls[_taskDescriptionTextBoxName] as TextBox;
            var descLabel = panel.Controls[_taskDescriptionLabelName] as Label;
            var updataButton = panel.Controls[_updataButtonName] as Button;
            var removeButton = panel.Controls[_removeButtonName] as Button;
            updataButton.Enabled = true;
            removeButton.Enabled = true;
            task.Description = descTextBox.Text;
            descLabel.Text = task.Description;
            TodoDatabase.UpdateTask(task);
            descTextBox.Visible = false;
            confirmButton.Visible = false;
            cancelButton.Visible = false;
            descLabel.Visible = true;

            
         

        };
        return confirmButton;
    }
    private Button CreateCancelChangesButton(TaskTest task)
    {
        var cancelButton = new Button();
        cancelButton.Size = new Size(25, 25);
        cancelButton.Location = new Point(380, 20);
        cancelButton.BackColor = Color.White;
        cancelButton.Visible = false;
        cancelButton.FlatAppearance.BorderSize = 0;
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.Name = _cancelChangesButtonName;
        cancelButton.BackgroundImage = _cancelButtonBackground;
        cancelButton.BackgroundImageLayout=ImageLayout.Stretch;
        cancelButton.Click += (sender, e) =>
        {
            var button = sender as Button;
            var panel = button.Parent as Panel;
            var descLabel = panel.Controls[_taskDescriptionLabelName] as Label;
            var descTextBox = panel.Controls[_taskDescriptionTextBoxName] as TextBox;
            var confirmButton = panel.Controls[_confirmChangesButtonName] as Button;
            var updataButton = panel.Controls[_updataButtonName] as Button;
            var removeButton = panel.Controls[_removeButtonName] as Button;
            updataButton.Enabled = true;
            removeButton.Enabled = true;
            descLabel.Text = task.Description;
            button.Visible = false;
            descTextBox.Visible = false;
            confirmButton.Visible = false;
            descLabel.Visible = true;


        };
       
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
        var confirmChangesButton = form.Controls[_confirmChangesButtonName] as Button;
        var cancelChangesButton = form.Controls[_cancelChangesButtonName] as Button;
        if (descLabel.Visible)
        {
            confirmChangesButton.Visible = true;
            cancelChangesButton.Visible = true;
            descLabel.Visible = false;
            decsTextBox.Visible = true;
            updateButton.Enabled = false;
            removeButton.Enabled = false;

        }
        else
        {
            cancelChangesButton.Visible = false;
            confirmChangesButton.Visible = false;
            descLabel.Visible = true;
            decsTextBox.Visible = false;
            updateButton.Enabled = true;
            removeButton.Enabled = true;
        }
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

    
 


}

