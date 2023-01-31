using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using XAF_Example.Module.BusinessObjects;

namespace XAF_Example.Module.Controllers;

public class ClearTasksController : ViewController
{
    public ClearTasksController()
    {
        TargetViewType = ViewType.DetailView;
        TargetObjectType = typeof(Employee);

        var action = new SimpleAction(this, "ClearTasks", PredefinedCategory.View)
        {
            Caption = "Clear tasks",
            ConfirmationMessage = "Are you sure you want to clear the Tasks list?",
            ImageName = "Action_Clear"
        };

        action.Execute += ClearTasksAction;
    }

    private void ClearTasksAction(object sender, SimpleActionExecuteEventArgs e)
    {
        var employee = View.CurrentObject as Employee;

        while (employee!.Tasks.Count > 0)
        {
            employee.Tasks.Remove(employee.Tasks[0]);
        }

        View.ObjectSpace.CommitChanges();
        View.ObjectSpace.Refresh();
    }
}