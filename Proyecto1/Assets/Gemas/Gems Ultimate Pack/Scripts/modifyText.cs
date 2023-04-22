using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class modifyText : MonoBehaviour
{

    public TextMeshProUGUI canvasText;
    public TMP_Text worldTex;
    public static int llaveText = 0;
    public static int monedas = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        //objetos.text = "Llaves: " + llaves;
        //gold.text = "Monedas: " + monedas;
    }

    // Update is called once per frame
    void Update()
    {
        canvasText.text = "x" + monedas;

        string textVarialbe = "x" + llaveText;

        worldTex.text = textVarialbe;

    }
}
