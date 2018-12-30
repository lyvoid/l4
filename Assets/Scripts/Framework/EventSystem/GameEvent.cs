namespace GameSystem
{
    public class GameEvent {
        public string EventName { get; private set; }
        public GameEvent(string eventName)
        {
            EventName = eventName;
        }
    }
}