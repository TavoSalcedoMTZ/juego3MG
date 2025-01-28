using UnityEngine;

public class EnemigoDamage : MonoBehaviour
{
    public Tienda tienda;
    public int VidaEnemigo;
    void Start()
    {

    }

    void Update()
    {
     
        if (VidaEnemigo == 0)
        {
            tienda.DineroPlayer = tienda.DineroPlayer + 5;

            Destroy(gameObject);
        }
    }

    public void RecibirDano()
    {
        VidaEnemigo = VidaEnemigo - 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.CompareTag("Player"))
        {
           
            PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();

            if (playerLife != null)
            {
              
                playerLife.RecibirDanio(1); 
           
            }
            else
            {
               
            }
        }
    }
}
