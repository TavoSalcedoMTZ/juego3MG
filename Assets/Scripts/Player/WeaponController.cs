using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class WeaponController : MonoBehaviour
{
    public Transform shootSpawn;
    public bool shooting = false;
    public float cadencia = 0.2f;
    public int numerobalas = 10;
    public float tiemporecarga = 2f;
    public int cantidaddebalascargador = 5;
    public Image Filler;
    public bool canShoot;
    public Tienda tienda;
    public GameObject bullPreFab;
    public TextMeshProUGUI textobalas;
   

    private float FillerAmout;
    private float timeSinceLastShot = 0f;
    public bool isReloading = false;

    void Start()
    {
        timeSinceLastShot = cadencia;
        cantidaddebalascargador = numerobalas;
        canShoot=true;
    }

    void Update()
    {

        if (tienda.TiendaOpen)
        {
            canShoot = false;
        }
        else if (!tienda.TiendaOpen)
        {
            canShoot = true;
        }



        UpgradeTextoBalas();
        UpdateFiller();
        Debug.DrawLine(shootSpawn.position, shootSpawn.position + shootSpawn.forward * 10f, Color.blue);
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 10f, Color.red);

        RaycastHit cameraHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - shootSpawn.position;
            shootSpawn.rotation = Quaternion.LookRotation(shootDirection);


            if (Input.GetKey(KeyCode.Mouse0) && numerobalas > 0 && timeSinceLastShot >= cadencia && !isReloading&& canShoot)
            {

                if (!isReloading)
                {
                    Shoot();
                    numerobalas--;
                    timeSinceLastShot = 0f;
                }
                else if (isReloading)
                {

                }
            }
        }

        timeSinceLastShot += Time.deltaTime;

        if ( Input.GetKeyDown(KeyCode.R) && canShoot || numerobalas == 0 && !isReloading && canShoot )
        {

            Debug.Log("Recargando");
            Recargar();
        }
    }

    public void Shoot()
    {
        Instantiate(bullPreFab, shootSpawn.position, shootSpawn.rotation);
    }

    public void Recargar()
    {
        if (!isReloading || numerobalas == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {   
        isReloading = true;
        Filler.gameObject.SetActive(true);
        FillerAmout = tiemporecarga;
        yield return new WaitForSeconds(tiemporecarga);
        numerobalas = cantidaddebalascargador;
        Filler.gameObject.SetActive(false);
        isReloading = false;
    }

    void UpdateFiller()
    {
        if (isReloading)
        {
            FillerAmout-=1f*Time.deltaTime;
            Filler.fillAmount = FillerAmout/tiemporecarga;
            Debug.Log("FILLER AMOUT: " + FillerAmout/tiemporecarga);


        }
    }

    void UpgradeTextoBalas()
    {
        textobalas.text = numerobalas.ToString();


    }
}
