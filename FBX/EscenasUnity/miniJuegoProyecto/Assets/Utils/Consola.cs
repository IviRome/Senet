using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consola : MonoBehaviour
{

    public static Consola instace;

    public Text output;

    public int maxLines = 5;

    private Queue<string> lines;

    void Start()
    {
        instace = this;
        lines = new Queue<string>();
    }

    private void Print(params object[] message)
    {
        if (lines.Count == maxLines) lines.Dequeue();
        lines.Enqueue(string.Join(" / ", message));
        output.text = string.Join("\n", lines);
    }

    public static void Log(params object[] message)
    {
        instace.Print(message);
    }
}
