using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Enemy : MonoBehaviour
{

    //stats Enemy : Cow
    public float lifeEnemy;
    public float MaxlifeEnemy;
    public int dmgCow;
    public int speedCow;
    public float spawnIntervall;
    public float attackSpeed;
    public int expGet;

    //MovementVariables
    Rigidbody2D rb;
    public Vector2 posCow;

    //other Objects
    private Transform target;
    public GameObject cow;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        Vector3 pos = target.position - transform.position;
        pos.Normalize();
        rb.velocity = pos * speedCow;
        
    }

    void SpawnEnemy()
    {
        float spawntimer = 0;
        spawntimer += Time.deltaTime;

        if(spawntimer >= spawnIntervall)
        {           

        spawntimer = 0;
        posCow = new Vector2(Random.Range(-8, 8), Random.Range(-8, 8));
        Instantiate(cow, posCow, Quaternion.identity);
        }   
    }

    public void EnemyGetDmg(int dmg)
    {
        lifeEnemy -= dmg;
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
            target.GetComponent<Player>().PlayerEXP(expGet);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        float timer = 0;
        timer += Time.deltaTime;

        if (timer >= attackSpeed)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                target.GetComponent<Player>().PLayerTakeDamage(dmgCow);
            }
        }
    }
}

   