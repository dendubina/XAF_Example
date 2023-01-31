using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;

namespace XAF_Example.Module.BusinessObjects;

[DefaultClassOptions]
[ImageName("BO_Task")]
public class Task : BaseObject
{
    [Size(SizeAttribute.Unlimited)]
    public virtual string Description { get; set; }

    public virtual TaskStatus Status { get; set; }

    public virtual Employee AssignedTo { get; set; }

    [ForeignKey(nameof(AssignedTo))]
    [Browsable(false)]
    public virtual Guid AssignedToId { get; set; }
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
}