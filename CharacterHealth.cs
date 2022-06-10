using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float maxH = 100;

    public float currentH = 100;

    public GameObject health;

    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentH = maxH;
        Sethealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentH <= 0)
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void TakeDamage(float amount)
    {
        currentH -= amount;
        Sethealth();
    }

    public void Sethealth()
    {
        float updatehealth = currentH / maxH;
        Debug.Log(updatehealth);
        health.transform.localScale = new Vector3(Mathf.Clamp(updatehealth, 0, 1), health.transform.localScale.y, health.transform.localScale.z);
    }
}
