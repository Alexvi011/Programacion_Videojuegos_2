using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{

    modifyText moned;
    // Start is called before the first frame update

    private void Start()
    {
        moned = GameObject.FindGameObjectWithTag("Player").GetComponent<modifyText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            modifyText.monedas += 1;
            Destroy(gameObject);
            //this.SetActive(false);

        }
       

    }
}
