using RapidDeskToolkit.Common.DatabaseManager.Managers;

namespace RapidDeskToolkit.Common.DatabaseManager.Configs;

/// <summary>
///     CSV 数据库配置
/// </summary>
public class CsvConfigItem : DatabaseConfigItemBase
{
    /// <summary>
    ///     数据库名称
    /// </summary>
    public override string Name { get; set; } = "database_csv";

    /// <inheritdoc />
    public override ManagerBase GenerateManager()
    {
        return new CsvDatabaseManager(Path, Name);
    }

    /// <summary>
    ///     数据库文件路径
    /// </summary>
    public string Path { get; set; } = "data";
}