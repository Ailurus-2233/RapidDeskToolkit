using RapidDeskToolkit.Common.DatabaseManager.Managers;

namespace RapidDeskToolkit.Common.DatabaseManager.Configs;

/// <summary>
///     XML 数据库配置
/// </summary>
public class XMLConfigItem : DatabaseConfigItemBase
{
    /// <inheritdoc />
    public override string Name { get; set; } = "database_xml";

    /// <inheritdoc />
    public override ManagerBase GenerateManager()
    {
        return new XmlDatabaseManager(Path, Name);
    }

    /// <summary>
    ///     数据库文件路径
    /// </summary>
    public string Path { get; set; } = "data";
    
}