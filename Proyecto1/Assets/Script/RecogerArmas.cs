using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArmas : MonoBehaviour
{

    public GameObject[] armas;

    public BoxCollider[] armasBoxCol;

    public MvJg logicaPersonaje1;

    // Start is called before the first frame update
    void Start()
    {
        
        DesactivarCollidersArmas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarArmas(int numero)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);
        armas[0].SetActive(true);
        armas[1].SetActive(true);

        logicaPersonaje1.conArma = true;
    }

    public void ActivarCollidersArmas()
    {
        for (int i = 0; i < armasBoxCol.Length; i++)
        {   

            if (logicaPersonaje1.conArma)
            {
                if (armasBoxCol[i] != null)
                {
                    armasBoxCol[i].enabled = true;
                }
            }
        }  
    }

    public void DesactivarCollidersArmas()
    {
        for(int i=0; i< armasBoxCol.Length; i++)
        {
            if (armasBoxCol[i] !=null)
            {
                armasBoxCol[i].enabled = false;
            }
        }
    }
}
