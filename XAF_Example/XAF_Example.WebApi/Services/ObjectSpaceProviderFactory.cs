using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.EFCore;
using Microsoft.EntityFrameworkCore;

namespace XAF_Example.WebApi.Core;

public sealed class ObjectSpaceProviderFactory : IObjectSpaceProviderFactory
{
    private readonly ITypesInfo _typesInfo;
    private readonly IDbContextFactory<Module.BusinessObjects.XAF_ExampleEFCoreDbContext> _dbFactory;

    public ObjectSpaceProviderFactory(ITypesInfo typesInfo,
        IDbContextFactory<Module.BusinessObjects.XAF_ExampleEFCoreDbContext> dbFactory)
    {
        _typesInfo = typesInfo;
        _dbFactory = dbFactory;
    }

    IEnumerable<IObjectSpaceProvider> IObjectSpaceProviderFactory.CreateObjectSpaceProviders()
    {
        yield return new EFCoreObjectSpaceProvider<Module.BusinessObjects.XAF_ExampleEFCoreDbContext>(_dbFactory, _typesInfo);
        yield return new NonPersistentObjectSpaceProvider(_typesInfo, null);
    }
}
