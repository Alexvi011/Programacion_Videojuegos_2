using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    public void cargarNivel01()
    {
        SceneManager.LoadScene("Nivel01");
    }


    public void cargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
    }
     
    
}
