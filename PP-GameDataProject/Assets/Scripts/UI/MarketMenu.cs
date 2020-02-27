using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketMenu : MonoBehaviour {
    public Inventory inventoryReference;
    public Food[] marketStock;
    public GameObject buttonPrefab;
    public List<GameObject> marketButtons;
    public int marketButtonVerticalPadding;
    public int marketButtonHorizontalPadding;
    public int marketButtonColumnLimit;
    // Start is called before the first frame update
    void Start() {
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

}
