using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MvEnemigo : MonoBehaviour
{
    public Transform[] puntosDestino;

    public Animator anim;


    private NavMeshAgent agente;
    private int contador = 0;
    private bool siguiendoJugador = false;

    float movH, movV;
    private SphereCollider arePer;
    public float TimeDamage;
    float nextDamageTime;
    public GameObject indicador;
      
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();   
        arePer = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (!siguiendoJugador)
        {
            if (agente.remainingDistance < 2)
            {
                contador++;

                if (contador >= puntosDestino.Length)
                {
                    contador = 0;
                }

                agente.SetDestination(puntosDestino[contador].position);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            arePer.radius = 6.0f;
            agente.speed = 6;
            
            //other.GetComponent<Combat>().Daño(15);
            anim.Play("Attack02 0");
            indicador.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Attack01");
            agente.SetDestination(other.transform.position);
            siguiendoJugador = true;
            indicador.SetActive(true);





            nextDamageTime += Time.deltaTime;
            if (nextDamageTime > TimeDamage)
            {
                other.GetComponent<Combat>().Daño(15);
                nextDamageTime = 0.0f;
            }



        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agente.SetDestination(puntosDestino[contador].position);
            siguiendoJugador = false;
            arePer.radius = 3f;
            agente.speed = 3;
            //anim.Play("Attack02 0");
            indicador.SetActive(false);
        }
    }
}
