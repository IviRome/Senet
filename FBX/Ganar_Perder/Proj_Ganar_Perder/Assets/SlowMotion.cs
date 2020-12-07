using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    public float slowFactor = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = Time.timeScale * .05f;
    }
}
