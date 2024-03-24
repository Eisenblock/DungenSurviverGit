using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Enemy : MonoBehaviour
{

    //stats Enemy : Cow
    public float attackSpeed;  
    public float lifeEnemy;
    public float MaxlifeEnemy;
    public int zombieDmg;
    public int expGet;
    public int zombieSpeed;
    float timer = 0;

    //MovementVariables
    Rigidbody2D rb;
    public Vector2 posCow;

    //other Objects
    private Transform target;
    public GameObject blood;

    

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
        timer += Time.deltaTime;
    }

    void MoveEnemy()
    {
        Vector3 pos = target.position - transform.position;
        pos.Normalize();
        rb.velocity = pos * zombieSpeed;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {      
        if (timer >= attackSpeed)
        {
            timer = 0;
            if (collision.gameObject.CompareTag("Player"))
            {
                target.GetComponent<Player>().PLayerTakeDamage(zombieDmg);
            }
        }
    }

    public void EnemyGetDmg(int dmg)
    {
        lifeEnemy -= dmg;
        Debug.Log("LifeEnemy" + lifeEnemy);
        blood.SetActive(true);
        Invoke("BloodFalse", 1f);
        if (lifeEnemy <= 0)
        {
            target.GetComponent<Player>().PlayerEXP(expGet);
            Destroy(gameObject);           
        }
    }

    private void BloodFalse()
    {
        blood.SetActive(false);
    }

}

   