using r_core.coresystems.optionalsystems.messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNumber : MonoBehaviour
{
    public UILabel label;
    private R_MessageButton messageButton;

    private void Start()
    {
        messageButton = new R_MessageButton((uint)GameEnums.Senders.ButtonNumber, label.text, GameEnums.ActionKeyboard.SendKey);
    }


    public void PressButton()
    {
        //Enviamos mensaje con el boton pulsado
        R_MessagesController<R_MessageButton>.Post((int)GameEnums.MessagesTypes.SendKey, messageButton);

    }
}
