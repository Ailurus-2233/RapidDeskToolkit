﻿using A6ToolKits.Layout.Generator;
using A6ToolKits.Layout.Helper;
using Avalonia.Controls;
using RapidDeskToolkit.Common.ResourceLoader;

namespace RapidDeskToolkit.Desktop.Controls;

/// <summary>
///     菜单按钮，点击后显示菜单列表
/// </summary>
public partial class MenuIcon : UserControl
{
    /// <summary>
    ///     构造函数
    /// </summary>
    public MenuIcon()
    {
        InitializeComponent();
        var menuItems = MenuBarGenerateHelper.GenerateMenuItems();
        menuItems.ForEach(menuItem =>
        {
            MenuButton.Items.Add(menuItem);
            menuItem.Height = WindowConfig.Instance.MenuHeight;
        });
        if (menuItems.Count > 0) Menu.IsVisible = true;
        if (WindowConfig.Instance.Icon == null) return;
        if (!AssetHelper.TryLoadImage(WindowConfig.Instance.Icon, out var image)) return;
        HeaderIcon.Source = image;
        HeaderIcon.IsVisible = true;
    }
}