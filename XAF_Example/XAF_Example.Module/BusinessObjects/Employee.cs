using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace XAF_Example.Module.BusinessObjects;

[DefaultClassOptions]
[DefaultProperty(nameof(FullName))]
[ImageName("BO_Person")]
public class Employee : BaseObject
{
    private const string DefaultNameFormat = "{FirstName} {LastName}";
    public string FullName =>
        ObjectFormatter.Format(DefaultNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);

    [VisibleInListView(false)]
    public virtual string FirstName { get; set; }

    [VisibleInListView(false)]
    public virtual string LastName { get; set; }

    public virtual string Email { get; set; }

    public virtual int Age { get; set; }
    
    public virtual DateTime Birthday { get; set; }

    public virtual IList<Task> Tasks { get; set; } = new ObservableCollection<Task>();
}