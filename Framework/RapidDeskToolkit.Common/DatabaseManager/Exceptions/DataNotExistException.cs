using RapidDeskToolkit.Models.Exceptions;

namespace RapidDeskToolkit.Common.DatabaseManager.Exceptions;

/// <summary>
///     没有找到根元素异常，当在XML文件中没有找到根元素时抛出
/// </summary>
public class DataNotExistException(string targetXmlFile, string details = "") :
    FrameworkExceptionBase(ErrorCode.InvalidOperation, targetXmlFile, details);
