﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    #region variables
    // array of all food items
    public Food[] foods;
    // players current stock per item synced by id
    public int[] stock;
    // players current gold
    public float gold;
    // players current reputation (not implemented yet)
    public float reputation;
    // inventory button prefab
    public GameObject buttonPrefab;
    // list of inventory buttons
    public List<GameObject> inventoryButtons;
    // list of active food objects
    public List<GameObject> activeFood;
    // location to instantiate food
    public Transform foodSpot;
    //spacing variables
    public int inventoryButtonVerticalPadding;
    public int inventoryButtonHorizontalPadding;
    public int inventoryButtonColumnLimit;
    #endregion
    #region inventoryButtonManagement
    public void GenerateInventory() {
        //loop to initialize inventory buttons by column
        int z = 0;
        int y = 0;
        for (int x = 0; x < (stock.Length); x++) {
            if (stock[x]>0&&foods[x].cookable) {
                GameObject newInventoryButton = Instantiate(buttonPrefab, new Vector3(this.transform.position.x + (z * inventoryButtonHorizontalPadding), this.transform.position.y + (y * inventoryButtonVerticalPadding), this.transform.position.z), Quaternion.identity);
                UIInventoryButton functionReference = newInventoryButton.GetComponentInChildren<UIInventoryButton>();
                functionReference.dataReference = foods[x];
                functionReference.inventoryReference = this;
                inventoryButtons.Add(newInventoryButton);
                y++;
                if (y>=inventoryButtonColumnLimit) {
                    y = 0;
                    z++;
                }
            } else {

            }
        }
    }
    // empty lists of inventory/unpacked stock one item at a time until empty
    public void ClearInventory() {
        while (activeFood.Count > 0) { 
            GameObject temp = null;
            temp = activeFood[0];
            activeFood.Remove(temp);
            Destroy(temp);
        }

        while (inventoryButtons.Count > 0) {
            GameObject temp = null;
            temp = inventoryButtons[0];
            inventoryButtons.Remove(temp);
            Destroy(temp);
        }
    }
    #endregion
}
