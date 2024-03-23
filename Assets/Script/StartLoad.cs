using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoad : MonoBehaviour
{

    public GameObject player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().SavePlayerStats();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
