using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public bool TiendaOpen;
   public GameObject Panel;
    public GameObject Player;
    public GameObject m4, revolver, escopeta, subfusil;
    


 
    void Start()
    {
        TiendaOpen=false;
       
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchTienda();

        }
        
    }

    void SwitchTienda()
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
            TiendaOpen=false ;
        }




    }
}
