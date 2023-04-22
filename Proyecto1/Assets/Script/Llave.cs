using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    
    
    public GameObject puerta;
    public GameObject llaves;
    public GameObject llave1;
    public GameObject llave2;
    public GameObject cohete;
    public GameObject estrella;
    private bool llave;
    
    
   

    private void OnTriggerEnter(Collider other)
    {       
        if(other.CompareTag("Key"))
        {
            modifyText.llaveText += 1;
            llaves.SetActive(false);
            llave = true;
    
        }
        if (other.CompareTag("Key2"))
        {
            modifyText.llaveText += 1;
            llave1.SetActive(false);
            llave = true;

        }
        if (other.CompareTag("Key3"))
        {
            modifyText.llaveText += 1;
            llave2.SetActive(false);
            llave = true;

        }
        if (llave == true && other.CompareTag("Unlock"))
        {
            puerta.SetActive(false);
            
        }
        if (llave == true && other.CompareTag("Unlock") && modifyText.llaveText==2)
        {
            
            cohete.SetActive(true);
        }
        if (llave == true && other.CompareTag("Unlock") && modifyText.llaveText == 5)
        {

            estrella.SetActive(true);
        }
    }
    
   
}
