﻿using A6ToolKits.Helper.Instance;
using A6ToolKits.Module;
using Avalonia;
using Avalonia.Markup.Xaml.Styling;

namespace A6ToolKits.UIPackage;

public class UIPackageModule : ModuleBase
{
    public override IInstanceHelper? Creator { get; set; } = new BaseInstanceHelper();
    public override string ModuleName { get; set; } = "A6ToolKits.UIPackage";
    public override string ModuleVersion { get; set; } = "1.0.0";

    public override string ModuleDescription { get; set; } =
        "Provides custom control theme and resources for A6Toolkits and applications";

    protected override void Initialize()
    {
        // var styleUri = new Uri("avares://A6ToolKits.UIPackage/UIPackageStyles.axaml");
        // var style = new StyleInclude(styleUri)
        // {
        //     Source = styleUri
        // };
        // Application.Current?.Styles.Add(style);
        
        var resUri = new Uri("avares://A6ToolKits.UIPackage/UIPackageResources.axaml");
        var resource = new ResourceInclude(resUri)
        {
            Source = resUri
        };

        Application.Current?.Resources.MergedDictionaries.Add(resource);
    }
}