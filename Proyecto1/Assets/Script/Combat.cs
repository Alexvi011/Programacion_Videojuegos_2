using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int vida;

    [SerializeField] int maximoVida;
    public GameObject [] vidas;
    public Vector3 lastCheckpoint;

    public Lifes lifes;
    public AudioClip dano;
    AudioSource audioSource;

    [SerializeField] private HealthBar healthBar; 
    void Start()
    {
        vida = maximoVida;
        healthBar.IniciarBarraVida(vida);
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Life"))
        {
           vidas[0].SetActive(false);
           vida += 50;
            if (vida > 100)
            {
                vida = 100;
                healthBar.CambiarVidaActual(100);
            }
            else
            {
                healthBar.CambiarVidaActual(vida);
            }
            
        }

        if (other.CompareTag("Life2"))
        {
            vidas[1].SetActive(false);
            vida += 50;
            if (vida > 100)
            {
                vida = 100;
                healthBar.CambiarVidaActual(100);
            }
            else
            {
                healthBar.CambiarVidaActual(vida);
            }

        }
        if (other.CompareTag("Life3"))
        {
            vidas[2].SetActive(false);
            vida += 50;
            if (vida > 100)
            {
                vida = 100;
                healthBar.CambiarVidaActual(100);
            }
            else
            {
                healthBar.CambiarVidaActual(vida);
            }

        }
        if (other.CompareTag("Life4"))
        {
            vidas[3].SetActive(false);
            vida += 50;
            if (vida > 100)
            {
                vida = 100;
                healthBar.CambiarVidaActual(100);
            }
            else
            {
                healthBar.CambiarVidaActual(vida);
            }

        }
    }




    public void Daño(int daño)
    {
        vida -= daño;
        audioSource.PlayOneShot(dano);
        healthBar.CambiarVidaActual(vida);
        if (vida < 0)
        {
            healthBar.CambiarVidaActual(0);
            transform.position = lastCheckpoint;
            healthBar.CambiarVidaActual(100);
            vida = 100;

        }
    }
    // Update is called once per frame
  
}
