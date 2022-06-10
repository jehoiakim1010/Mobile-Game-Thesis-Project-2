using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]

public class Itemss : ScriptableObject
{
    public string name;
    public int damage;
}
