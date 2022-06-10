using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableMusic : MonoBehaviour
{
    public static AdjustableMusic Instance;

    [SerializeField] private AudioSource musicsource;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
