using r_core.core;
using r_core.coresystems.optionalsystems.messages;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] private GameObject backgroundWrong;
    [SerializeField] private GameObject backgroundCorrect;
    [SerializeField] private UILabel labelIntentos;
    [SerializeField] private Countdown cuentaAtras;

    public UILabel[] display;
    private int lastIndex = 0;
    private byte intentos = 3;

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
        if (obj.SenderId == (int)GameEnums.Senders.ButtonNumber || obj.SenderId == (int)GameEnums.Senders.ButtonClear ||
            obj.SenderId == (int)GameEnums.Senders.ButtonUnlock)
        {
            switch (obj.action)
            {
                case GameEnums.ActionKeyboard.SendKey:
                    AddKey(obj.number);
                    break;

                case GameEnums.ActionKeyboard.SendDelete:
                    RemoveLastKey();
                    break;

                case GameEnums.ActionKeyboard.SendUnlock:
                    CheckPassword();
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

        display[lastIndex].text = string.Empty;
        
    }

    private void CheckPassword()
    {
        if (intentos == 0) return;

        bool keyCorrect = false;
        string passIntroduced = string.Empty;

        for(int i = 0, max = display.Length; i < max; i++)
        {
            //Comprobamos si estan todos los digitos introducidos
            if (string.IsNullOrEmpty(display[i].text))
            {
                keyCorrect = false;
                break;
            }

            //Obtenemos la primera letra de cada string
            char letra = display[i].text[0];
            passIntroduced += letra;
        }

        //Comprobamos el password introducido
        if(passIntroduced == "GREMIO")
        {
            keyCorrect = true;
        }

        if (!keyCorrect)
        {
            //Indicamos que se ha equivocado el usuario
            backgroundWrong.gameObject.SetActive(true);

            //Reducimos los intentos
            intentos--;

            if(intentos == 0)
            {
                //Indicamos al usuario que tendra que esperar 1 min para poder intentarlo otra vez
                labelIntentos.text = "ESPERE 1 MINUTO Y VUELVA A INTENTARLO";

                
                //Montamos un timer para montar nuevos intentos en 1 minuto
                R_Core.GetInstance().StartTimer(60f, this, cacheAction =>
                {
                    (cacheAction.Context as Display).SetNewIntentos();
                });
                
                
            }
            else
            {
                //Se lo indicamos al usuario
                labelIntentos.text = "QUEDAN " + intentos + " INTENTOS";
            }

        }
        else
        {
            //La clave es correcta
            backgroundCorrect.gameObject.SetActive(true);

            //Paramos el contador
            cuentaAtras.StopCountdown();
            
        }
    }

    private void SetNewIntentos()
    {
        intentos = 3;

        labelIntentos.text = "QUEDAN 3 INTENTOS";   
    }
}
