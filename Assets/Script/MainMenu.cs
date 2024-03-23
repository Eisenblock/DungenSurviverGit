using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    //[SerializeField] Text panelText;
    PauseManager pauseManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           if(panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }       
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
        //panelText.gameObject.SetActive(true);
    }
}
