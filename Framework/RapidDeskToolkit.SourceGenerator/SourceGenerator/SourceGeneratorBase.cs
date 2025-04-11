using Microsoft.CodeAnalysis;

namespace RapidDeskToolkit.SourceGenerator.SourceGenerator;

public abstract class SourceGeneratorBase : IIncrementalGenerator
{

    /// <inheritdoc />
    public virtual void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // 步骤1: 收集所有类声明
        var classDeclarations = GetClassInfo(context);

        // 步骤2: 注册代码生成逻辑
        context.RegisterSourceOutput(classDeclarations, (spc, classInfo) =>
        {
            // 调用子类的代码生成方法
            var generatedCode = classInfo.GenerateCode();
            // 自动生成文件名（可自定义）
            var fileName = $"{classInfo.GeneratedFileName}.g.cs";
            // 将生成的代码添加到编译上下文
            spc.AddSource(fileName, generatedCode);
        });
    }

    protected abstract IncrementalValuesProvider<BaseGenerateClassInfo> GetClassInfo(
        IncrementalGeneratorInitializationContext context);
}