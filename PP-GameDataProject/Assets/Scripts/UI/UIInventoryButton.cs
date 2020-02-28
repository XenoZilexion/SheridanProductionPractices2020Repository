using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryButton : MonoBehaviour
{

    #region variables
    //reference to food data
    public Food dataReference;
    //ui elements
    public Text nameText;
    public Text stockText;
    public Image art;
    //text colors
    public Color defaultColor;
    public Color disableColor;
    //reference to inventory
    public Inventory inventoryReference;
    //food object base
    public GameObject foodPrefab;
    #endregion
    #region setup
    // Start is called before the first frame update
    void Start() {
        // set button using stored food data
        art.sprite = dataReference.rawArt;
        nameText.text = dataReference.itemName;
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    #endregion
    #region updates
    // Update is called once per frame
    void Update() {
        // adjust buttons
        QuantityCheck();
    }
    #endregion
    #region functions
    // set stock text disable color if none in inventory
    void QuantityCheck() {
        if (inventoryReference.stock[dataReference.id] == 0) {
            stockText.color = disableColor;
        } else {
            stockText.color = defaultColor;
        }
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    // purchase if the player has enough gold
    public void Unpack() {
        // if the player has stock of the food type, unpack for use in the kitchen, reduce inventory accordingly
        if (inventoryReference.stock[dataReference.id] > 0) {
            GameObject newFood = Instantiate(foodPrefab, inventoryReference.foodSpot.position, Quaternion.identity);
            Cookable cookReference = newFood.GetComponent<Cookable>();
            cookReference.inventoryReference = inventoryReference;
            cookReference.dataReference = dataReference;
            inventoryReference.activeFood.Add(newFood);
            inventoryReference.stock[dataReference.id]--;
        }
        else {

        }
    }
    #endregion
}
