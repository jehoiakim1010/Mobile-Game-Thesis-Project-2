using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combine : MonoBehaviour
{

    playerMovement playermovement;

    Uimanager uimanager;
    inventory inv;
    //Sword
    bool bronze1;
    bool silver1;
    int silverArray1;
    int bronzeArray1;
    //public GameObject Sword;

    //Axe
    bool bronze2;

    bool silver2;

    int silverArray2;
    int bronzeArray2;

    //Double Axe
    bool bronze3;

    bool silver3;

    int silverArray3;
    int bronzeArray3;
    GameObject Player;

    string Weapon;
    Button FirstSword, Axe, Double_Axe;

    // Start is called before the first frame update
    void Start()
    {
        uimanager = GameObject.FindObjectOfType<Uimanager>() as Uimanager;

        inv = GameObject.FindObjectOfType<inventory>() as inventory;
        Player = GameObject.FindWithTag("Player");

        if (this.gameObject.name == "Combine Sword")
        {
            FirstSword = this.gameObject.GetComponent<Button>();
        }

        else if (this.gameObject.name == "Combine Axe")
        {
            Axe = this.gameObject.GetComponent<Button>();
        }

        else if (this.gameObject.name == "Combine Double Axe")
        {
            Double_Axe = this.gameObject.GetComponent<Button>();
        }

        playermovement = Player.GetComponent<playerMovement>();
    }

    // Update is called once per frame

    void Update()
    {

        SwordCrafting();

        AxeCrafting();

        DoubleAxeCrafting();

        //enable crafting materials for weapon

        if (this.gameObject.name == "Combine Sword")
        {
            if (bronze1 && silver1)
            {
                FirstSword.interactable = true;
            }
            else
            {
                FirstSword.interactable = false;
            }
        }

        if (this.gameObject.name == "Combine Axe")
        {
            if (bronze2 && silver2)
            {
                Axe.interactable = true;
            }
            else
            {
                Axe.interactable = false;
            }
        }

        if (this.gameObject.name == "Combine Double Axe")
        {
            if (bronze3 && silver3)
            {
                Double_Axe.interactable = true;
            }
            else
            {
                Double_Axe.interactable = false;
            }
        }

    }

    void DoubleAxeCrafting()
    {
        //Double Axe Upgrade
        //Get items from inventory
        //Second Item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 8)
                {
                    bronze3 = true;
                    bronzeArray3 = i;
                }
            }

            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[bronzeArray3].transform.childCount < 8)
                    {
                        bronze3 = false;
                        bronzeArray3 = 0;

                    }
                }
            }
        }

        //Second Item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 8)
                {
                    silver3 = true;
                    silverArray3 = i;
                }
            }
            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[silverArray3].transform.childCount < 8)
                    {
                        silver3 = false;
                        silverArray3 = 0;

                    }
                }
            }
        }
    }
    void AxeCrafting()
    {
        //Axe Upgrade
        //Get items from inventory
        //Second Item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 4)
                {
                    bronze2 = true;
                    bronzeArray2 = i;
                }
            }

            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[bronzeArray2].transform.childCount < 4)
                    {
                        bronze2 = false;
                        bronzeArray2 = 0;

                    }
                }
            }
        }

        //Second Item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 4)
                {
                    silver2 = true;
                    silverArray2 = i;
                }
            }
            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[silverArray2].transform.childCount < 4)
                    {
                        silver2 = false;
                        silverArray2 = 0;

                    }
                }
            }
        }
    }
    void SwordCrafting()
    {
        //Bronze
        //Get items from inventory
        //First item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 2)
                {
                    bronze1 = true;
                    bronzeArray1 = i;
                }
            }

            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[bronzeArray1].transform.childCount < 2)
                    {
                        bronze1 = false;
                        bronzeArray1 = 0;

                    }
                }
            }
        }

        //Silver
        //Get items from inventory
        //First item
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 2)
                {
                    silver1 = true;
                    silverArray1 = i;
                }
            }
            else
            {
                if (inv.GameObject_Slots[i] == "")
                {
                    if (inv.slots[silverArray1].transform.childCount < 2)
                    {
                        silver1 = false;
                        silverArray1 = 0;

                    }
                }
            }
        }
    }
    public void CombineSword()
    {

        if (bronze1 && silver1)
        {
            playermovement.isCrafting = true;

            Weapon = "Sword";


            ES3.Save("Player Sword", Weapon);

            uimanager.Sword = ES3.Load<string>("Player Sword");

            //Instantiate(Sword, Player.transform.position + new Vector3(0.0f, 0.5f, 0.5f), Quaternion.identity);

            for (int i = 0; i < inv.GameObject_Slots.Length; i++)
            {
                if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 2)
                    {
                        for (int a = 1; a < 3; a++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(a).gameObject);
                        }
                    }
                }

                if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 2)
                    {
                        for (int b = 1; b < 3; b++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(b).gameObject);
                        }
                    }
                }
            }
        }
    }

    public void Combine_Item_Axe()
    {
        if (bronze2 && silver2)
        {
            playermovement.isCrafting = true;

            Weapon = "Axe";

            ES3.Save("Player Sword", Weapon);

            uimanager.Sword = ES3.Load<string>("Player Sword");
            
            //Instantiate(Sword, Player.transform.position + new Vector3(0.0f, 0.5f, 0.5f), Quaternion.identity);

            for (int i = 0; i < inv.GameObject_Slots.Length; i++)
            {
                if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 4)
                    {
                        for (int a = 1; a < 5; a++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(a).gameObject);
                        }
                    }
                }

                if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 4)
                    {
                        for (int b = 1; b < 5; b++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(b).gameObject);
                        }
                    }
                }
            }
        }
    }

    public void Combine_Item_Double_Axe()
    {
        if (bronze3 && silver3)
        {
            playermovement.isCrafting = true;

            Weapon = "Double Axe";

            ES3.Save("Player Sword", Weapon);

            uimanager.Sword = ES3.Load<string>("Player Sword");

            //Instantiate(Sword, Player.transform.position + new Vector3(0.0f, 0.5f, 0.5f), Quaternion.identity);

            for (int i = 0; i < inv.GameObject_Slots.Length; i++)
            {
                if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 8)
                    {
                        for (int a = 1; a < 9; a++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(a).gameObject);
                        }
                    }
                }

                if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
                {
                    if (inv.slots[i].transform.childCount > 8)
                    {
                        for (int b = 1; b < 9; b++)
                        {
                            Destroy(inv.slots[i].gameObject.transform.GetChild(b).gameObject);
                        }
                    }
                }
            }
        }
    }
}
