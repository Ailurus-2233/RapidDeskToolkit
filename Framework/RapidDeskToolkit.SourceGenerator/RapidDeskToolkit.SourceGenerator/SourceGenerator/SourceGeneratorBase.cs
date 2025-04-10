using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RapidDeskToolkit.SourceGenerator.SourceGenerator;

namespace RapidDeskToolkit.Common.SourceGenerator;

public abstract class SourceGeneratorBase : IIncrementalGenerator
{

    /// <inheritdoc />
    public virtual void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // 步骤1: 收集所有类声明
        var classDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => s is ClassDeclarationSyntax,
                transform: (ctx, _) => GetClassInfo(ctx))
            .Where(classInfo => classInfo.ShouldGenerate); // 筛选需要生成的类

        // 步骤2: 注册代码生成逻辑
        context.RegisterSourceOutput(classDeclarations, (spc, classInfo) =>
        {
            // 调用子类的代码生成方法
            var generatedCode = GenerateCode(classInfo);
            // 自动生成文件名（可自定义）
            var fileName = $"{classInfo.Namespace}_{classInfo.Name}.g.cs";
            // 将生成的代码添加到编译上下文
            spc.AddSource(fileName, SourceText.From(generatedCode, Encoding.UTF8));
        });
    }

    // 子类必须实现的抽象方法 - 实际生成代码的逻辑
    protected abstract string GenerateCode(AutoGenerateClassInfo classInfo);

    protected abstract AutoGenerateClassInfo GetClassInfo(GeneratorSyntaxContext context);
}
