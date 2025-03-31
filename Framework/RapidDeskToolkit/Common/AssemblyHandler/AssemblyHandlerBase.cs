using System.Reflection;

namespace RapidDeskToolkit.Common.AssemblyHandler;

public abstract class AssemblyHandlerBase : IAssemblyHandler
{
    public IEnumerable<string> AssemblyPaths { get; set; } = new List<string>() { "./" };

    public void SetAssemblyPaths(IEnumerable<string> paths)
    {
        var result = new List<string> { "./" };
        foreach (var path in paths)
        {
            if (Directory.Exists(path)) result.Add(path);
            else
                throw new DirectoryNotFoundException($"{path}");
        }

        AssemblyPaths = result;
    }

    public void ResolveAssembly()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (_, args) =>
        {
            var assemblyName = $"{new AssemblyName(args.Name).Name}.dll";
            Assembly? assembly = null;
            foreach (var path in AssemblyPaths)
            {
                var assemblyPath = Path.Combine(path, assemblyName);
                if (File.Exists(assemblyPath)) assembly = Assembly.LoadFrom(assemblyPath);
            }

            return assembly;
        };
    }

    public Type? LoadType(string type, string? assemblyName = null)
    {
        if (assemblyName == null) return Type.GetType(type);
        Assembly? assembly = null;
        foreach (var path in AssemblyPaths)
        {
            var assemblyPath = Path.Combine(path, assemblyName);
            if (File.Exists(assemblyPath)) assembly = Assembly.LoadFrom(assemblyPath);
        }

        var result = assembly?.GetTypes().FirstOrDefault(t => t.FullName == type);
        return result;
    }

    public List<string> GetAllAssemblies()
    {
        var result = new List<string>();
        foreach (var path in AssemblyPaths)
        {
            var files = Directory.GetFiles(path, "*.dll");
            // 只存储名称，不记录路径和后缀
            result.AddRange(files.Select(Path.GetFileNameWithoutExtension)!);
        }

        return result;
    }

    public List<Type> GetTypesWithAttribute<T>() where T : Attribute
    {
        var result = new List<Type>();
        foreach (var path in AssemblyPaths)
        {
            var files = Directory.GetFiles(path, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();
                result.AddRange(types.Where(t => t.GetCustomAttribute<T>() != null));
            }
        }

        return result;
    }
}
