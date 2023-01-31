using Bogus;
using XAF_Example.Module.BusinessObjects;
using Task = XAF_Example.Module.BusinessObjects.Task;
using TaskStatus = XAF_Example.Module.BusinessObjects.TaskStatus;

namespace XAF_Example.Module.Database.Config;

internal static class DataInitializer
{
    public static IEnumerable<Employee> Employees { get; }
    public static IEnumerable<Task> Tasks { get; }

    static DataInitializer()
    {
        Randomizer.Seed = new Random(35566);

        Employees = new Faker<Employee>("ru")
            .RuleFor(x => x.ID, f => f.Random.Guid())
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Age, f => f.Random.Int(1, 65))
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.Birthday, f => f.Date.Past())
            .Generate(20);

        Tasks = new Faker<Task>("ru")
            .RuleFor(x => x.ID, f => f.Random.Guid())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.Status, f => f.PickRandom<TaskStatus>())
            .RuleFor(x => x.AssignedToId, f => f.PickRandom(Employees.Select(x => x.ID)))
            .Generate(100);
    }
}