using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    Rigidbody bullrb;

    public float bulletPower = 0f;
    public float life = 4f;

    private float time = 0f;
    void Start()
    {
     
        bullrb=GetComponent<Rigidbody>();
        bullrb.linearVelocity= this.transform.forward*bulletPower;

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Obtiene el componente EnemigoDamage del objeto con el que colisionas
        EnemigoDamage enemigoDamage = collision.gameObject.GetComponent<EnemigoDamage>();

        // Verifica si el componente existe
        if (enemigoDamage != null)
        {

            enemigoDamage.RecibirDano();
        }
        else
        {
       
        }
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        time+= Time.deltaTime;

        if (time >= life)
        {
            Destroy(this.gameObject);
        }
    }
}
