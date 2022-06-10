using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    public Itemss items;

    Uimanager uimanager;

    private void Start()
    {
        uimanager = GameObject.FindObjectOfType<Uimanager>();
    }

    public void ShowDetails()
    {
        uimanager.itemdetailspanel.SetActive(true);
        uimanager.item_name.text = this.items.name.ToString();
        if (items.damage != 0)
        {
            uimanager.details.text = items.damage.ToString();
        }

        else
        {
            uimanager.details.text = "";
        }
    }


    /*void DropItem()
    {
        if (this.transform.childCount > 1)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                if (this.gameObject.transform.GetChild(i).GetComponent<Spawn>() != null)
                {
                    this.gameObject.transform.GetChild(i).GetComponent<Spawn>().Item_Spawner();

                    GameObject.Destroy(this.gameObject.transform.GetChild(i).gameObject);

                    break;
                }
            }
        }
    }

    public void Item_Spawner()
    {
       Destroy(this.gameObject);
    }*/
}
