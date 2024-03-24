using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    [SerializeField] GameObject panel;

    //stats player
    public float lifePlayer;
    public float MaxlifePlayer;
    public int dmgPlayer;
    public int defense;
    public int speedPlayer;
    int expPlayer = 0;
    public bool doubleShoot;

    //All Bool
    bool doubleShoot2;
    public bool fireball_bool;
    public bool fire;

    //MovementVariables
    Rigidbody2D rb;
    private float vertical;
    private float horizontal;

    //other Objects
    public Image fillHealth;
    public GameObject bullet;
    public Vector3 mousePos;
    public GameObject LifebarPos;
    public GameObject fireball;
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(LifebarPos);
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FirePlayer();
        FireBall_Spezial();
    }

    void MovePlayer()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);


        Vector3 direction = (mouseposition - transform.position ).normalized ;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction );
        transform.rotation = lookRotation;
        rb.velocity = new Vector2(horizontal * speedPlayer, vertical * speedPlayer);
    }

    void FirePlayer()
    {
        if (fire == true)
        {
            if (Input.GetButtonDown("Jump"))
            {

                if (doubleShoot == true)
                {
                    Debug.Log("Double shoot activated!");
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    Vector2 go = new Vector2(transform.position.x - 1, transform.position.y);
                    Instantiate(bullet, go, Quaternion.identity);
                    fire = false;
                    Invoke("Fire_AtkSpeed", 1f);
                }
                else
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    fire = false;
                    Invoke("Fire_AtkSpeed", 1f);
                }
            }
        }
    }

    private void Fire_AtkSpeed()
    {
        fire = true;
    }

    public void PLayerTakeDamage(int dmg)
    {
        lifePlayer -= dmg;
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        if(lifePlayer <= 0)
        {
            //SavePlayerStats();
            //ResetPlayerStats();
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SavePlayerStats()
    {
        // Spielerstatistiken in PlayerPrefs speichern
        PlayerPrefs.SetInt("LifePlayer", (int) lifePlayer);
        PlayerPrefs.SetInt("MaxHealth", (int)MaxlifePlayer);

        // PlayerPrefs speichern
        PlayerPrefs.Save();

        Debug.Log("Player stats saved." + lifePlayer +" maxlife " + MaxlifePlayer);
    }

    public void ResetPlayerStats()
    {
        // Spielerstatistiken in PlayerPrefs speichern
        PlayerPrefs.SetInt("LifePlayer", 10);
        PlayerPrefs.SetInt("MaxHealth", 10);

        // PlayerPrefs speichern
        PlayerPrefs.Save();

        Debug.Log("Player stats saved." + lifePlayer + " maxlife " + MaxlifePlayer);
    }

    public void LoadPlayerStats()
    {
        // Spielerstatistiken aus PlayerPrefs laden
        lifePlayer = PlayerPrefs.GetInt("LifePlayer");
        MaxlifePlayer = PlayerPrefs.GetInt("MaxHealth");

        Debug.Log("Player stats loaded." + lifePlayer + " maxlife " + MaxlifePlayer);
    }

    public void PlayerEXP(int exp)
    {
        expPlayer += exp; 
        Debug.Log("EXP: " + expPlayer);

        if(expPlayer >= 100)
        {
            expPlayer = 0;
            //SavePlayerStats();
            Time.timeScale = 0.0f; 
            panel.SetActive(true);
            
        }
    }

    public void LvL_UPDefense(int def)
    {
        defense += def;
        Debug.Log("Defense " + defense);
    }

    public void LvL_UPDMG(int dmg)
    {
        dmgPlayer += dmg;
        Debug.Log("DMG " + dmgPlayer);
    }

    public void LvL_UPLife(int life)
    {
        MaxlifePlayer += life;
        lifePlayer += life;
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        //SavePlayerStats();
        Debug.Log("MaxLife: " + lifePlayer);
    }

    public void DoubleShoot()
    {
        doubleShoot = true;
        Debug.Log("DoubleShoot : true " + doubleShoot);
    }
    public void Fireball_true()
    {
        fireball_bool = true;
    }

    public void FireBall_Spezial()
    {
        if (fireball_bool == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(fireball, transform.position, Quaternion.identity);
                Debug.Log("Fireball" + fireball);      
                fireball_bool = false;
                Invoke("Fireball_AtkSpeed", 1f);
            }
        }
    }

    private void Fireball_AtkSpeed()
    {
        fireball_bool = true;
    }
   
}
