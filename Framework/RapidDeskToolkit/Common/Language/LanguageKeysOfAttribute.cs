namespace RapidDeskToolkit.Common.Language;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class LanguageKeysOfAttribute(Type languageType) : Attribute;
