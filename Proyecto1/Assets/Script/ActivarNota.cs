using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarNota : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject notaVisual;
    public GameObject objetoDesaparecer;
    public bool activa;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            notaVisual.SetActive(false);
            Destroy(this.objetoDesaparecer);
            //objetoDesaparecer.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Player")
        {
            activa = true;
            notaVisual.SetActive(true);
           
        }
        
    }
}
