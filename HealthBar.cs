using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Rigidbody Player;
    int PlayerHealth;
    int MaxHealth = 100;
    [HideInInspector]
    public Slider HealthSlider;
    private int NewHealthAmount;
    bool RunOnce;
    [HideInInspector]
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthSlider != null)
        {
            if (HealthSlider.value <= 0)
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }

            if(RunOnce == false)
            {
                HealthSlider.maxValue = MaxHealth;
                HealthSlider.value = MaxHealth;
                RunOnce = true;
            }
        }
        else
        {
            GameOverPanel = GameObject.Find("/Canvas/GameOverPanel");
            GameOverPanel.SetActive(false);
            HealthSlider = GameObject.Find("/Canvas/CharacterHealth/Slider").GetComponent<Slider>();
        }
    }
    public void HurtPlayer(int Amount)
    {
        HealthSlider.value -= Amount;
        /*NewHealthAmount = PlayerHealth -= Amount;
        HealthSlider.value = NewHealthAmount;
        Amount = 0;
        NewHealthAmount = 0;*/
    }
}
