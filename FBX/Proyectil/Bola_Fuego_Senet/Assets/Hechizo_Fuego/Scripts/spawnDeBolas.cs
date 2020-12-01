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

    // Start is called before the first frame update
    void Start()
    {
        seHaDisparadoLaBola = false;
        Instantiate(laBola, transform.position, laBola.transform.rotation);
        maxTime = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        if( seHaDisparadoLaBola )
        {
            Debug.Log("Va a spawnear otra");
            currentTime += Time.deltaTime;

            if( currentTime >= maxTime)
            {
                Instantiate(laBola, transform.position, laBola.transform.rotation);
                seHaDisparadoLaBola = false;
                currentTime = 0;
            }
            
        }
        
    }
}
