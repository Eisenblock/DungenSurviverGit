using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ColliderEnemy : MonoBehaviour
{
    public float attackSpeed;
    public GameObject player;
    public float lifeEnemy;
    public float MaxlifeEnemy;
    public int zombieDmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        float timer = 0;
        timer += Time.deltaTime;

        if (timer >= attackSpeed)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.GetComponent<Player>().PLayerTakeDamage(zombieDmg);
            }
        }
    }

    public void EnemyGetDmg(int dmg)
    {
        lifeEnemy -= dmg;
        Debug.Log("LifeEnemy" + lifeEnemy);
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
            //target.GetComponent<Player>().PlayerEXP(expGet);
        }
    }
}
