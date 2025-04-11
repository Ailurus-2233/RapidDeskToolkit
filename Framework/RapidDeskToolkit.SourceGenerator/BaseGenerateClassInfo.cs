using Microsoft.CodeAnalysis.Text;

namespace RapidDeskToolkit.SourceGenerator;

public abstract class BaseGenerateClassInfo
{
    public string? GeneratedFileName { get; set; }
    public bool ShouldGenerate { get; set; }
    public abstract SourceText GenerateCode();
}