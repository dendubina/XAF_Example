using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Win.ApplicationBuilder;
using DevExpress.ExpressApp.Win;
using Microsoft.EntityFrameworkCore;
using DevExpress.ExpressApp.Design;
using XAF_Example.Module;
using XAF_Example.Module.BusinessObjects;

namespace XAF_Example.Win;

public class ApplicationBuilder : IDesignTimeApplicationFactory
{
    public static WinApplication BuildApplication(string connectionString)
    {
        var builder = WinApplication.CreateBuilder();
        builder.UseApplication<XAF_ExampleWindowsFormsApplication>();
        builder.Modules
            .AddValidation(options =>
            {
                options.AllowValidationDetailsAccess = false;
            })
            .Add<XAF_ExampleModule>()
                        .Add<XAF_ExampleWinModule>();
        builder.ObjectSpaceProviders
            .AddEFCore()
            .WithDbContext<XAF_ExampleEFCoreDbContext>((application, options) =>
            {
                options.UseInMemoryDatabase("InMemory");

                options.UseChangeTrackingProxies();
                options.UseObjectSpaceLinkProxies();
            })
            .AddNonPersistent();

        builder.AddBuildStep(application =>
        {
            application.ConnectionString = connectionString;
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached && application.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
            {
                application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
#endif
        });
        var winApplication = builder.Build();
        return winApplication;
    }

    XafApplication IDesignTimeApplicationFactory.Create()
        => BuildApplication(XafApplication.DesignTimeConnectionString);
}
