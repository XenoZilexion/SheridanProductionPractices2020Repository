using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMarketButton : MonoBehaviour
{
    #region variables
    public Food dataReference;

    public Text nameText;
    public Text priceText;
    public Text stockText;
    public Image art;

    public Color defaultColor;
    public Color disableColor;

    public Inventory inventoryReference;
    #endregion
    #region setup
    // Start is called before the first frame update
    void Start() { 

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
        PriceCheck();
        QuantityCheck();
    }
    #endregion
    #region functions
    void PriceCheck() {
        if (dataReference.price > inventoryReference.gold) {
            //nameText.color = disableColor;
            priceText.color = disableColor;
            //stockText.color = disableColor;
        } else {
            //nameText.color = defaultColor;
            priceText.color = defaultColor;
            //stockText.color = defaultColor;
        }
    }
    void QuantityCheck() {
        if (inventoryReference.stock[dataReference.id]==0) {
            stockText.color = disableColor;
        } else {
            stockText.color = defaultColor;
        }
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    public void Purchase() {
        if (inventoryReference.gold >= dataReference.price) {
            inventoryReference.gold -= dataReference.price;
            inventoryReference.stock[dataReference.id] += dataReference.quantityPerPurchase;
        }
    }
    #endregion
}
