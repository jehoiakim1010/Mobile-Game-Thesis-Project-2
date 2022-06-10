using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyCount : MonoBehaviour
{
    PersistentData persistentData;
    GameObject[] enemies;
    public Text enemyCountText;

    Scene scene;

    inventory PlayerInventory;

    GameObject Player;

    // Start is called before the first frame update

    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerInventory = Player.GetComponent<inventory>() as inventory;

        if (ES3.FileExists("SaveFile.es3"))
        {
            if (ES3.KeyExists("Player Inventory"))
            {
                PlayerInventory.GameObject_Slots = ES3.Load<string[]>("Player Inventory");
                PlayerInventory.NumberOfItemsInSlot = ES3.Load<int[]>("Player Inventory Number");
            }
        }
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        persistentData = GameObject.FindObjectOfType<PersistentData>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = "Enemies : " + enemies.Length.ToString();

        if (enemies.Length <= 0)
        {
            if (scene.name == "Stage1")
            {
                if (persistentData.Scene_Done[0] == false)
                {
                    persistentData.Scene_Done[0] = true;
                    ES3.Save("Stage Done", persistentData.Scene_Done);
                }
            }

            if (scene.name == "Stage2")
            {
                if (persistentData.Scene_Done[1] == false)
                {
                    persistentData.Scene_Done[1] = true;
                    ES3.Save("Stage Done", persistentData.Scene_Done);
                }
            }

            if (scene.name == "Stage3")
            {
                if (persistentData.Scene_Done[2] == false)
                {
                    persistentData.Scene_Done[2] = true;
                    ES3.Save("Stage Done", persistentData.Scene_Done);
                }
            }

            if (scene.name == "Stage4")
            {
                if (persistentData.Scene_Done[3] == false)
                {
                    persistentData.Scene_Done[3] = true;
                    ES3.Save("Stage Done", persistentData.Scene_Done);
                }
            }

            if (scene.name == "Stage5")
            {
                if (persistentData.Scene_Done[4] == false)
                {
                    persistentData.Scene_Done[4] = true;
                    ES3.Save("Stage Done", persistentData.Scene_Done);
                }
            }
        }
    }
}
