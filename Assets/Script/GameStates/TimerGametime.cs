using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerGametime : MonoBehaviour
{

    public Text text;
    public float time;
    Scene scene;
    string minutes;
    string seconds;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "SampleScene")
        {
            Debug.Log("Resetting timer...");
            elapsedTime = 0;
            text.text = elapsedTime.ToString();
        }
        else
        {
            Debug.Log("Continuing timer...");
            Timer();
        }

    }

    void Timer()
    {
        elapsedTime = Time.time - time;

        
        minutes = ((int)elapsedTime / 60).ToString("00");
        seconds = (elapsedTime % 60).ToString("00");

        
        text.text = minutes + ":" + seconds;

    }
}
