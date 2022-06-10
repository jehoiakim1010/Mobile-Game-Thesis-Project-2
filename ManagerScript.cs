using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{

    public List<GameObject> enemies;
    public GameObject Drop;
    public GameObject PortalPanel;
    inventory PlayerInventory;
    bool drops;
    GameObject portal;
    Image SampleP;

    Uimanager uimanager;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.Find("/Portal").gameObject;

        Player = GameObject.FindWithTag("Player");

        PlayerInventory = Player.GetComponent<inventory>() as inventory;

        foreach (GameObject em in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(em);
        }

        uimanager = GameObject.FindObjectOfType<Uimanager>() as Uimanager;

        SampleP = GameObject.Find("/Canvas/SamplePanel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PortalPanel != null)
        {
            foreach (Transform child in PortalPanel.transform)
            {
                SampleP.enabled = false;
                child.gameObject.SetActive(false);
            }

            if (enemies.Count == 0 && drops == false)
            {
                StartCoroutine(DelayOpeningYouWin());

                //PortalPanel.SetActive(true);

                drops = true;
            }
        }

        else
        {
            PortalPanel = GameObject.Find("/Canvas/SamplePanel");
            //PortalPanel.SetActive(false);

            SampleP = GameObject.Find("/Canvas/SamplePanel").GetComponent<Image>();
        }
    }

    IEnumerator DelayOpeningYouWin()
    {
        yield return new WaitForSeconds(1.0f);

        ES3.Save("Player Inventory", PlayerInventory.GameObject_Slots);
        ES3.Save("Player Inventory Number", PlayerInventory.NumberOfItemsInSlot);


        ES3.Save("Sword Damage", uimanager.Sword_damage);

        ES3.Save("Axe Damage", uimanager.Axe_Damage);

        ES3.Save("Double Axe Damage", uimanager.Double_Axe_damage);


        foreach (Transform child in PortalPanel.transform)
        {
            SampleP.enabled = true;
            child.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}
