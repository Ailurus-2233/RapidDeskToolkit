using RapidDeskToolkit.Models.Events;

namespace RapidDeskToolkit.Common.EventAggregator;

/// <summary>
///     事件聚合器接口
/// </summary>
public interface IEventAggregator
{
    /// <summary>
    ///     订阅事件
    /// </summary>
    /// <param name="action">
    ///     事件触发后执行操作
    /// </param>
    /// <typeparam name="TEvent">
    ///     事件类型
    /// </typeparam>
    void Subscribe<TEvent>(Action<TEvent> action) where TEvent : FrameworkEventBase;


    /// <summary>
    ///     取消订阅
    /// </summary>
    /// <param name="action">
    ///     事件执行后执行操作
    /// </param>
    /// <typeparam name="TEvent">
    ///     事件类型
    /// </typeparam>
    void Unsubscribe<TEvent>(Action<TEvent> action) where TEvent : FrameworkEventBase;


    /// <summary>
    ///     发布事件
    /// </summary>
    /// <param name="eventToPublish">
    ///     具体事件
    /// </param>
    /// <typeparam name="TEvent">
    ///     事件类型
    /// </typeparam>
    void Publish<TEvent>(TEvent eventToPublish) where TEvent : FrameworkEventBase;
}