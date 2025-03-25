namespace RapidDeskToolkit.Models.Exceptions;

/// <summary>
///     框架异常基类，用于记录框架内部异常
/// </summary>
/// <param name="code"></param>
/// <param name="information"></param>
/// <param name="details"></param>
public abstract class FrameworkExceptionBase(ErrorCode code, string information, string details = null) : Exception(information)
{
    /// <summary>
    ///     错误码，用于标识错误类型
    /// </summary>
    private ErrorCode Code { get; set; } = code;

    /// <summary>
    ///     错误信息
    /// </summary>
    private string Information { get; set; } = information;

    /// <summary>
    ///     错误详细信息
    /// </summary>
    private string Details { get; set; } = details;

    /// <summary>
    ///     完整错误信息
    /// </summary>
    public string FullMessage
    {
        get
        {
            var result = $"{Code.ToString()}:\n\tInformation:{Information}";
            if (!string.IsNullOrEmpty(Details))
                result += $"\n\tDetails:{Details}";
            return result;
        }
    }
}

