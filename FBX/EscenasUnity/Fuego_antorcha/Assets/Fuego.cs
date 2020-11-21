using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public float intensidad = 1.5f;

    public float minIntensidad = 0.5f;

    public float maxIntensidad = 1.5f;

    public float velocidad = 5;

    public bool fuegoCambia = false;

    // Update is called once per frame
    void Update()
    {

        CambiarIntensidad();
        
    }

    void CambiarIntensidad()
    {
        this.GetComponent<Light>().intensity = intensidad;

        if(intensidad <= minIntensidad)
        {
            fuegoCambia = false;
        }

        if(intensidad >= maxIntensidad)
        {
            fuegoCambia = true;
        }

        if(fuegoCambia == true)
        {
            intensidad -= velocidad * Time.deltaTime;
        }

        if(fuegoCambia == false)
        {
            intensidad += velocidad * Time.deltaTime;
        }

    }
}
