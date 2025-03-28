﻿using RapidDeskToolkit.Models.Exceptions;

namespace RapidDeskToolkit.Common.DatabaseManager.Exceptions;

/// <summary>
/// 表示在数据库中未找到数据时引发的异常。
/// </summary>
public class DataNotFoundException : FrameworkExceptionBase
{
    /// <summary>
    /// 初始化 <see cref="DataNotFoundException"/> 类的新实例。
    /// </summary>
    /// <param name="information">错误信息。</param>
    /// <param name="details">错误详情。</param>
    public DataNotFoundException(string information, string details = "")
        : base(ErrorCode.RuntimeError, information, details)
    {
    }
}
