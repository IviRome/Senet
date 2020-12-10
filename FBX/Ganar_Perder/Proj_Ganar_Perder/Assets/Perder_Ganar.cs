using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perder_Ganar : MonoBehaviour
{

    public GameObject FichaOriginal;
    public GameObject FichaFracturada;
    public GameObject explosion;

    public GameObject explosion_luz;

    public Image fade_perder;
    public Text texto_perder;

    public Image fade_ganar;
    //public Text texto_ganar;

    private float timer = 0.7f;

    public SlowMotion tok;

    public Animator anim_ganar;
    private bool esta_animando= false;

    void Start()
    {
        anim_ganar = GetComponent<Animator>();
        texto_perder.canvasRenderer.SetAlpha(0.0f);
        fade_perder.canvasRenderer.SetAlpha(0.0f);
        fade_ganar.canvasRenderer.SetAlpha(0.0f);
    }
    // Update is called once per frame
    void Update()
    {

       

        if (Input.GetMouseButtonDown(0))
        {

            Start_Ganar();

            //Start_Perder();

        }
    }

    public void Start_Perder()
    {

        SpawnFichaFracturada();
        tok.GetComponent<SlowMotion>().toquen = true;

        fade_perder.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(fade_text_perder());


    }

    public void Start_Ganar()
    {
        tok.GetComponent<SlowMotion>().toquen = true;
        fade_ganar.CrossFadeAlpha(1, 0.5f, false);
        anim_ganar.SetBool("esta_animando",true);

        Destroy(Instantiate(explosion_luz, FichaOriginal.transform.position, FichaOriginal.transform.rotation), 0.5f);
    }


    public void SpawnFichaFracturada()
    {
        Destroy(FichaOriginal);


        GameObject fractObj = Instantiate(FichaFracturada) as GameObject;

        fractObj.GetComponent<Explosion_Perder>().Explode();

        Destroy(Instantiate(explosion, FichaOriginal.transform.position, FichaOriginal.transform.rotation), 0.5f);



    }

     IEnumerator fade_text_perder()
    {

        yield return new WaitForSeconds(0.5f);
        texto_perder.CrossFadeAlpha(1, 0.5f, false);
      
    }

    IEnumerator fade_animacion_ganar()
    {

        yield return new WaitForSeconds(10f);
        anim_ganar.Play("anim_ganar");

    }
}


    
        
       

