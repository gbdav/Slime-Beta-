using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

public class SinVidasManagerScript : MonoBehaviour
{
    public void VolverAJugar()
    {
        SceneManager.LoadScene("Juego");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
