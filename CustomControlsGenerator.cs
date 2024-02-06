namespace TodoList;
public class CustomControlsGenerator
{
    private Form1 _form;
    public CustomControlsGenerator(Form1 form) {
        _form = form;
        }
    public Panel CreateOneTaskPanel(TaskTest task,Panel lastPanel)
    {
        var panel = new Panel();
        panel.Location = new Point(lastPanel.Location.X, lastPanel.Location.Y + 75);
        panel.Name = "oneTaskPanel";
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
        removeButton.Name = "removeButton";
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
        updataButton.Name = "updateButton";
        updataButton.Click += UpdataDescription;
        return updataButton;
    }

    private CheckBox CreateCheckBox(TaskTest task)
    {
        var checkBox = new CheckBox();
        checkBox.Location = new Point(575, 21);
        checkBox.Size = new Size(18, 18);
        checkBox.Name = "isDoneCheckBox";
        checkBox.Checked=task.IsCompleted;
        return checkBox;
    }
    private Label CreateNumLabel(TaskTest task)
    {
        var taskNumberLabel = new Label();
        taskNumberLabel.Location = new Point(11, 21);
        taskNumberLabel.Size = new Size(23, 25);
        taskNumberLabel.Name = "taskNumberLabel";
        taskNumberLabel.Text = task.Id.ToString();
        return taskNumberLabel;
    }
    private Label CreateDescriptionLabel(TaskTest task)
    {
        var descriptionLabel = new Label();
        descriptionLabel.Size = new Size(160, 25);
        descriptionLabel.Location = new Point(165, 20);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Text = task.Description;
        return descriptionLabel;
    }
    private Label CreateDateLabel(TaskTest task)
    {
        var dateLabel = new Label();
        dateLabel.Location = new Point(995, 17);
        dateLabel.Size = new Size(205, 25);
        dateLabel.Text=task.DeadliteDate.ToString("d");
        return dateLabel;
    }
  

    private TextBox CreateDescriptionTextBox(TaskTest task)
    {
        var descriptionTextBox = new TextBox();
        descriptionTextBox.Size = new Size(160, 25);
        descriptionTextBox.Location = new Point(165, 20);
        descriptionTextBox.Name = "descriptionTextBox";
        descriptionTextBox.Text = task.Description;
        descriptionTextBox.Visible = false;
    
        return descriptionTextBox;
    }

    private void RemovePanel(object sender, EventArgs e)
    {
        var button = sender as Button;
        MessageBox.Show(button.Parent.TabIndex.ToString());
        //добавить List<Panel>?? и пересчитывать при удалении позицию всех панелей которые идут после
        _form.Controls.Remove(button.Parent);
        button.Parent.Dispose();

    }
    private void UpdataDescription(object sender, EventArgs e)
    {
        var updateButton = sender as Button;
        var form = updateButton.Parent;
        var descTextBox = form.Controls["descriptionLabel"] as Label;
        var decsTextBox = form.Controls["descriptionTextBox"] as TextBox;
        if (descTextBox.Visible)
        {
            descTextBox.Visible = false;
            decsTextBox.Visible = true;
        }
        else
        {
            descTextBox.Visible = true;
            decsTextBox.Visible = false;
        }
    }
    private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
    {
        //add changing Task at database
        
    }


}

