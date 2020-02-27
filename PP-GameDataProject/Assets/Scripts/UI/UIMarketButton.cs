using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMarketButton : MonoBehaviour
{
    #region variables
    //reference to food data
    public Food dataReference;
    //ui elements
    public Text nameText;
    public Text priceText;
    public Text stockText;
    public Image art;
    //text colors
    public Color defaultColor;
    public Color disableColor;
    //reference to inventory
    public Inventory inventoryReference;
    #endregion
    #region setup
    // Start is called before the first frame update
    void Start() { 
        // set button using stored food data
        art.sprite = dataReference.rawArt;
        nameText.text = dataReference.itemName;
        priceText.text = "Price for " + dataReference.quantityPerPurchase + ": " + dataReference.price + " gold";
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    #endregion
    #region updates
    // Update is called once per frame
    void Update()
    {
        // adjust buttons
        PriceCheck();
        QuantityCheck();
    }
    #endregion
    #region functions
    // set price text disable color if can't afford
    void PriceCheck() {
        if (dataReference.price > inventoryReference.gold) {
            priceText.color = disableColor;
        } else {
            priceText.color = defaultColor;
        }
    }
    // set stock text disable color if none in inventory
    void QuantityCheck() {
        if (inventoryReference.stock[dataReference.id]==0) {
            stockText.color = disableColor;
        } else {
            stockText.color = defaultColor;
        }
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    // purchase if the player has enough gold
    public void Purchase() {
        if (inventoryReference.gold >= dataReference.price) {
            inventoryReference.gold -= dataReference.price;
            inventoryReference.stock[dataReference.id] += dataReference.quantityPerPurchase;
        }
    }
    #endregion
}
