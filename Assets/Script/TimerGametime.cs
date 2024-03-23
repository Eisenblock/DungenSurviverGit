using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGametime : MonoBehaviour
{

    public Text text;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - time;

        // Formatierung der Zeit in Minuten und Sekunden
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        // Anzeige der Zeit im Textfeld
        text.text = minutes + ":" + seconds;
    }
}
