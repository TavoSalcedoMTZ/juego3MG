using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
    public Transform shootSpawn;
    public bool shooting = false;
    public float cadencia = 0.2f;
    public int numerobalas = 10;
    public float tiemporecarga = 2f;
    public int cantidaddebalascargador = 5;
    public Image Filler;
    
    public GameObject bullPreFab;

    private float FillerAmout;
    private float timeSinceLastShot = 0f;
    private bool isReloading = false;

    void Start()
    {
        timeSinceLastShot = cadencia;
        cantidaddebalascargador = numerobalas;
    }

    void Update()
    {

        UpdateFiller();
        Debug.DrawLine(shootSpawn.position, shootSpawn.position + shootSpawn.forward * 10f, Color.blue);
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 10f, Color.red);

        RaycastHit cameraHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - shootSpawn.position;
            shootSpawn.rotation = Quaternion.LookRotation(shootDirection);

            if (Input.GetKeyDown(KeyCode.Mouse0) && numerobalas > 0 && timeSinceLastShot >= cadencia && !isReloading)
            {
                Shoot();
                numerobalas--;
                timeSinceLastShot = 0f;
            }
        }

        timeSinceLastShot += Time.deltaTime;

        if ( Input.GetKeyDown(KeyCode.R) || numerobalas == 0 && !isReloading )
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
}