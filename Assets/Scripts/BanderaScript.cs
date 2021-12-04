using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BanderaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SlimeMovement slime = other.GetComponent<SlimeMovement>();
        if (slime != null)
        {
            //Debug.Log("Win");
            SceneManager.LoadScene("FinDelJuego");
        }
    }

}
