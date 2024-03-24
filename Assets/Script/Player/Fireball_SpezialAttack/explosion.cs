using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
   public int dmg_eplosion;


    private void Start()
    {
        Invoke("Delete", 0.25f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {          
            collision.gameObject.GetComponent<Enemy>().EnemyGetDmg(dmg_eplosion);           
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Enemy>().EnemyGetDmg(dmg_eplosion);          
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

}
