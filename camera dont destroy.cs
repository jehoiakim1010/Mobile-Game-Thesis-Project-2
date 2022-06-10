using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameradontdestroy : MonoBehaviour
{

    public static cameradontdestroy Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
