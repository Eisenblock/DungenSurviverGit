using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Shoot : MonoBehaviour
{
    private Vector2 direction;
    public Transform target;
    private Rigidbody2D rb;
    public int speedBullet;

    //Stats Boss
    public int dmgBoss;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
        direction = (target.transform.position - transform.position ).normalized;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(direction.x * speedBullet, direction.y * speedBullet);
        Destroy(gameObject, 4);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject, 4);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PLayerTakeDamage(dmgBoss);
        }
    }
}
