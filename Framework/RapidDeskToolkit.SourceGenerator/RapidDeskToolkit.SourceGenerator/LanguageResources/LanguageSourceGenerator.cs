using System.Globalization;
using System.Linq;
using Avalonia.Controls;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RapidDeskToolkit.Common.SourceGenerator;
using RapidDeskToolkit.SourceGenerator.SourceGenerator;

namespace RapidDeskToolkit.SourceGenerator.LanguageResources;

[Generator(LanguageNames.CSharp)]
public class LanguageSourceGenerator : SourceGeneratorBase
{
    private static readonly string Attribute = $"{typeof(LanguageTargetAttribute).FullName}";
    private static readonly string CultureInfo = $"global::{typeof(CultureInfo).FullName}";
    private static readonly string ResourceProvider = $"global::{typeof(ResourceProvider).FullName}";
    private static readonly string IEnumerable = $"global::{nameof(System)}.Collections.Generic.IEnumerable<string>";

    private static readonly string[] Exceptions =
    [
        "ResourceManager",
        "Culture"
    ];

    /// <inheritdoc />
    protected override string GenerateCode(AutoGenerateClassInfo classInfo)
    {
        return "";
    }

    /// <inheritdoc />
    protected override AutoGenerateClassInfo GetClassInfo(GeneratorSyntaxContext context)
    {
        var classDeclaration = (ClassDeclarationSyntax)context.Node;
        var semanticModel = context.SemanticModel;
        var classSymbol = ModelExtensions.GetDeclaredSymbol(semanticModel, classDeclaration)!;

        // 检查类是否有 LanguageTargetAttribute 特性
        var hasAttribute = classSymbol.GetAttributes()
            .Any(attr => attr.AttributeClass?.ToDisplayString() == Attribute);

        // 获取类名和命名空间
        var className = classSymbol.Name;
        var classNamespace = classSymbol.ContainingNamespace.ToDisplayString();

        // 返回类信息
        return new AutoGenerateClassInfo
        {
            Name = className,
            Namespace = classNamespace,
            ShouldGenerate = hasAttribute,
            Context = context
        };
    }
}
