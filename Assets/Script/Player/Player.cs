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


    //MovementVariables
    Rigidbody2D rb;
    private float vertical;
    private float horizontal;

    //other Objects
    public Image fillHealth;
    public GameObject bullet;
    public Vector3 mousePos;
    public GameObject LifebarPos;
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(LifebarPos);
        DontDestroyOnLoad(gameObject);
        if(scene.name == "Start_Area")
        {
            ResetPlayerStats();
        }

        rb = GetComponent<Rigidbody2D>();
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FirePlayer();
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
        
        if (Input.GetButtonDown("Jump"))
        {
                Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    public void PLayerTakeDamage(int dmg)
    {
        lifePlayer -= dmg;
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        if(lifePlayer <= 0)
        {
            //SavePlayerStats();
            ResetPlayerStats();
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

    public void LvL_UPDefense()
    {
        defense += 5;
        Debug.Log("Defense " + defense);
    }

    public void LvL_UPDMG()
    {
        dmgPlayer += 5;
        Debug.Log("DMG " + dmgPlayer);
    }

    public void LvL_UPLife()
    {
        MaxlifePlayer += 10;
        lifePlayer += 10;
        fillHealth.fillAmount = lifePlayer / MaxlifePlayer;
        //SavePlayerStats();
        Debug.Log("MaxLife: " + lifePlayer);
    }
}
