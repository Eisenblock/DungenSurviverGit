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
    public int playerDMG;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        PosShoot();
        RotateBullet();

    }

    // Update is called once per frame
    void Update()
    {
        ShootEnemy();
    }

    private void RotateBullet()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);


        Vector3 direction = (mouseposition - player.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = lookRotation;
    }

    private void PosShoot()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z; // Entfernung der Kamera zur Szene einbeziehen
        targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        shootDirection = (targetPosition - transform.position).normalized;
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
            Debug.Log("tREFFER");
        }

        if(collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss1>().BossGetDmg(playerDMG);
            Destroy(gameObject);
            Debug.Log("Boss treffer");
        }
    }
}