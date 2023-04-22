using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject kirby;
    public GameObject final;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Credits"))
        {

            
            kirby.SetActive(false);
            
        }

    }
}
