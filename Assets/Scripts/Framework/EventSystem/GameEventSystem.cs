using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{

    public class GameEventSystem : SystemBase<GameEventSystem>, IEventSystem
    {
        private Dictionary<string, IList<Action<GameEvent>>> _listeners = new Dictionary<string, IList<Action<GameEvent>>>();
        private Dictionary<string, IList<Action<GameEvent>>> _onceListeners = new Dictionary<string, IList<Action<GameEvent>>>();

        public void AddEventListener(string eventName, Action<GameEvent> listener)
        {
            if (!_listeners.ContainsKey(eventName))
            {
                _listeners[eventName] = new List<Action<GameEvent>>(GameSystemConst.InitialEventSystemListnerListSize);
            }
            _listeners[eventName].Add(listener);
        }


        public void AddUniqEventListener(string eventName, Action<GameEvent> listener)
        {
            // if listener already exist, return 
            if (HasEventListener(eventName, listener))
            {
                Debug.Log(string.Format("Listener had already added into event {0} before.",
                    eventName));
                return;
            }
            AddEventListener(eventName, listener);
        }

        /// <summary>
        /// clear all listeners in eventName
        /// </summary>
        /// <param name="eventName"></param>
        public void ClearEvent(string eventName)
        {
            if (!_listeners.ContainsKey(eventName))
                return;
            _listeners[eventName].Clear();
        }

        /// <summary>
        /// clear all once listeners in event name
        /// </summary>
        /// <param name="eventName"></param>
        public void ClearOnceEvent(string eventName)
        {
            if (!_onceListeners.ContainsKey(eventName))
                return;
            _onceListeners[eventName].Clear();
        }

        public void DispatchEvent(GameEvent event_)
        {
            if (_listeners.ContainsKey(event_.EventName))
            {
                foreach (Action<GameEvent> action in _listeners[event_.EventName])
                {
                    action(event_);
                }
            }
            if (_onceListeners.ContainsKey(event_.EventName))
            {
                foreach (Action<GameEvent> action in _onceListeners[event_.EventName])
                {
                    action(event_);
                }
                ClearOnceEvent(event_.EventName);
            }
        }

        /// <summary>
        /// whether a listener is in a normal event (this function dont judge whether is it in once event). 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool HasEventListener(string eventName, Action<GameEvent> listener)
        {
            // eventType exist && index of listner >= 0
            return _listeners.ContainsKey(eventName) && _listeners[eventName].Contains(listener);
        }

        /// <summary>
        /// add a listener to eventname, but this listener only run one time,
        /// and will be auto removed from event list after dispatched.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void Once(string eventName, Action<GameEvent> listener)
        {
            if (!_onceListeners.ContainsKey(eventName))
            {
                _onceListeners[eventName] = new List<Action<GameEvent>>(
                    GameSystemConst.InitialEventSystemListnerListSize);
            }
            _onceListeners[eventName].Add(listener);
        }

        /// <summary>
        /// Remove one listener from eventName if exist.(not remove all)
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void RemoveEventListener(string eventName, Action<GameEvent> listener)
        {
            if (_listeners.ContainsKey(eventName))
            {
                _listeners[eventName].Remove(listener);
            }
            if (_onceListeners.ContainsKey(eventName))
            {
                _onceListeners[eventName].Remove(listener);
            }
        }
    }
}