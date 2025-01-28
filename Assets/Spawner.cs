using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigoPrefab;          
    public List<Transform> puntosDeSpawn;    
    public float tiempoEntreSpawnsInicial = 3f; 
    public float tiempoEntreSpawnsMinimo = 1f; 
    public float incrementoDeFrecuencia = 0.1f; 
    public int enemigosMaximos = 25;           
    private float tiempoProximoSpawn;       
    private int numeroDeEnemigos;             

    void Start()
    {

        tiempoProximoSpawn = tiempoEntreSpawnsInicial;
        numeroDeEnemigos = 0;
    }

    void Update()
    {
 
        if (numeroDeEnemigos < enemigosMaximos)
        {
     
            tiempoProximoSpawn -= Time.deltaTime;

          
            if (tiempoProximoSpawn <= 0)
            {
           
                SpawnEnemigo();

                tiempoProximoSpawn = Mathf.Max(tiempoEntreSpawnsMinimo, tiempoProximoSpawn - incrementoDeFrecuencia);
            }
        }
    }


    void SpawnEnemigo()
    {
    
        if (puntosDeSpawn.Count > 0)
        {
       
            Transform puntoSpawn = puntosDeSpawn[Random.Range(0, puntosDeSpawn.Count)];

      
            Instantiate(enemigoPrefab, puntoSpawn.position, Quaternion.identity);

       
            numeroDeEnemigos++;
        }
        else
        {
            Debug.LogWarning("No hay puntos de spawn definidos.");
        }
    }

 
    public void EnemigoDestruido()
    {
        numeroDeEnemigos--;
    }
}
