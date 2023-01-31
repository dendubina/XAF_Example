using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.EFCore;
using Microsoft.EntityFrameworkCore;
using XAF_Example.Module.Database;

namespace XAF_Example.WebApi.Core;

public sealed class ObjectSpaceProviderFactory : IObjectSpaceProviderFactory
{
    private readonly ITypesInfo _typesInfo;
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public ObjectSpaceProviderFactory(ITypesInfo typesInfo,
        IDbContextFactory<AppDbContext> dbFactory)
    {
        _typesInfo = typesInfo;
        _dbFactory = dbFactory;
    }

    IEnumerable<IObjectSpaceProvider> IObjectSpaceProviderFactory.CreateObjectSpaceProviders()
    {
        yield return new EFCoreObjectSpaceProvider<AppDbContext>(_dbFactory, _typesInfo);
        yield return new NonPersistentObjectSpaceProvider(_typesInfo, null);
    }
}
