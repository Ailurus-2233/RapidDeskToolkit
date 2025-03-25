using RapidDeskToolkit.Common.Container.Attributes;

namespace RapidDeskToolkit.Common.AssemblyHandler;

/// <summary>
///     简单的程序集处理类，用于处理程序集的加载
/// </summary>
[AutoRegister(typeof(IAssemblyHandler), RegisterType.Singleton)]
public class SimpleAssemblyHandler : AssemblyHandlerBase;