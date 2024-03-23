using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private Vector3 targetPosition;
    public Vector3 mousePosition;
    private Vector3 shootDirection;
    Rigidbody2D rb;

    //Player stats
    private int playerDMG;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDMG = player.GetComponent<Player>().dmgPlayer;
        mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z; // Entfernung der Kamera zur Szene einbeziehen
        targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        shootDirection = (targetPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        ShootEnemy();
    }

    void ShootEnemy()
    {
     
            rb.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            Destroy(gameObject, lifeTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().EnemyGetDmg(playerDMG);
            Destroy(gameObject);
        }
    }
}