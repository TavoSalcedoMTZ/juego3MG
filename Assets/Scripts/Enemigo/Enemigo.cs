using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(Objetivo.position);
    }
}
