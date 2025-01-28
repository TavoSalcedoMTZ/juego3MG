using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Necesario para trabajar con TextMeshPro

public class Tienda : MonoBehaviour
{
    public bool TiendaOpen;
    public GameObject Panel;
    public GameObject Player;
    public GameObject m4, revolver, escopeta, subfusil;
    public PlayerMovement playermove;
    public PlayerLife playerlife;
    public int DineroPlayer;

    // Referencia al componente TextMeshPro
    public TextMeshProUGUI DineroText;

    void Start()
    {
        TiendaOpen = false;
        ActualizarDineroText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchTienda();
        }
        ActualizarDineroText();
    }

    public void SwitchTienda()
    {
        if (!TiendaOpen)
        {
            TiendaOpen = true;
            Panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (TiendaOpen)
        {
            Panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            TiendaOpen = false;
        }
    }

    public void CompraArma(GameObject _arma, int tipoarma, int costo)
    {
        if (DineroPlayer >= costo)
        {
            DineroPlayer -= costo;
            ActualizarDineroText();

            if (tipoarma == 1)
            {
                playermove.SetArma1(_arma);
            }
            else if (tipoarma == 2)
            {
                playermove.SetArma2(_arma);
            }
            else
            {
                Debug.Log("Error");
            }
        }
        else
        {
            Debug.Log("Sin dinero suficiente");
        }
    }

    public void CompraM4()
    {
        CompraArma(m4, 1, 20);
    }
    public void CompraRevolver()
    {
        CompraArma(revolver, 2, 20);
    }
    public void CompraEscopeta()
    {
        CompraArma(escopeta, 1, 20);
    }
    public void CompraSubfusil()
    {
        CompraArma(subfusil, 2, 20);
    }
    public void ComprarCuras()
    {
        if (DineroPlayer >= 50)
        {
            DineroPlayer -= 50;
            ActualizarDineroText();

            playerlife.Curar();
        }
        else
        {
            Debug.Log("Dinero Insuficiente");
        }

    }


    void ActualizarDineroText()
    {
        if (DineroText != null)
        {
            DineroText.text = "$: " + DineroPlayer.ToString(); 
        }
        else
        {
         
        }
    }
}
