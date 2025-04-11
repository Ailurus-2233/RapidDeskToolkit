using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RapidDeskToolkit.Common.Language;
using RapidDeskToolkit.SourceGenerator.SourceGenerator;

namespace RapidDeskToolkit.SourceGenerator.LanguageResources;

[Generator]
public class LanguageSourceGenerator : SourceGeneratorBase
{
    private static readonly string Attribute = $"{typeof(LanguageTargetAttribute).FullName}";

    /// <inheritdoc />
    protected override IncrementalValuesProvider<BaseGenerateClassInfo> GetClassInfo(
        IncrementalGeneratorInitializationContext context)
    {
        return context.SyntaxProvider.ForAttributeWithMetadataName(
            Attribute,
            predicate: static (node, _) =>
                node is ClassDeclarationSyntax { Parent: not ClassDeclarationSyntax } classDeclarationSyntax
                && classDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword),
            transform: (ctx, _) =>
            {
                var disableResult = new LanguageGenerateClassInfo
                {
                    ShouldGenerate = false,
                    GeneratedFileName = "Fail"
                };
                if (ctx.TargetNode is not ClassDeclarationSyntax node) return disableResult;
                var attribute = node.GetSpecifiedAttribute(ctx.SemanticModel, Attribute);
                var argumentSyntax = attribute?.ArgumentList?.Arguments.FirstOrDefault();
                if (argumentSyntax?.Expression is not TypeOfExpressionSyntax typeOfExp) return disableResult;
                var type = typeOfExp.Type;
                var className = ctx.TargetSymbol.Name;
                var classNamespace =
                    ctx.TargetSymbol.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                BaseGenerateClassInfo result = new LanguageGenerateClassInfo
                {
                    DesignerType = type,
                    GenerateCtx = ctx,
                    ShouldGenerate = true,
                    GeneratedFileName = $"{classNamespace}_{className}_LanguageProvider.g.cs",
                };
                return result;
            }
        ).Where(x => x.ShouldGenerate);
    }
}
