﻿using RapidDeskToolkit.Models.Exceptions;

namespace RapidDeskToolkit.Common.DatabaseManager.Exceptions;

/// <summary>
/// 表示无效的数据模型异常。
/// </summary>
public class InvalidDataModelException : FrameworkExceptionBase
{
    /// <summary>
    /// 初始化 <see cref="InvalidDataModelException"/> 类的新实例。
    /// </summary>
    /// <param name="errorType">错误类型。</param>
    /// <param name="details">错误详情。</param>
    public InvalidDataModelException(Type errorType, string details = "")
        : base(ErrorCode.InvalidArgument, $"The data model {errorType.FullName} is invalid.", details)
    {

    }
}
