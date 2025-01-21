using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ComprobadorDeVariables : MonoBehaviour
{
    public WeaponController weapons1;
    public WeaponController weapons2;
    public WeaponController weapons3;
    public WeaponController weapons4;
    public bool CanSwitch;
    public bool ForzarSwitchBool;
    public PlayerMovement player;

    void Start()
    {
        CanSwitch=true;

        
    }


    void Update()
    {
        if (weapons1.isReloading || weapons2.isReloading || weapons3.isReloading || weapons4.isReloading)
        {
            CanSwitch = false;
        }
        else
        {
            CanSwitch=true;
        }



        ForzarSwitch();
    }
    void ForzarSwitch()
    {
        if (weapons1.armarota || weapons2.armarota || weapons3.armarota || weapons4.armarota)
        {
            ForzarSwitchBool = true;
        }
        else
        {
            ForzarSwitchBool=false;
        }

    }

    void VerificarOperacion()
    {
        if (player.operacioncompletada)
        {
            ForzarSwitchBool = false;

        }
        else
        {

        }
    }
}
