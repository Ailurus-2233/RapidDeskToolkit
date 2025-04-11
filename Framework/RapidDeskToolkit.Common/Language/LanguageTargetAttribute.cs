namespace RapidDeskToolkit.Common.Language;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class LanguageTargetAttribute(Type targetDesignerType) : Attribute
{
    public Type TargetDesignerType { get; } = targetDesignerType;
}
