using Microsoft.CodeAnalysis;

namespace RapidDeskToolkit.SourceGenerator.SourceGenerator;

public class AutoGenerateClassInfo
{
    public string? Name { get; set; }
    public string? Namespace { get; set; }
    public bool ShouldGenerate { get; set; }
    public GeneratorSyntaxContext Context { get; set; }
}
