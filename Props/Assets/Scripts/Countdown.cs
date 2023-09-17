using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public UILabel labelTiempo;

    private float tiempoInicial = 3600f;
    private float tiempoRestante;
    private int minutos = 0;
    private int segundos = 0;
    private bool run;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    public void ResetCounter()
    {
        tiempoInicial = 3600f;
        tiempoRestante = tiempoInicial;
        labelTiempo.text = "59:59";
        run = false;
    }

    public void PlayCounter()
    {
        run = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!run) return;

        if(tiempoRestante > 0)
        {
            //Actualizamos el tiempo restante
            tiempoRestante -= Time.deltaTime;

            minutos = Mathf.FloorToInt(tiempoRestante / 60);
            segundos = Mathf.FloorToInt(tiempoRestante % 60);            

            //Imprimimos tiempo restante
            labelTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        }
        else
        {
            run = false;
            labelTiempo.text = "00:00";
        }
    }

    public void StopCountdown()
    {
        run = false;
    }
}
