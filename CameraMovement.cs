using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject Player;

    [SerializeField]
    float y;

    [SerializeField]
    float x;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position + new Vector3(0, y, x);
        }
        else
        {
            Player = GameObject.FindWithTag("Player");
        }
    }
}
