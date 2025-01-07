using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform shootSpawn;
    public bool shooting = false;

    public GameObject bullPreFab;

    void Start()
    {
    }

    void Update()
    {
        // Línea azul para visualizar el forward de shootSpawn
        Debug.DrawLine(shootSpawn.position, shootSpawn.position + shootSpawn.forward * 10f, Color.blue);

        // Línea roja para visualizar el forward de la cámara principal
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * 10f, Color.red);

        RaycastHit cameraHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - shootSpawn.position;
            shootSpawn.rotation = Quaternion.LookRotation(shootDirection);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bullPreFab, shootSpawn.position, shootSpawn.rotation);
    }
}
