using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    public TextMeshProUGUI item_name;

    inventory inv;
    public GameObject itemdetailspanel;

    public TextMeshProUGUI details;

    GameObject Player;

    GameObject Respawn;

    HealthBar CHealth;

    Scene Scenename;

    GameObject Canvas;

    GameObject Bag, Minimap;

    GameObject UpgradePanel;

    Image CurrentSword;
    TextMeshProUGUI CurrentDamage;

    //Upgrade
    public string Sword;

    Button btn_Upgrade;

    bool OpenUpgradePanel;

    public int Sword_damage = 10;

    public int Axe_Damage = 20;

    public int Double_Axe_damage = 30;

    bool bronze;
    int bronzeArray;

    bool silver;

    int silverArray;
    // Start is called before the first frame update
    void Start()
    {
        item_name = GameObject.Find("/Canvas/itemdisplay/itemname").GetComponent<TextMeshProUGUI>();
        itemdetailspanel = GameObject.Find("/Canvas/itemdisplay").gameObject;
        details = GameObject.Find("/Canvas/itemdisplay/Description/details").GetComponent<TextMeshProUGUI>();
        UpgradePanel = GameObject.Find("/Canvas/UpgradePanel").gameObject;
        itemdetailspanel.SetActive(false);

        Player = GameObject.FindWithTag("Player");
        Respawn = GameObject.Find("/Respawn");
        CHealth = GameObject.FindObjectOfType<HealthBar>();

        inv = Player.GetComponent<inventory>();

        Bag = GameObject.Find("/Canvas/inventory/BagPanel").gameObject;

        Minimap = GameObject.Find("/Canvas/Minimap UI").gameObject;

        CurrentSword = GameObject.Find("/Canvas/UpgradePanel/CurrentWeapon").GetComponent<Image>();
        CurrentDamage = GameObject.Find("/Canvas/UpgradePanel/CurrentLevel").GetComponent<TextMeshProUGUI>();
        btn_Upgrade = GameObject.Find("/Canvas/UpgradePanel/Upgrade").GetComponent<Button>();

        if (ES3.KeyExists("Player Sword"))
        {
            Sword = ES3.Load<string>("Player Sword");

            Sword_damage = ES3.Load<int>("Sword Damage");

            Axe_Damage = ES3.Load<int>("Axe Damage");

            Double_Axe_damage = ES3.Load<int>("Double Axe Damage");
        }

        UpgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (UpgradePanel.activeSelf == true)
        {
            if (ES3.KeyExists("Player Sword"))
            {
                for (int i = 0; i < inv.GameObject_Slots.Length; i++)
                {
                    if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
                    {
                        if (inv.slots[i].transform.childCount > 10)
                        {
                            bronze = true;
                            bronzeArray = i;
                        }
                    }

                    else
                    {
                        if (inv.GameObject_Slots[i] == "")
                        {
                            if (inv.slots[bronzeArray].transform.childCount < 10)
                            {
                                bronze = true;
                                bronzeArray = 0;

                            }
                        }
                    }
                }

                //Second Item
                for (int i = 0; i < inv.GameObject_Slots.Length; i++)
                {
                    if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
                    {
                        if (inv.slots[i].transform.childCount > 10)
                        {
                            silver = true;
                            silverArray = i;
                        }
                    }
                    else
                    {
                        if (inv.GameObject_Slots[i] == "")
                        {
                            if (inv.slots[silverArray].transform.childCount < 10)
                            {
                                silver = false;
                                silverArray = 0;

                            }
                        }
                    }
                }

                if (silver && bronze)
                {
                    btn_Upgrade.interactable = true;
                }
                else
                {
                    btn_Upgrade.interactable = false;
                }

                if (Sword == "Sword")
                {
                    CurrentSword.sprite = Resources.Load<Sprite>("Sword");

                    CurrentDamage.text = "Damage: " + Sword_damage.ToString("0");
                }

                else if (Sword == "Axe")
                {
                    CurrentSword.sprite = Resources.Load<Sprite>("Axe");

                    CurrentDamage.text = "Damage: " + Axe_Damage.ToString("0");
                }

                else if (Sword == "Double Axe")
                {
                    CurrentSword.sprite = Resources.Load<Sprite>("Double Axe");

                    CurrentDamage.text = "Damage: " + Double_Axe_damage.ToString("0");
                }


            }
            else
            {
                CurrentSword.sprite = null;
                CurrentDamage.text = null;
                btn_Upgrade.interactable = false;
            }


        }

        Scenename = SceneManager.GetActiveScene();

        if (Canvas != null)
        {

            if (Scenename.name == "Menu")
            {
                if (Canvas.activeSelf == true)
                {
                    Canvas.SetActive(false);
                }
            }
            else
            {
                if (Canvas.activeSelf == false)
                {
                    Canvas.SetActive(true);
                }

                if (Bag.activeSelf == true || UpgradePanel.activeSelf == true)
                {
                    Minimap.SetActive(false);
                }
                else
                {
                    Minimap.SetActive(true);
                }

                if (OpenUpgradePanel == true)
                {
                    UpgradePanel.SetActive(true);
                    Bag.SetActive(false);
                }
                else
                {
                    UpgradePanel.SetActive(false);
                }
            }

        }
        else
        {
            Canvas = GameObject.Find("/Canvas");
        }

    }

    public void Upgrade()
    {
        for (int i = 0; i < inv.GameObject_Slots.Length; i++)
        {
            if (inv.GameObject_Slots[i] == "bronze ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 10)
                {
                    for (int a = 1; a < 11; a++)
                    {
                        Destroy(inv.slots[i].gameObject.transform.GetChild(a).gameObject);
                    }
                }
            }

            if (inv.GameObject_Slots[i] == "silver ore UI(Clone)")
            {
                if (inv.slots[i].transform.childCount > 10)
                {
                    for (int b = 1; b < 11; b++)
                    {
                        Destroy(inv.slots[i].gameObject.transform.GetChild(b).gameObject);
                    }
                }
            }
        }

        if (Sword == "Sword")
        {
            Sword_damage += 5;
        }

        else if (Sword == "Axe")
        {
            Axe_Damage += 5;
        }

        else if (Sword == "Double Axe")
        {
            Double_Axe_damage += 5;
        }
    }
    void Awake()
    {
        Canvas = GameObject.Find("/Canvas");

        Time.timeScale = 1.0f;
    }

    public void OpenUpgrade()
    {
        OpenUpgradePanel = !OpenUpgradePanel;
    }

    public void ItemDetailsClose()
    {
        itemdetailspanel.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Player.transform.position = Respawn.transform.position;

        //CHealth.Sethealth();
    }
}
