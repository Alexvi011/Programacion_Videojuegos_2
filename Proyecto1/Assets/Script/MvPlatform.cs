using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvPlatform : MonoBehaviour
{
    public GameObject[] puntosDestino;
    public float velocidadPlataforma = 1;

    int indexPuntosDestino = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, puntosDestino[indexPuntosDestino].transform.position)< 0.1f)
        {
            indexPuntosDestino++;
            if(indexPuntosDestino >= puntosDestino.Length)
            {
                indexPuntosDestino = 0;
            }
        }

        transform.position = Vector3.MoveTowards(this.transform.position, puntosDestino[indexPuntosDestino].transform.position,velocidadPlataforma * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
