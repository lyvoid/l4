using GameSystem;

public class NewGameProcessInfoEvent : GameEvent
{
    public string info;
    public NewGameProcessInfoEvent(string frameCount) : base(GameEventNames.NewGameProcessInfo)
    {
        this.info = frameCount;
    }
}