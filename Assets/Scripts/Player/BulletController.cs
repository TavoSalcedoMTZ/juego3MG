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
        bullrb.velocity= this.transform.forward*bulletPower;

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
