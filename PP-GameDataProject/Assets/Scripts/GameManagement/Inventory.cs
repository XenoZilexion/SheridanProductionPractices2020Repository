using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // array of all food items
    public Food[] foods;
    // players current stock per item synced by id
    public int[] stock;
    // players current gold
    public float gold;
    // players current reputation (not implemented yet)
    public float reputation;
}
