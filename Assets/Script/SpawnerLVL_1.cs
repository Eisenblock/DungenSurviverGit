using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLVL_1 : MonoBehaviour
{

    public GameObject enemy;
    public float spawnIntervall;
    private float spawntimer;
    public Transform player;
    private Vector2 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector2 (0, 0);
        //Instantiate(player, spawnPos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        Spawner(); 
    }

    void Spawner()
    {
        if(spawntimer >= spawnIntervall)
        {
            Vector2 pos = new Vector2(Random.Range(-8, 8), Random.Range(-8, 8));
            spawntimer = 0;
            Instantiate(enemy,pos , Quaternion.identity);
            spawnIntervall = spawnIntervall - 0.05f;
        }
        else 
        { 
            spawntimer += Time.deltaTime;
        }
    }
}
