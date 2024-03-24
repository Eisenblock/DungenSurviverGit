using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerLVL_1 : MonoBehaviour
{
    //Object Enemy
    public GameObject enemy;
    public float spawnIntervall;
    private float spawntimer;
    public Transform player;
    private Vector2 spawnPos_Zombie;

    //Object Boss
    public GameObject boss;
    private Vector2 bossPos;
    private float time;
    private float timer;

    //GameTime
    public float gameTime;

    //other Object
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
        spawnPos_Zombie = new Vector2 (0, 0);
        bossPos = new Vector2(0, 0);
        //Instantiate(player, spawnPos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
        gameTime += Time.deltaTime;
        BossComing();
    }

    private void BossComing()
    {
        if (gameTime >= timer)
        { 
        text.SetActive(true);
        Invoke("BossSpawn", 3f);
        }          
    }

    void BossSpawn()
    {
        text.SetActive(false);
        Debug.Log("Time" + gameTime);
        if (gameTime >= timer )
        {
            Instantiate(boss,bossPos,Quaternion.identity);
            gameTime = 0;
        }


    }

    void Spawner()
    {
        if(spawntimer >= spawnIntervall)
        {
            Vector2 pos = new Vector2(Random.Range(-8, 8), Random.Range(-8, 8));
            spawntimer = 0;
            Instantiate(enemy,pos , Quaternion.identity);
            spawnIntervall = spawnIntervall - 0.05f;
            if(spawnIntervall < 1)
            {
                spawnIntervall = 1;
            }
        }
        else 
        { 
            spawntimer += Time.deltaTime;
        }
    }
}
