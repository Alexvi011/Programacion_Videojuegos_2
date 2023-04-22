using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaEnemigo : MonoBehaviour
{
    [SerializeField] int vida;

    [SerializeField] int maximoVida;

    [SerializeField] private HealthBar healthBar;
    //public int hp;
    public int da�oArma;
    public Animator anim;
    public GameObject indicador;
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
            vida -= da�oArma;
            healthBar.CambiarVidaActual(vida);
            if (vida <= 0)
            {
                healthBar.CambiarVidaActual(0);
                this.gameObject.SetActive(false);
                indicador.SetActive(false);

            }
        }

    }
    
}
