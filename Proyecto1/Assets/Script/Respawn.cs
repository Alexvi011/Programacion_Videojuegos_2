using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(gameObject);
            other.GetComponent<Combat>().lastCheckpoint=GetComponent<Transform>().position;
            this.gameObject.SetActive(false);
        }
    }


    
}
