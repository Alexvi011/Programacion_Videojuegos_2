using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control1HP : MonoBehaviour
{
    public GameObject[] vidaJugador;
    private int indiceVidas = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            vidaJugador[indiceVidas].SetActive(false);
            indiceVidas++;

            if (indiceVidas < 0)
            {
                Debug.Log("Fin del juego");
                //Falta pantalla

            }
        }
    }
}
