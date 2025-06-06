﻿using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using RapidDeskToolkit.Common.DatabaseManager.Attributes;
using RapidDeskToolkit.Common.DatabaseManager.Models;
using RapidDeskToolkit.Common.DatabaseManager.Models.Enums;

namespace RapidDeskToolkit.Common.DatabaseManager.DataConverters;

/// <summary>
///     数据类型对 SQLite 语句的转化类
/// </summary>
public static class SQLiteConverter
{
    /// <summary>
    ///     生成创建表的 SQL 语句
    /// </summary>
    /// <param name="data">
    ///     数据类型
    /// </param>
    /// <returns>
    ///     创建表的 SQL 语句
    /// </returns>
    public static string GenerateCreateTableCommand(this IData data)
    {
        var primaryKeys = data.GetPrimaryKeys();
        var columns = data.GetNonPrimaryKey();

        var result = new StringBuilder($"CREATE TABLE IF NOT EXISTS {data.GetTableName()} (");

        switch (primaryKeys.Count)
        {
            case 0:
                throw new ArgumentException("Primary key is required");
            case 1:
            {
                var primary = primaryKeys[0];
                if (primary.GetCustomAttribute<AutoIncrementAttribute>() != null)
                    result.Append($"{primary.Name} {primary.GetColumnType().GetSQLType()} PRIMARY KEY AUTOINCREMENT,");

                else
                    result.Append($"{primary.Name} {primary.GetColumnType().GetSQLType()} PRIMARY KEY,");


                foreach (var column in columns)
                    result.Append($"{column.Name} {column.GetColumnType().GetSQLType()},");


                result.Remove(result.Length - 1, 1);
                result.Append(");");
                break;
            }
            default:
            {
                foreach (var primary in primaryKeys)
                {
                    if (primary.GetCustomAttribute<AutoIncrementAttribute>() != null)
                        throw new ArgumentException("Auto increment is not supported for multiple primary keys");
                    result.Append($"{primary.Name} {primary.GetColumnType().GetSQLType()},");
                }
                    

                foreach (var column in columns)
                    result.Append($"{column.Name} {column.GetColumnType().GetSQLType()},");

                result.Append("PRIMARY KEY (");
                foreach (var primary in primaryKeys)
                    result.Append($"{primary.Name},");

                result.Remove(result.Length - 1, 1);
                result.Append("));");
                break;
            }
        }

        return result.ToString();
    }

    /// <summary>
    ///     生成插入数据的 SQL 语句
    /// </summary>
    /// <param name="data">
    ///     数据对象
    /// </param>
    /// <returns>
    ///     插入数据的 SQL 语句
    /// </returns>
    public static string GenerateInsertCommand(this IData data)
    {
        var primaryKeys = data.GetPrimaryKeys();
        var columns = data.GetNonPrimaryKey();

        var result = new StringBuilder($"INSERT INTO {data.GetTableName()} (");

        foreach (var primary in primaryKeys)
            result.Append($"{primary.GetColumnType().Name},");


        foreach (var column in columns)
            result.Append($"{column.GetColumnType().Name},");


        result.Remove(result.Length - 1, 1);
        result.Append(") VALUES (");

        foreach (var primary in primaryKeys)
            result.Append($"${primary.GetColumnType().Name},");

        foreach (var column in columns)
            result.Append($"${column.GetColumnType().Name},");

        result.Remove(result.Length - 1, 1);
        result.Append(");");

        return result.ToString();
    }

    /// <summary>
    ///     生成更新数据的 SQL 语句
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string GenerateUpdateCommand(this IData data)
    {
        var primaryKeys = data.GetPrimaryKeys();
        var columns = data.GetNonPrimaryKey();

        var result = new StringBuilder($"UPDATE {data.GetTableName()} SET ");

        foreach (var column in columns)
            result.Append($"{column.GetColumnType().Name} = ${column.GetColumnType().Name},");

        result.Remove(result.Length - 1, 1);
        result.Append(" WHERE ");

        foreach (var primary in primaryKeys)
            result.Append($"{primary.GetColumnType().Name} = ${primary.GetColumnType().Name} AND ");

        result.Remove(result.Length - 4, 4);
        result.Append(';');

        return result.ToString();
    }

    /// <summary>
    ///     生成删除数据的 SQL 语句
    /// </summary>
    /// <param name="data">
    ///     数据对象
    /// </param>
    /// <returns>
    ///     删除数据的 SQL 语句
    /// </returns>
    public static string GenerateDeleteCommand(this IData data)
    {
        var primaryKeys = data.GetPrimaryKeys();

        var result = new StringBuilder($"DELETE FROM {data.GetTableName()} WHERE ");

        foreach (var primary in primaryKeys)
            result.Append($"{primary.GetColumnType().Name} = ${primary.GetColumnType().Name} AND ");

        result.Remove(result.Length - 4, 4);
        result.Append(';');

        return result.ToString();
    }

    /// <summary>
    ///     生成查询数据的 SQL 语句
    /// </summary>
    /// <returns>
    ///     查询数据的 SQL 语句
    /// </returns>
    public static string GenerateSelectCommand<T>(Expression<Func<T, bool>> predicate) where T : class, IData
    {
        var data = Activator.CreateInstance<T>();
        var tableName = data.GetTableName();

        var result = new StringBuilder($"SELECT * FROM {tableName} WHERE ");
        var condition = GenerateConditionStatement<T>(predicate.Body);

        result.Append(condition);

        if (string.IsNullOrEmpty(condition))
            result.Remove(result.Length - 7, 7);
        result.Append(';');

        return result.ToString();
    }

    private static string GenerationSingleConditionStatement<T>(BinaryExpression? expression) where T : class, IData
    {
        var data = Activator.CreateInstance<T>();
        var columns = data.GetAllColumns();

        if (expression?.Left is not MemberExpression left || expression.Right is not ConstantExpression right)
            throw new ArgumentException("Predicate must be a binary expression");

        var column = columns.FirstOrDefault(c => c.Name == left.Member.Name);

        if (column == null)
            throw new ArgumentException("Column not found");

        var operate = expression.NodeType switch
        {
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            _ => throw new ArgumentException("Unsupported operation")
        };

        var value = right.Value;
        if (column.GetColumnType().ColumnType == ColumnType.SQLITE_TEXT)
            value = $"'{value}'";

        return $"{column.GetColumnType().Name} {operate} {value}";
    }

    private static readonly ExpressionType[] SingleExpressionTypes =
    [
        ExpressionType.Equal,
        ExpressionType.NotEqual,
        ExpressionType.GreaterThan,
        ExpressionType.GreaterThanOrEqual,
        ExpressionType.LessThan,
        ExpressionType.LessThanOrEqual
    ];

    private static readonly ExpressionType[] MultiExpressionTypes =
    [
        ExpressionType.AndAlso,
        ExpressionType.OrElse
    ];

    private static string GenerateConditionStatement<T>(Expression predicate) where T : class, IData
    {
        if (predicate is ConstantExpression)
            return string.Empty;
        if (predicate is not BinaryExpression body)
            throw new ArgumentException("Predicate must be a binary expression");

        if (SingleExpressionTypes.Contains(body.NodeType))
            return GenerationSingleConditionStatement<T>(body);

        if (!MultiExpressionTypes.Contains(body.NodeType))
            throw new ArgumentException("Unsupported expression");

        var connect = predicate.NodeType switch
        {
            ExpressionType.AndAlso => "AND",
            ExpressionType.OrElse => "OR",
            _ => throw new ArgumentException("Unsupported expression")
        };

        var left = GenerateConditionStatement<T>(body.Left);
        var right = GenerateConditionStatement<T>(body.Right);

        return $"({left} {connect} {right})";
    }

    /// <summary>
    ///     生成清空表的 SQL 语句
    /// </summary>
    /// <typeparam name="T">
    ///     数据类型
    /// </typeparam>
    /// <returns>
    ///     清空表的 SQL 语句
    /// </returns>
    public static string GenerateClearTableCommand<T>() where T : class, IData
    {
        var data = Activator.CreateInstance<T>();
        return $"DELETE FROM {data.GetTableName()};";
    }
}
