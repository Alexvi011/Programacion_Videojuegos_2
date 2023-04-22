using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBoss : MonoBehaviour
{
    [SerializeField] int vida;

    [SerializeField] int maximoVida;
    public GameObject indicador;
    [SerializeField] private HealthBar healthBar;
    //public int hp;
    public int dañoArma;
    public Animator anim;

    public GameObject llaves;

    private Slider slider;

    
    public void CambiarVidaMaxima(int vidaMax)
    {
        slider.maxValue = vidaMax;
        

    }

    public void CambiarVidaActual(int Vida)
        
    {
        
        
        slider.value = Vida;
    }

    public void IniciarBarraVida(int Vida)
    {
        slider = GetComponent<Slider>();

        CambiarVidaMaxima(Vida);
        CambiarVidaActual(Vida);
    }
    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;
        healthBar.IniciarBarraVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            if(anim != null)
            {
                anim.Play("GetHit 0");
            }
            vida -= dañoArma;
            healthBar.CambiarVidaActual(vida);
            if (vida <= 0)
            {

                healthBar.CambiarVidaActual(0);
                this.gameObject.SetActive(false);



                indicador.SetActive(false);
                anim.Play("Die");
                llaves.SetActive(true);
            }
        }

    }
    
}
