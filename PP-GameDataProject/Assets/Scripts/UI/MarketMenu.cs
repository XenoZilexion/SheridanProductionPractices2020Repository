using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketMenu : MonoBehaviour {
    // initializes menu buttons
    #region variables
    // reference to give buttons
    public Inventory inventoryReference;
    //purchasable items (varying stock not yet implemented)
    public Food[] marketStock;
    //base button prefab
    public GameObject buttonPrefab;
    //list storing button references
    public List<GameObject> marketButtons;
    //spacing variables
    public int marketButtonVerticalPadding;
    public int marketButtonHorizontalPadding;
    public int marketButtonColumnLimit;
    #endregion
    #region setup
    void Start() {
        //loop to initialize market buttons by column
        int z = 0;
        for (int x = 0; x < (marketStock.Length) && z < marketStock.Length; x++) {
            for (int y = 0; y < marketButtonColumnLimit && z < marketStock.Length; y++) {        
                GameObject newMarketButton = Instantiate(buttonPrefab, new Vector3(this.transform.position.x + (x * marketButtonHorizontalPadding), this.transform.position.y + (y * marketButtonVerticalPadding), this.transform.position.z), Quaternion.identity);
                UIMarketButton functionReference = newMarketButton.GetComponentInChildren<UIMarketButton>();
                functionReference.dataReference = marketStock[z];
                functionReference.inventoryReference = inventoryReference;
                marketButtons.Add(newMarketButton);
                z++;
            }
        }
    }
    #endregion
}
