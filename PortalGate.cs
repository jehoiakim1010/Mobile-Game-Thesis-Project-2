using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalGate : MonoBehaviour
{
    public GameObject PortalPanel;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PortalPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
