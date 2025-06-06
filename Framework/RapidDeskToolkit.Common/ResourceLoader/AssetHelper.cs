﻿using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Svg;
using RapidDeskToolkit.Common.ResourceLoader.Exceptions;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace RapidDeskToolkit.Common.ResourceLoader;

/// <summary>
///     资源帮助类
/// </summary>
public static class AssetHelper
{
    /// <summary>
    ///     从 Avalonia应用资源 中加载图片
    /// </summary>
    /// <param name="resourceUri">
    ///     资源 URI
    /// </param>
    /// <returns>
    ///     返回图片
    /// </returns>
    public static IImage LoadImage(Uri resourceUri)
    {
        using var stream = AssetLoader.Open(resourceUri);
        if (stream == null)
            throw new AssetNotFoundException(resourceUri);
        return new Bitmap(stream);
    }

    /// <summary>
    ///     尝试从 Avalonia应用资源 中加载图片
    /// </summary>
    /// <param name="resourceUri">
    ///     资源 URI
    /// </param>
    /// <param name="image">
    ///     获得的图片
    /// </param>
    /// <returns>
    ///     返回是否加载成功
    /// </returns>
    public static bool TryLoadImage(Uri resourceUri, out IImage? image)
    {
        try
        {
            var type = resourceUri.AbsoluteUri.Split('.').Last();
            image = type == "svg" ? LoadSvgImage(resourceUri) : LoadImage(resourceUri);
            return true;
        }
        catch (AssetNotFoundException)
        {
            image = null;
            return false;
        }
    }

    /// <summary>
    ///     从 Avalonia应用资源 中加载 SVG 图片
    /// </summary>
    /// <param name="resourceUri">
    ///     资源 URI
    /// </param>
    /// <returns>
    ///     返回图片
    /// </returns>
    public static IImage LoadSvgImage(Uri resourceUri)
    {
        using var stream = AssetLoader.Open(resourceUri);
        if (stream == null)
            throw new AssetNotFoundException(resourceUri);
        return new SvgImage { Source = SvgSource.Load(stream) };
    }


    /// <summary>
    ///     从 网络地址 加载图片
    /// </summary>
    /// <param name="uri">
    ///     网络地址
    /// </param>
    /// <returns>
    ///     返回图片的异步任务
    /// </returns>
    public static async Task<Bitmap?> LoadFromWeb(Uri? uri)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));
            throw new AssetNotFoundException(uri);
        }
    }
}
