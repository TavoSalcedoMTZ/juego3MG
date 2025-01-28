using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerLife : MonoBehaviour
{
    public int VidaPlayer; 
    private int VidaMaximaPlayer; 
    public Image Filler; 

    void Start()
    {
        VidaPlayer = 25; 
        VidaMaximaPlayer = VidaPlayer; 

        if (Filler == null)
        {
            Debug.LogError("Filler no asignado en el inspector.");
        }
    }

    void Update()
    {
        if (VidaPlayer == 0)
        {
            string escena = "GameOver";
            SceneManager.LoadScene(escena);
        }

        UpdateFiller();
    }

    void UpdateFiller()
    {
        if (Filler != null)
        {

            Filler.fillAmount = (float)VidaPlayer / VidaMaximaPlayer;
        }
    }


    public void RecibirDanio(int danio)
    {
        VidaPlayer -= danio;
        VidaPlayer = Mathf.Clamp(VidaPlayer, 0, VidaMaximaPlayer);
    }

    public void Curar()
    {
        VidaPlayer = VidaMaximaPlayer;
       
    }
}
