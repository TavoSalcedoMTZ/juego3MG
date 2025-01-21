using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_J : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float VidaMaxima;


    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / VidaMaxima;
    }
}
