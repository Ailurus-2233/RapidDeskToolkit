using RapidDeskToolkit.Common.DatabaseManager.Models.Enums;
using RapidDeskToolkit.Models.Exceptions;

namespace RapidDeskToolkit.Common.DatabaseManager.Exceptions;

/// <summary>
///     类型不一致异常，用于表示类型与列类型不一致
/// </summary>
/// <param name="columnType">
///     列类型
/// </param>
/// <param name="type">
///     实际类型
/// </param>
/// <param name="details">
///     异常详细信息
/// </param>
public class TypeInconsistentException(ColumnType columnType, Type type, string details = "")
    : FrameworkExceptionBase(ErrorCode.InvalidArgument, $"Type: {type} inconsistent with ColumnType: {columnType}",
        details);
