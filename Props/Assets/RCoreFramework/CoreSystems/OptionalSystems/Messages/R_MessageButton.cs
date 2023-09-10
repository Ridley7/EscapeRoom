using r_core.coresystems.optionalsystems.messages;

public class R_MessageButton : R_Message
{
    public string number { get; private set; }
    public GameEnums.ActionKeyboard action { get; private set; }

    public R_MessageButton(uint senderId, GameEnums.ActionKeyboard action) : base(senderId)
    {
        this.action = action;
    }

    public R_MessageButton(uint senderId, string number, GameEnums.ActionKeyboard action) : base(senderId)
    {
        this.number = number;
        this.action = action;
    }

    public void SetData(uint senderId, string number, GameEnums.ActionKeyboard action)
    {
        IsLocal = true;
        SenderId = senderId;
        this.number = number;
        this.action = action;
    }
}
