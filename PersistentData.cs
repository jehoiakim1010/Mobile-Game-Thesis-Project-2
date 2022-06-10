using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PersistentData : MonoBehaviour
{
    GameObject Camera;


    GameObject Player;
    GameObject Canvas;
    GameObject UIManager;

    Scene scene;

    public bool[] Scene_Done = new bool[20];

    GameObject DungeonStagePanel, EasyPanel, NormalPanel, HardPanel;
    [SerializeField] GameObject Stage1, Stage2, Stage3, Stage4, Stage5;
    // Start is called before the first frame update

    bool CheckOnce;
    void Awake()
    {
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Menu")
        {
            Stage1 = GameObject.Find("/Canvas/DungeonStagePanel/Stage1").gameObject;
            Stage2 = GameObject.Find("/Canvas/DungeonStagePanel/Stage2").gameObject;
            Stage3 = GameObject.Find("/Canvas/DungeonStagePanel/Stage3").gameObject;
            Stage4 = GameObject.Find("/Canvas/DungeonStagePanel/Stage4").gameObject;
            Stage5 = GameObject.Find("/Canvas/DungeonStagePanel/Stage5").gameObject;


            //Challenges Stage
            EasyPanel = GameObject.Find("/Canvas/DungeonStagePanel/Easy").gameObject;
            NormalPanel = GameObject.Find("/Canvas/DungeonStagePanel/Normal").gameObject;
            HardPanel = GameObject.Find("/Canvas/DungeonStagePanel/Hard").gameObject;

            EasyPanel.SetActive(false);
            NormalPanel.SetActive(false);
            HardPanel.SetActive(false);

            DungeonStagePanel = GameObject.Find("/Canvas/DungeonStagePanel").gameObject;
            DungeonStagePanel.SetActive(false);

        }
        else
        {
            if (ES3.FileExists("SaveFile.es3"))
            {
                Scene_Done = ES3.Load<bool[]>("Stage Done");
            }
        }
        /*
        UIManager = GameObject.Find("/UIManager");
        Canvas = GameObject.Find("/Canvas");
        Camera = GameObject.Find("/Camera");
        GameObject.DontDestroyOnLoad(UIManager.gameObject);
        GameObject.DontDestroyOnLoad(Canvas.gameObject);
                GameObject.DontDestroyOnLoad(Camera.gameObject);
                */

    }

    void Update()
    {
        if (scene.name == "Menu")
        {
            if (ES3.FileExists("SaveFile.es3"))
            {
                if (CheckOnce == false)
                {
                    Scene_Done = ES3.Load<bool[]>("Stage Done");
                    CheckOnce = true;
                }

                if (Scene_Done[0] == true)
                {
                    Stage1.SetActive(true);

                    Stage2.SetActive(true);

                    Stage3.SetActive(false);

                    Stage4.SetActive(false);

                    Stage5.SetActive(false);
                }

                if (Scene_Done[1] == true)
                {
                    Stage1.SetActive(true);

                    Stage2.SetActive(true);

                    Stage3.SetActive(true);

                    Stage4.SetActive(false);

                    Stage5.SetActive(false);
                }

                if (Scene_Done[2] == true)
                {
                    Stage1.SetActive(true);

                    Stage2.SetActive(true);

                    Stage3.SetActive(true);

                    Stage4.SetActive(true);

                    Stage5.SetActive(false);
                }

                if (Scene_Done[3] == true)
                {
                    Stage1.SetActive(true);

                    Stage2.SetActive(true);

                    Stage3.SetActive(true);

                    Stage4.SetActive(true);

                    Stage5.SetActive(true);
                }

                if (Scene_Done[4] == true)
                {
                    EasyPanel.SetActive(true);
                    NormalPanel.SetActive(true);
                    HardPanel.SetActive(true);
                }
            }
            else
            {
                Stage1.SetActive(true);

                Stage2.SetActive(false);

                Stage3.SetActive(false);

                Stage4.SetActive(false);

                Stage5.SetActive(false);
            }
        }
    }
}
