using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public int[] NumberOfItemsInSlot;

    public string[] GameObject_Slots = new string[50];

    public bool pickup;


    void Start()
    {
        for (int a = 0; a < GameObject_Slots.Length; a++)
        {
            if (GameObject_Slots[a] == "bronze ore UI(Clone)")
            {
                for (int i = 0; i < NumberOfItemsInSlot[a]; i++)
                {
                    Instantiate(Resources.Load<GameObject>("bronze ore UI"), slots[a].transform, false);

                    isFull[a] = true;
                }
            }

            if (GameObject_Slots[a] == "silver ore UI(Clone)")
            {
                for (int i = 0; i < NumberOfItemsInSlot[a]; i++)
                {
                    Instantiate(Resources.Load<GameObject>("silver ore UI"), slots[a].transform, false);

                    isFull[a] = true;
                }
            }
        }
    }

    void Awake()
    {
        slots[0] = GameObject.Find("/Canvas/inventory/BagPanel/slots");
        slots[1] = GameObject.Find("/Canvas/inventory/BagPanel/slots (1)");
        slots[2] = GameObject.Find("/Canvas/inventory/BagPanel/slots (2)");
        slots[3] = GameObject.Find("/Canvas/inventory/BagPanel/slots (3)");
        slots[4] = GameObject.Find("/Canvas/inventory/BagPanel/slots (4)");
        slots[5] = GameObject.Find("/Canvas/inventory/BagPanel/slots (5)");
        slots[6] = GameObject.Find("/Canvas/inventory/BagPanel/slots (6)");
        slots[7] = GameObject.Find("/Canvas/inventory/BagPanel/slots (7)");
        slots[8] = GameObject.Find("/Canvas/inventory/BagPanel/slots (8)");
        slots[9] = GameObject.Find("/Canvas/inventory/BagPanel/slots (9)");
        slots[10] = GameObject.Find("/Canvas/inventory/BagPanel/slots (10)");
        slots[11] = GameObject.Find("/Canvas/inventory/BagPanel/slots (11)");
        slots[12] = GameObject.Find("/Canvas/inventory/BagPanel/slots (12)");
        slots[13] = GameObject.Find("/Canvas/inventory/BagPanel/slots (13)");
        slots[14] = GameObject.Find("/Canvas/inventory/BagPanel/slots (14)");
        slots[15] = GameObject.Find("/Canvas/inventory/BagPanel/slots (15)");
        slots[16] = GameObject.Find("/Canvas/inventory/BagPanel/slots (16)");
        slots[17] = GameObject.Find("/Canvas/inventory/BagPanel/slots (17)");
        slots[18] = GameObject.Find("/Canvas/inventory/BagPanel/slots (18)");
        slots[19] = GameObject.Find("/Canvas/inventory/BagPanel/slots (19)");
        slots[20] = GameObject.Find("/Canvas/inventory/BagPanel/slots (20)");
        slots[21] = GameObject.Find("/Canvas/inventory/BagPanel/slots (21)");
        slots[22] = GameObject.Find("/Canvas/inventory/BagPanel/slots (22)");
        slots[23] = GameObject.Find("/Canvas/inventory/BagPanel/slots (23)");
        slots[24] = GameObject.Find("/Canvas/inventory/BagPanel/slots (24)");
        slots[25] = GameObject.Find("/Canvas/inventory/BagPanel/slots (25)");
        slots[26] = GameObject.Find("/Canvas/inventory/BagPanel/slots (26)");
        slots[27] = GameObject.Find("/Canvas/inventory/BagPanel/slots (27)");
        slots[28] = GameObject.Find("/Canvas/inventory/BagPanel/slots (28)");
        slots[29] = GameObject.Find("/Canvas/inventory/BagPanel/slots (29)");
        slots[30] = GameObject.Find("/Canvas/inventory/BagPanel/slots (30)");
        slots[31] = GameObject.Find("/Canvas/inventory/BagPanel/slots (31)");
        slots[32] = GameObject.Find("/Canvas/inventory/BagPanel/slots (32)");
        slots[33] = GameObject.Find("/Canvas/inventory/BagPanel/slots (33)");
        slots[34] = GameObject.Find("/Canvas/inventory/BagPanel/slots (34)");
        slots[35] = GameObject.Find("/Canvas/inventory/BagPanel/slots (35)");
        slots[36] = GameObject.Find("/Canvas/inventory/BagPanel/slots (36)");
        slots[37] = GameObject.Find("/Canvas/inventory/BagPanel/slots (37)");
        slots[38] = GameObject.Find("/Canvas/inventory/BagPanel/slots (38)");
        slots[39] = GameObject.Find("/Canvas/inventory/BagPanel/slots (39)");
        slots[40] = GameObject.Find("/Canvas/inventory/BagPanel/slots (40)");
        slots[41] = GameObject.Find("/Canvas/inventory/BagPanel/slots (41)");
        slots[42] = GameObject.Find("/Canvas/inventory/BagPanel/slots (42)");
        slots[43] = GameObject.Find("/Canvas/inventory/BagPanel/slots (43)");
        slots[44] = GameObject.Find("/Canvas/inventory/BagPanel/slots (44)");
        slots[45] = GameObject.Find("/Canvas/inventory/BagPanel/slots (45)");
        slots[46] = GameObject.Find("/Canvas/inventory/BagPanel/slots (46)");
        slots[47] = GameObject.Find("/Canvas/inventory/BagPanel/slots (47)");
        slots[48] = GameObject.Find("/Canvas/inventory/BagPanel/slots (48)");
        slots[49] = GameObject.Find("/Canvas/inventory/BagPanel/slots (49)");
    }

    void Update()
    {
        if (slots[0] != null)
        {
            Stack();
        }
        else
        {
            slots[0] = GameObject.Find("/Canvas/inventory/BagPanel/slots");
            slots[1] = GameObject.Find("/Canvas/inventory/BagPanel/slots (1)");
            slots[2] = GameObject.Find("/Canvas/inventory/BagPanel/slots (2)");
            slots[3] = GameObject.Find("/Canvas/inventory/BagPanel/slots (3)");
            slots[4] = GameObject.Find("/Canvas/inventory/BagPanel/slots (4)");
            slots[5] = GameObject.Find("/Canvas/inventory/BagPanel/slots (5)");
            slots[6] = GameObject.Find("/Canvas/inventory/BagPanel/slots (6)");
            slots[7] = GameObject.Find("/Canvas/inventory/BagPanel/slots (7)");
            slots[8] = GameObject.Find("/Canvas/inventory/BagPanel/slots (8)");
            slots[9] = GameObject.Find("/Canvas/inventory/BagPanel/slots (9)");
            slots[10] = GameObject.Find("/Canvas/inventory/BagPanel/slots (10)");
            slots[11] = GameObject.Find("/Canvas/inventory/BagPanel/slots (11)");
            slots[12] = GameObject.Find("/Canvas/inventory/BagPanel/slots (12)");
            slots[13] = GameObject.Find("/Canvas/inventory/BagPanel/slots (13)");
            slots[14] = GameObject.Find("/Canvas/inventory/BagPanel/slots (14)");
            slots[15] = GameObject.Find("/Canvas/inventory/BagPanel/slots (15)");
            slots[16] = GameObject.Find("/Canvas/inventory/BagPanel/slots (16)");
            slots[17] = GameObject.Find("/Canvas/inventory/BagPanel/slots (17)");
            slots[18] = GameObject.Find("/Canvas/inventory/BagPanel/slots (18)");
            slots[19] = GameObject.Find("/Canvas/inventory/BagPanel/slots (19)");
            slots[20] = GameObject.Find("/Canvas/inventory/BagPanel/slots (20)");
            slots[21] = GameObject.Find("/Canvas/inventory/BagPanel/slots (21)");
            slots[22] = GameObject.Find("/Canvas/inventory/BagPanel/slots (22)");
            slots[23] = GameObject.Find("/Canvas/inventory/BagPanel/slots (23)");
            slots[24] = GameObject.Find("/Canvas/inventory/BagPanel/slots (24)");
            slots[25] = GameObject.Find("/Canvas/inventory/BagPanel/slots (25)");
            slots[26] = GameObject.Find("/Canvas/inventory/BagPanel/slots (26)");
            slots[27] = GameObject.Find("/Canvas/inventory/BagPanel/slots (27)");
            slots[28] = GameObject.Find("/Canvas/inventory/BagPanel/slots (28)");
            slots[29] = GameObject.Find("/Canvas/inventory/BagPanel/slots (29)");
            slots[30] = GameObject.Find("/Canvas/inventory/BagPanel/slots (30)");
            slots[31] = GameObject.Find("/Canvas/inventory/BagPanel/slots (31)");
            slots[32] = GameObject.Find("/Canvas/inventory/BagPanel/slots (32)");
            slots[33] = GameObject.Find("/Canvas/inventory/BagPanel/slots (33)");
            slots[34] = GameObject.Find("/Canvas/inventory/BagPanel/slots (34)");
            slots[35] = GameObject.Find("/Canvas/inventory/BagPanel/slots (35)");
            slots[36] = GameObject.Find("/Canvas/inventory/BagPanel/slots (36)");
            slots[37] = GameObject.Find("/Canvas/inventory/BagPanel/slots (37)");
            slots[38] = GameObject.Find("/Canvas/inventory/BagPanel/slots (38)");
            slots[39] = GameObject.Find("/Canvas/inventory/BagPanel/slots (39)");
            slots[40] = GameObject.Find("/Canvas/inventory/BagPanel/slots (40)");
            slots[41] = GameObject.Find("/Canvas/inventory/BagPanel/slots (41)");
            slots[42] = GameObject.Find("/Canvas/inventory/BagPanel/slots (42)");
            slots[43] = GameObject.Find("/Canvas/inventory/BagPanel/slots (43)");
            slots[44] = GameObject.Find("/Canvas/inventory/BagPanel/slots (44)");
            slots[45] = GameObject.Find("/Canvas/inventory/BagPanel/slots (45)");
            slots[46] = GameObject.Find("/Canvas/inventory/BagPanel/slots (46)");
            slots[47] = GameObject.Find("/Canvas/inventory/BagPanel/slots (47)");
            slots[48] = GameObject.Find("/Canvas/inventory/BagPanel/slots (48)");
            slots[49] = GameObject.Find("/Canvas/inventory/BagPanel/slots (49)");
        }

    }

    void Stack()
    {

        if (isFull[0] && GameObject_Slots[0] == "")
        {
            GameObject_Slots[0] = slots[0].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[1] && GameObject_Slots[1] == "")
        {
            GameObject_Slots[1] = slots[1].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[2] && GameObject_Slots[2] == "")
        {
            GameObject_Slots[2] = slots[2].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[3] && GameObject_Slots[3] == "")
        {
            GameObject_Slots[3] = slots[3].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[4] && GameObject_Slots[4] == "")
        {
            GameObject_Slots[4] = slots[4].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[5] && GameObject_Slots[5] == "")
        {
            GameObject_Slots[5] = slots[5].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[6] && GameObject_Slots[6] == "")
        {
            GameObject_Slots[6] = slots[6].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[7] && GameObject_Slots[7] == "")
        {
            GameObject_Slots[7] = slots[7].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[8] && GameObject_Slots[8] == "")
        {
            GameObject_Slots[8] = slots[8].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[9] && GameObject_Slots[9] == "")
        {
            GameObject_Slots[9] = slots[9].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[10] && GameObject_Slots[10] == "")
        {
            GameObject_Slots[10] = slots[10].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[11] && GameObject_Slots[11] == "")
        {
            GameObject_Slots[11] = slots[11].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[12] && GameObject_Slots[12] == "")
        {
            GameObject_Slots[12] = slots[12].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[13] && GameObject_Slots[13] == "")
        {
            GameObject_Slots[13] = slots[13].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[14] && GameObject_Slots[14] == "")
        {
            GameObject_Slots[14] = slots[14].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[15] && GameObject_Slots[15] == "")
        {
            GameObject_Slots[15] = slots[15].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[16] && GameObject_Slots[16] == "")
        {
            GameObject_Slots[16] = slots[16].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[17] && GameObject_Slots[17] == "")
        {
            GameObject_Slots[17] = slots[17].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[18] && GameObject_Slots[18] == "")
        {
            GameObject_Slots[18] = slots[18].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[19] && GameObject_Slots[19] == "")
        {
            GameObject_Slots[19] = slots[19].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[20] && GameObject_Slots[20] == "")
        {
            GameObject_Slots[20] = slots[20].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[21] && GameObject_Slots[21] == "")
        {
            GameObject_Slots[21] = slots[21].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[22] && GameObject_Slots[22] == "")
        {
            GameObject_Slots[22] = slots[22].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[23] && GameObject_Slots[23] == "")
        {
            GameObject_Slots[23] = slots[23].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[24] && GameObject_Slots[24] == "")
        {
            GameObject_Slots[24] = slots[24].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[25] && GameObject_Slots[25] == "")
        {
            GameObject_Slots[25] = slots[25].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[26] && GameObject_Slots[26] == "")
        {
            GameObject_Slots[26] = slots[26].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[27] && GameObject_Slots[27] == "")
        {
            GameObject_Slots[27] = slots[27].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[28] && GameObject_Slots[28] == "")
        {
            GameObject_Slots[28] = slots[28].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[29] && GameObject_Slots[29] == "")
        {
            GameObject_Slots[29] = slots[29].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[30] && GameObject_Slots[30] == "")
        {
            GameObject_Slots[30] = slots[30].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[31] && GameObject_Slots[31] == "")
        {
            GameObject_Slots[31] = slots[31].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[32] && GameObject_Slots[32] == "")
        {
            GameObject_Slots[32] = slots[32].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[33] && GameObject_Slots[33] == "")
        {
            GameObject_Slots[33] = slots[33].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[34] && GameObject_Slots[34] == "")
        {
            GameObject_Slots[34] = slots[34].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[35] && GameObject_Slots[35] == "")
        {
            GameObject_Slots[35] = slots[35].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[36] && GameObject_Slots[36] == "")
        {
            GameObject_Slots[36] = slots[36].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[37] && GameObject_Slots[37] == "")
        {
            GameObject_Slots[37] = slots[37].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[38] && GameObject_Slots[38] == "")
        {
            GameObject_Slots[38] = slots[38].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[39] && GameObject_Slots[39] == "")
        {
            GameObject_Slots[39] = slots[39].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[40] && GameObject_Slots[40] == "")
        {
            GameObject_Slots[40] = slots[40].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[41] && GameObject_Slots[41] == "")
        {
            GameObject_Slots[41] = slots[41].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[42] && GameObject_Slots[42] == "")
        {
            GameObject_Slots[42] = slots[42].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[43] && GameObject_Slots[43] == "")
        {
            GameObject_Slots[43] = slots[43].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[44] && GameObject_Slots[44] == "")
        {
            GameObject_Slots[44] = slots[44].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[45] && GameObject_Slots[45] == "")
        {
            GameObject_Slots[45] = slots[45].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[46] && GameObject_Slots[46] == "")
        {
            GameObject_Slots[46] = slots[46].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[47] && GameObject_Slots[47] == "")
        {
            GameObject_Slots[47] = slots[47].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[48] && GameObject_Slots[48] == "")
        {
            GameObject_Slots[48] = slots[48].transform.GetChild(1).gameObject.name.ToString();
        }

        if (isFull[49] && GameObject_Slots[49] == "")
        {
            GameObject_Slots[49] = slots[49].transform.GetChild(1).gameObject.name.ToString();
        }



        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount <= 1)
            {
                isFull[i] = false;
                GameObject_Slots[i] = "";
                slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                for (int a = 0; a < slots[i].transform.childCount; a++)
                {
                    if (slots[i].gameObject.transform.GetChild(a).GetComponent<Spawn>() != null)
                    {
                        NumberOfItemsInSlot[i] = a;
                        //Set The Stack Text Number To String
                        slots[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = a.ToString();

                    }
                }
            }
        }
    }
}
