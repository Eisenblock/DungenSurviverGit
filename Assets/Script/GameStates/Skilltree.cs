using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skilltree : MonoBehaviour
{
    public GameObject player;

    private int a_Life = 0;     // 3 mal
    private int a_Def = 0;      // 3 mal
    private int a_Doubleshoot = 0;
    private int a_Fireball = 0;

    //ALL Buttons
    public GameObject button_1; 
    public GameObject button_2; 
    public GameObject button_3; 
    public GameObject button_4;

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

   public void Skilltree_GetLife()
    {
        if (a_Life != 3)
        {
            player.GetComponent<Player>().LvL_UPLife(30);
            a_Life += 1;
        }
        else
        {
            Destroy(button_1);
        }
    }

    public void Skilltree_GetDef()
    {
        if (a_Def != 3)
        {
            player.GetComponent<Player>().LvL_UPDefense(5);
            a_Def += 1;
        }
        else
        {
            Destroy(button_2);
        }
    }

    public void Skilltree_Projectil()
    {
        if(a_Doubleshoot != 1) 
        {
            player.GetComponent<Player>().DoubleShoot();
            a_Doubleshoot += 1;
        }
        else
        {
            Destroy(button_3);
        }
       
    }

    public void Skilltree_Fireball()
    {
        if (a_Fireball != 1)
        {
            player.GetComponent<Player>().Fireball_true(); 
            a_Fireball += 1;
        }
        else
        {
            Destroy(button_4);
        }

    }
}
