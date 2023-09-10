using r_core.coresystems.optionalsystems.messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClear : MonoBehaviour
{
    private R_MessageButton messageButton;

    // Start is called before the first frame update
    void Start()
    {
        messageButton = new R_MessageButton((uint)GameEnums.Senders.ButtonNumber, GameEnums.ActionKeyboard.SendDelete);
    }

    public void PressButton()
    {
        //Enviamos mensaje con el boton pulsado
        R_MessagesController<R_MessageButton>.Post((int)GameEnums.MessagesTypes.SendKey, messageButton);
    }

}
