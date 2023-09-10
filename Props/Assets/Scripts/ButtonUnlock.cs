using r_core.coresystems.optionalsystems.messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnlock : MonoBehaviour
{
    private R_MessageButton messageButton;

    private void Start()
    {
        messageButton = new R_MessageButton((uint)GameEnums.Senders.ButtonNumber, GameEnums.ActionKeyboard.SendUnlock);
    }

    public void PressButton()
    {
        //Enviamos mensaje con el boton pulsado
        R_MessagesController<R_MessageButton>.Post((int)GameEnums.MessagesTypes.SendKey, messageButton);
    }
}
