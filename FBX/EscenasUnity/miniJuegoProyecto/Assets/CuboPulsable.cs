using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTI4.Utils;

public class CuboPulsable : MonoBehaviour
{

    private RaycastHit hit;
    public string[] nombres = new string[] { "Anna", "Berto", "Xustix", "Ivi" };
    public List<int> dado = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        dado.Add(15);
        dado.Add(3);
        dado.Add(7);
        dado.Add(4);
        dado.Add(6);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform == transform)
                {
                    Debug.Log(RandomUtils.Choose(dado));
                }
            }
        }
    }

    void ProbarPonderado()
    {

        Dictionary<string, int> opciones = new Dictionary<string, int>();
        opciones.Add("A", 5);
        opciones.Add("B", 2);
        opciones.Add("C", 1);

        int vecesA = 0;
        int vecesB = 0;
        int vecesC = 0;

        for( int i = 0; i < 80; i++)
        {
            switch (RandomUtils.RandomWeighted(opciones))
            {
                case "A":
                    vecesA++;
                    break;

                case "B":
                    vecesB++;
                    break;

                case "C":
                    vecesC++;
                    break;
            }
        }

        Debug.Log("A ha salido: " + vecesA);
        Debug.Log("B ha salido: " + vecesB);
        Debug.Log("C ha salido: " + vecesC);

    }

    /*private void OnMouseDown()
    {
        Debug.Log("Click");
    }*/
}
