using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace XAF_Example.Blazor.Server;

[ToolboxItemFilter("Xaf.Platform.Blazor")]
// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class XAF_ExampleBlazorModule : ModuleBase
{
    public XAF_ExampleBlazorModule()
    {
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    {
        return ModuleUpdater.EmptyModuleUpdaters;
    }

    public override void Setup(XafApplication application)
    {
        base.Setup(application);
    }
}
