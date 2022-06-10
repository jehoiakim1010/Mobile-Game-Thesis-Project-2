using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSwitch : MonoBehaviour
{
    PersistentData persistentData;
    GameObject Player;
    GameObject Respawn;
    GameObject GameOverPanel;
    HealthBar NewHealthBar;

    GameObject PlayerItems;

    void Start()
    {
        NewHealthBar = GameObject.FindObjectOfType<HealthBar>();

        persistentData = GameObject.FindObjectOfType<PersistentData>() as PersistentData;
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void Stage5()
    {
        SceneManager.LoadScene("Stage5");
    }

    public void EasyStage1()
    {
        SceneManager.LoadScene("Stage6");
    }

    public void EasyStage2()
    {
        SceneManager.LoadScene("Stage7");
    }

    public void EasyStage3()
    {
        SceneManager.LoadScene("Stage8");
    }

    public void EasyStage4()
    {
        SceneManager.LoadScene("Stage9");
    }

    public void EasyStage5()
    {
        SceneManager.LoadScene("Stage10");
    }

    public void NormalStage1()
    {
        SceneManager.LoadScene("Stage11");
    }

    public void NormalStage2()
    {
        SceneManager.LoadScene("Stage12");
    }

    public void NormalStage3()
    {
        SceneManager.LoadScene("Stage13");
    }

    public void NormalStage4()
    {
        SceneManager.LoadScene("Stage14");
    }

    public void NormalStage5()
    {
        SceneManager.LoadScene("Stage15");
    }

    public void HardStage1()
    {
        SceneManager.LoadScene("Stage16");
    }

    public void HardStage2()
    {
        SceneManager.LoadScene("Stage17");
    }

    public void HardStage3()
    {
        SceneManager.LoadScene("Stage18");
    }

    public void HardStage4()
    {
        SceneManager.LoadScene("Stage19");
    }

    public void HardStage5()
    {
        SceneManager.LoadScene("Stage20");
    }

    public void BackToMenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackToMenuBtn1()
    {
        SceneManager.LoadScene("StoryLine 1");
    }

    public void GoToStage01()
    {
        //NewHealthBar.GameOverPanel.SetActive(true);
        SceneManager.LoadScene("Stage2");
    }

    public void GoToStage02()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void GoToStage03()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void GoToStage04()
    {
        SceneManager.LoadScene("Stage5");
    }

    public void GoToStageE1()
    {
        SceneManager.LoadScene("Stage7");
    }

    public void GoToStageE2()
    {
        SceneManager.LoadScene("Stage8");
    }

    public void GoToStageE3()
    {
        SceneManager.LoadScene("Stage9");
    }

    public void GoToStageE4()
    {
        SceneManager.LoadScene("Stage10");
    }

    public void GoToStageN1()
    {
        SceneManager.LoadScene("Stage12");
    }

    public void GoToStageN2()
    {
        SceneManager.LoadScene("Stage13");
    }

    public void GoToStageN3()
    {
        SceneManager.LoadScene("Stage14");
    }

    public void GoToStageN4()
    {
        SceneManager.LoadScene("Stage15");
    }

    public void GoToStageH1()
    {
        SceneManager.LoadScene("Stage17");
    }

    public void GoToStageH2()
    {
        SceneManager.LoadScene("Stage18");
    }

    public void GoToStageH3()
    {
        SceneManager.LoadScene("Stage19");
    }

    public void GoToStageH4()
    {
        SceneManager.LoadScene("Stage20");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
