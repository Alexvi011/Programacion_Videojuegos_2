using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

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
    // Update is called once per frame

}

