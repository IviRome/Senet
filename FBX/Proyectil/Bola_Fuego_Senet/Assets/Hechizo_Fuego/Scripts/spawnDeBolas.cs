using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnDeBolas : MonoBehaviour
{

    public GameObject laBola;
    public bool seHaDisparadoLaBola;
    private float currentTime;
    private float maxTime;
    public GameObject elBoton;
    private Button btn;


    // Start is called before the first frame update
    void Start()
    {
        seHaDisparadoLaBola = false;
        
        elBoton = GameObject.Find("btn_shoot");
        btn = elBoton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        maxTime = 0.5f;
    }

    void TaskOnClick()
    {
        GameObject a = Instantiate(laBola, transform.position, laBola.transform.rotation);
        a.GetComponent<Script_Hechizo_Fuego>().cambiarDispararBolaATrue();
        seHaDisparadoLaBola = true;
    }


    // Update is called once per frame
    void Update()
    {
        /*if( seHaDisparadoLaBola )
        {
            Debug.Log("Va a spawnear otra");
            currentTime += Time.deltaTime;

            if( currentTime >= maxTime)
            {
                Instantiate(laBola, transform.position, laBola.transform.rotation);
                seHaDisparadoLaBola = false;
                currentTime = 0;
            }
            
        }*/
        
    }
}
