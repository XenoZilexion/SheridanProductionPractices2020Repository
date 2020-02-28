using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    // array of all food items
    public Food[] foods;
    // players current stock per item synced by id
    public int[] stock;
    // players current gold
    public float gold;
    // players current reputation (not implemented yet)
    public float reputation;

    public GameObject buttonPrefab;

    public List<GameObject> inventoryButtons;

    public List<GameObject> activeFood;

    public Transform foodSpot;

    //spacing variables
    public int inventoryButtonVerticalPadding;
    public int inventoryButtonHorizontalPadding;
    public int inventoryButtonColumnLimit;


    public void GenerateInventory() {
        //loop to initialize market buttons by column
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

    public void ClearInventory() {
        inventoryButtons.Clear();
    }




}
