using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RapidDeskToolkit.SourceGenerator.SourceGenerator;

public static class SourceGeneratorExtension
{
    public static IEnumerable<AttributeSyntax> GetAllAttributes(this SyntaxNode syntax)
    {
        var attributeLists = syntax switch
        {
            CompilationUnitSyntax compilationUnitSyntax => compilationUnitSyntax.AttributeLists,
            MemberDeclarationSyntax memberDeclarationSyntax => memberDeclarationSyntax.AttributeLists,
            LambdaExpressionSyntax lambdaExpressionSyntax => lambdaExpressionSyntax.AttributeLists,
            BaseParameterSyntax baseParameterSyntax => baseParameterSyntax.AttributeLists,
            StatementSyntax statementSyntax => statementSyntax.AttributeLists,
            _ => throw new NotSupportedException($"{syntax.GetType()} has no attribute")
        };
        return attributeLists.SelectMany(attributeListSyntax => attributeListSyntax.Attributes);
    }

    public static IEnumerable<AttributeSyntax> GetSpecifiedAttributes(
        this SyntaxNode syntax,
        SemanticModel semanticModel,
        string fullAttributeName,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        foreach (var attributeSyntax in syntax.GetAllAttributes())
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            if (!(ModelExtensions.GetSymbolInfo(semanticModel, attributeSyntax, cancellationToken).Symbol is
                IMethodSymbol attributeSymbol))
                continue;
            var attributeName = attributeSymbol.ContainingType.ToDisplayString();
            if (attributeName == fullAttributeName)
                yield return attributeSyntax;
        }
    }

    public static AttributeSyntax? GetSpecifiedAttribute(
        this SyntaxNode syntax,
        SemanticModel semanticModel,
        string fullAttributeName,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        return syntax.GetSpecifiedAttributes(semanticModel, fullAttributeName, cancellationToken).FirstOrDefault();
    }

    public static ClassDeclarationSyntax AddModifiers(this ClassDeclarationSyntax syntax, params SyntaxKind[] items)
    {
        return syntax.AddModifiers(items.Select(SyntaxFactory.Token).ToArray());
    }

    public static ClassDeclarationSyntax AddBaseListTypes(
        this ClassDeclarationSyntax syntax,
        params string[] identifiers)
    {
        var list = identifiers.Select(x => SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(x))).ToList();
        list.ForEach(x => syntax = syntax.AddBaseListTypes(x));
        return syntax;
    }

    public static ClassDeclarationSyntax AddMembers(this ClassDeclarationSyntax syntax, params string[] members)
    {
        return syntax.AddMembers(members.Select(x =>
            SyntaxFactory.ParseMemberDeclaration(x) ?? throw new Exception($"Text : {x} , Parse failed")).ToArray());
    }
}