using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    private inventory Inventory;
    public GameObject Items;
    [SerializeField] Itemss item;
    bool isInventorydone;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.FindWithTag("Player").GetComponent<inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (Inventory.pickup == false)
        {

            for (int i = 0; i < Inventory.slots.Length; i++)
            {
                if (Inventory.isFull[i] == true)
                {
                    if (Items.name + ("(Clone)") == Inventory.GameObject_Slots[i])
                    {
                        Inventory.isFull[i] = true;
                        GameObject Itembutton = Instantiate(Items, Inventory.slots[i].transform, false);
                        Itembutton.transform.SetSiblingIndex(2);
                        StartCoroutine(delayed());
                        break;
                    }
                }
                if (i >= Inventory.slots.Length - 1 && isInventorydone == false)
                {
                    isInventorydone = true;
                }
            }

            if (isInventorydone == true)
            {
                if (other.gameObject.tag == "Player")
                {
                    for (int i = 0; i < Inventory.slots.Length; i++)
                    {
                        if (Inventory.isFull[i] == false)
                        {
                            Inventory.isFull[i] = true;
                            GameObject Itembutton = Instantiate(Items, Inventory.slots[i].transform, false);
                            //Itembutton.transform.SetSiblingIndex(2);
                            Itembutton.transform.SetSiblingIndex(2);
                            StartCoroutine(delayed());
                            break;
                        }
                    }
                }
            }
        }
    }

    IEnumerator delayed()
    {
        Inventory.pickup = true;
        yield return new WaitForSeconds(0.5f);
        Inventory.pickup = false;
        Destroy(gameObject);
    }
}
