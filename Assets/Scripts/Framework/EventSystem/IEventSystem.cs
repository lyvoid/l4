using System;

namespace GameSystem
{
    public interface IEventSystem
    {
        void AddEventListener(string eventName, Action<GameEvent> listener);
        void AddUniqEventListener(string eventName, Action<GameEvent> listener);
        void DispatchEvent(GameEvent event_);
        bool HasEventListener(string eventName, Action<GameEvent> listener);
        void Once(string eventName, Action<GameEvent> listener);
        void RemoveEventListener(string eventName, Action<GameEvent> listener);
        void ClearEvent(string eventName);
        void ClearOnceEvent(string eventName);
    }
}