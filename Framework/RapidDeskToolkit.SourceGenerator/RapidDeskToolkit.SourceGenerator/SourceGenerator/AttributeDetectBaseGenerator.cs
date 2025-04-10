using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RapidDeskToolkit.Common.SourceGenerator;

namespace RapidDeskToolkit.SourceGenerator.SourceGenerator;

public abstract class AttributeDetectBaseGenerator : SourceGeneratorBase
{
    protected abstract string AttributeName { get; }

    /// <inheritdoc />
    public override void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var info = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                AttributeName,
                predicate: static (node, _) => node is ClassDeclarationSyntax
                                               {
                                                   Parent: not ClassDeclarationSyntax
                                               } classDeclarationSyntax
                                               && classDeclarationSyntax.Modifiers.Any(SyntaxKind.PartialKeyword),
                transform: (ctx, token) =>
                {
                    var node = ctx.TargetNode as ClassDeclarationSyntax;
                    var attribute = node?.AttributeLists
                        .SelectMany(x => x.Attributes)
                        .FirstOrDefault(x => x.Name.ToString() == AttributeName);
                    if (attribute == null) return (ctx, null);
                    var argumentSyntax = attribute.ArgumentList?.Arguments.FirstOrDefault();
                    return argumentSyntax is not { Expression: TypeOfExpressionSyntax typeOfExp }
                        ? (ctx, null)
                        : (ctx, typeOfExp.Type);
                }
            ).Where(x => x.Type != null);
    }
}
