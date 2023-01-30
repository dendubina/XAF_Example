using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace XAF_Example.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class XAF_ExampleContextInitializer : DbContextTypesInfoInitializerBase
{
    protected override DbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<XAF_ExampleEFCoreDbContext>()
            .UseInMemoryDatabase("InMemory")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();

        return new XAF_ExampleEFCoreDbContext(optionsBuilder.Options);
    }
}

//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class XAF_ExampleDesignTimeDbContextFactory : IDesignTimeDbContextFactory<XAF_ExampleEFCoreDbContext>
{
    public XAF_ExampleEFCoreDbContext CreateDbContext(string[] args)
    {
        throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        //var optionsBuilder = new DbContextOptionsBuilder<XAF_ExampleEFCoreDbContext>();
        //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=XAF_Example");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
        //return new XAF_ExampleEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(XAF_ExampleContextInitializer))]

public class XAF_ExampleEFCoreDbContext : DbContext
{
    public XAF_ExampleEFCoreDbContext(DbContextOptions<XAF_ExampleEFCoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
    }
}
