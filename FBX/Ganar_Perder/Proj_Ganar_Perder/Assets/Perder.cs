using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perder : MonoBehaviour
{

    public GameObject FichaOriginal;
    public GameObject FichaFracturada;
    public GameObject explosion;

    public Image fade;
    public Text perder;

    private float timer = 0.7f;

    private bool fadeOn = false;


     void Start()
    {
        perder.canvasRenderer.SetAlpha(0.0f);
        fade.canvasRenderer.SetAlpha(0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFichaFracturada();

        }

        if (fadeOn == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                perder.CrossFadeAlpha(1, 4f, false);
            }
            
            
        }
    }


    public void SpawnFichaFracturada()
    {
        Destroy(FichaOriginal);
       

        GameObject fractObj = Instantiate(FichaFracturada) as GameObject;
        
        fractObj.GetComponent<Explosion_Perder>().Explode();

        Destroy(Instantiate(explosion, FichaOriginal.transform.position, FichaOriginal.transform.rotation), 0.5f);
        fade.CrossFadeAlpha(1, 0.5f, false);
        fadeOn = true;
        
    }


    
        
       

     

}
