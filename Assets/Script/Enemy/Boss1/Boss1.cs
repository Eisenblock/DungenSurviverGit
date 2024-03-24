using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    //Stats
    public int bossLife;
    public int bossLifeMax; 
    public int bossDmg;
    public int attackSpeed;


    //Bullet
    public GameObject bulletBoss;
    public int lifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBoss();
    }

    public void BossGetDmg(int dmg)
    {
        bossLife -= dmg;
        Debug.Log("Bosslife" +  bossLife);
        if(bossLife == 0)
        {
            Destroy(gameObject);
        }
    }


    void ShootBoss()
    {
        if (attackSpeed == 4)
        {
            Instantiate(bulletBoss, transform.position, Quaternion.identity);
            //bulletBoss.GetComponent<Boss1_Shoot>().DestroyBullet();
            attackSpeed = 0;
        }
        else
        {
            attackSpeed += 1;
        }

        
    }
        
}
