using r_core.coresystems.optionalsystems.messages;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Display : MonoBehaviour
{
    public UILabel[] display;
    private int lastIndex = 0;

    private void Awake()
    {
        //Rellenamos la lista
        display = GetComponentsInChildren<UILabel>();
        
    }

    private void OnEnable()
    {
        R_MessagesController<R_MessageButton>.AddObserver((int)GameEnums.MessagesTypes.SendKey, HandleKey);
    }

    private void OnDisable()
    {
        R_MessagesController<R_MessageButton>.RemoveObserver((int)GameEnums.MessagesTypes.SendKey, HandleKey);
    }

    private void HandleKey(R_MessageButton obj)
    {
        if (obj.SenderId == (int)GameEnums.Senders.ButtonNumber || obj.SenderId == (int)GameEnums.Senders.ButtonClear)
        {
            switch (obj.action)
            {
                case GameEnums.ActionKeyboard.SendKey:
                    AddKey(obj.number);
                    break;

                case GameEnums.ActionKeyboard.SendDelete:
                    RemoveLastKey();
                    break;

                default:
                    Debug.Log("Caso no contemplado");
                    break;
            }
        }

        
    }

    private void AddKey(string letra)
    {
        if (lastIndex > display.Length - 1) return;

        Debug.Log("Index: " + lastIndex);
        display[lastIndex].text = letra;
        lastIndex++; 
    }

    private void RemoveLastKey()
    {
        lastIndex--;
        if (lastIndex < 0)
        {
            lastIndex = 0;
            return;
        }


        Debug.Log("Index: " + lastIndex);
        display[lastIndex].text = string.Empty;
        
    }

    private void CheckPassword()
    {
        bool keyCorrect = false;

        for(int i = 0, max = display.Length; i < max; i++)
        {
            if (string.IsNullOrEmpty(display[i].text))
            {
                keyCorrect = false;
                break;
            }
        }

        if (!keyCorrect)
        {
            Debug.Log("Clave incorrecta");
        }
        else
        {
            Debug.Log("Clave correcta");
        }

    }
}
