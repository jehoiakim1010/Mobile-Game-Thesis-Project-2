using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePanel : MonoBehaviour
{

    public static ScenePanel Instance;

    GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
