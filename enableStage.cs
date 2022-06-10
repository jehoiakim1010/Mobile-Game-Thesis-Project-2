using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableStage : MonoBehaviour
{

    public GameObject stageButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked()
    {
        if (stageButton.activeInHierarchy == true)
            stageButton.SetActive(true);
    }
}
