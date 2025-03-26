namespace RapidDeskToolkit.Common.AssemblyHandler;

/// <summary>
///     程序集处理器接口
/// </summary>
public interface IAssemblyHandler
{
    /// <summary>
    ///     程序集路径
    /// </summary>
    IEnumerable<string> AssemblyPaths { get; set; }


    void SetAssemblyPaths(IEnumerable<string> paths);

    /// <summary>
    ///     接管 AppDomain 解析程序集
    /// </summary>
    void ResolveAssembly();

    /// <summary>
    ///     根据程序集名称和类型名称加载类型
    /// </summary>
    /// <param name="type">
    ///     类型名称
    /// </param>
    /// <param name="assemblyName">
    ///     程序集名称
    /// </param>
    /// <returns>
    ///     返回加载的类型
    /// </returns>
    Type? LoadType(string type, string? assemblyName = null);

    /// <summary>
    ///     获取所有程序集名称
    /// </summary>
    /// <returns>
    ///     返回所有程序集
    /// </returns>
    List<string> GetAllAssemblies();

    /// <summary>
    ///     获取所有包含指定特性的类型
    /// </summary>
    /// <typeparam name="T">
    ///     特性类型
    /// </typeparam>
    /// <returns>
    ///     返回包含指定特性的类型
    /// </returns>
    List<Type> GetTypesWithAttribute<T>() where T : Attribute;
}
