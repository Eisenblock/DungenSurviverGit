using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLUP : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LvL_UPDmg()
    {
        player.GetComponent<Player>().LvL_UPDMG();
        SceneManager.UnloadSceneAsync("LvL_UP_Scene");
        Time.timeScale = 1.0f;
    }
    public void LvL_UPDefense()
    {
        player.GetComponent<Player>().LvL_UPDefense();
        SceneManager.UnloadSceneAsync("LvL_UP_Scene");
        Time.timeScale = 1.0f;
    }

    public void LvL_UPLife()
    {
        player.GetComponent<Player>().LvL_UPLife();
        SceneManager.UnloadSceneAsync("LvL_UP_Scene");
        Time.timeScale = 1.0f;
    }
}
