using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MvJg : MonoBehaviour
{
    public float velMovimiento = 5;
    public float velRotacion = 25;
    public float fuerzaSalto = 10;
    public float fuerzaCaida = 1;
    
    


    private Animator anim;

    public bool conArma;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public Vector3 lastCheckpoint;
    public float impulsoGolpe = 10f;


    public AudioClip golpea;
    
    public AudioClip normal;
    
    AudioSource audioSource;
    float movH, movV;

    Rigidbody rb;
    bool puedeSaltar = true;

    Vector3 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movH = Input.GetAxisRaw("Horizontal");
        movV = Input.GetAxisRaw("Vertical");

        movimiento = new Vector3(movH, 0, movV);
        anim.SetFloat("VelX", movH);
        anim.SetFloat("VelY",movV);
        if (!estoyAtacando)
        {
            transform.Translate(movimiento.normalized * velMovimiento * Time.deltaTime);
        }
        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }

        if(Input.GetKey(KeyCode.Mouse0) && puedeSaltar && !estoyAtacando) {
           
            if (conArma)
            {
                anim.SetTrigger("Golpeo");
                estoyAtacando = true;
                audioSource.PlayOneShot(golpea);
            }
            else
            {
                anim.SetTrigger("Golpeo");
                estoyAtacando = true;

            }
        }

        /*if (puedeSaltar)
        {
            transform.Translate(movimiento.normalized * velMovimiento * Time.deltaTime);

        }*/


        /*if (puedeSaltar)
        {
            transform.position += new Vector3(movH * velMovimiento, 0, movV * velMovimiento);

        }*/

        //transform.position += new Vector3(movH * velMovimiento, 0, movV * velMovimiento);

        //Normaliza en 1 el vector de movimiento en todas direcciones 

        //transform.Translate(movimiento.normalized * velMovimiento * Time.deltaTime);

        //Debug.Log(movH + ", " + movV);

        if(!estoyAtacando)
        {
            if (Input.GetButton("Jump") && puedeSaltar)
            {
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                //rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                puedeSaltar = false;
                audioSource.PlayOneShot(normal);
            }
            else
            {
                if (rb.velocity.y < 0)
                {
                    rb.AddForce(fuerzaCaida * Physics.gravity);//,ForceMode.Impulse);

                }
            }
        }
        
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }



        //Rotacion
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -velRotacion * Time.deltaTime);
        }
    }//Fin update

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respwan"))
        {
            transform.position = lastCheckpoint;

        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Suelo") || collision.transform.CompareTag("Plataforma"))
        {
            puedeSaltar = true;
        }
    }



    public void DejoDeGolpear()
    {
        estoyAtacando = false ;
        avanzoSolo = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}

