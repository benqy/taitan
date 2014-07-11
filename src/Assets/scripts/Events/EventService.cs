using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 事件控制器
/// 全局单例，非线程安全
/// </summary>
public class EventService {
    private readonly static EventService _instance = new EventService();

    // 存放事件对象的集合
    private readonly Dictionary<Type, EventBase> _eventBases = new Dictionary<Type, EventBase>();

    public static EventService Instance {
        get { return _instance; }
    }

    private EventService() {
    }

    /// <summary>
    /// 获取一个事件对象，该对象用于事件订阅或发布
    /// </summary>
    public T GetEvent<T>() where T : EventBase {
        Type eventType = typeof(T);
        if (!_eventBases.ContainsKey(eventType)) {
            // 如果事件对象不存在，则创建一个该类型的对象
            T e = Activator.CreateInstance<T>();
            _eventBases.Add(eventType, e);
        }

        return (T)_eventBases[eventType];
    }

    /// <summary>
    /// 移除所有事件对象
    /// </summary>
    public void ClearAll() {
        foreach (EventBase e in _eventBases.Values) {
            e.Clear();
        }

        _eventBases.Clear();
    }

    /// <summary>
    /// 移除所有KeepOnLevelChanging标记为false的事件对象的订阅方法，并不移除该事件对象
    /// 该方法应该与Application.LoadLevel() 一起调用（如果有必要）
    /// </summary>
    public void ClearOnLevelChanging(int newLevelId) {
        foreach (EventBase e in _eventBases.Values.Where(e => !e.KeepOnLevelChanging)) {
            e.Clear();
        }
    }
}


