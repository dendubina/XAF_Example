using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;

namespace XAF_Example.Win;

[ToolboxItemFilter("Xaf.Platform.Win")]
// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class XAF_ExampleWinModule : ModuleBase
{
    public XAF_ExampleWinModule()
    {
        FormattingProvider.UseMaskSettings = true;
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
