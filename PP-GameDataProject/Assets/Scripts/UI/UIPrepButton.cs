using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class UIPrepButton : MonoBehaviour
{
    #region variables
    //reference to food data
    public Food dataReference;
    //ui elements
    public Text nameText;
    public Text ingredientText;
    public Text ingredientOptionalText;
    public Text stockText;
    public Image art;
    //text colors
    public Color defaultColor;
    public Color disableColor;
    //reference to inventory
    public Inventory inventoryReference;

    public AnalyticsEventTracker success;
    public AnalyticsEventTracker fail;
    #endregion
    #region setup
    // Start is called before the first frame update
    void Start() {
        // set button using stored food data
        art.sprite = dataReference.rawArt;
        nameText.text = dataReference.itemName;
        // read required and optional ingredients and generate list in button.
        ingredientText.text = "Required:";
        foreach (int ingredient in dataReference.requiredIngredients) {
            ingredientText.text += "\n"+inventoryReference.foods[ingredient].itemName + ": " + inventoryReference.stock[ingredient];
        }
        if (dataReference.optionalIngredients.Length > 0) {
            ingredientOptionalText.text = "Optional:";
            foreach (int ingredient in dataReference.optionalIngredients) {
                ingredientOptionalText.text += "\n" + inventoryReference.foods[ingredient].itemName + ": " + inventoryReference.stock[ingredient] + "\n";
            }
        } else {
            ingredientOptionalText.text = "";
        }
            stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    #endregion
    #region updates
    // Update is called once per frame
    void Update() {
        // adjust buttons
        IngredientCheck();
        QuantityCheck();
    }
    #endregion
    #region functions
    // set price text disable color if can't afford
    void IngredientCheck() {
        // compares ingredients and optional ingredients against inventory stock and adjusts text colors appropriately
        bool canCraft = true;
        foreach (int ingredient in dataReference.requiredIngredients) {
            if (inventoryReference.stock[ingredient]<=0) {
                canCraft = false;
            }
        }
        if (!canCraft) {
            ingredientText.color = disableColor;
            ingredientOptionalText.color = disableColor;
        } else {
            ingredientText.color = defaultColor;
            ingredientOptionalText.color = defaultColor;
        }
        ingredientText.text = "Required:";
        foreach (int ingredient in dataReference.requiredIngredients) {
            ingredientText.text += "\n" + inventoryReference.foods[ingredient].itemName + ": " + inventoryReference.stock[ingredient];
        }
        if (dataReference.optionalIngredients.Length > 0) {
            ingredientOptionalText.text = "Optional:";
            foreach (int ingredient in dataReference.optionalIngredients) {
                ingredientOptionalText.text += "\n" + inventoryReference.foods[ingredient].itemName + ": " + inventoryReference.stock[ingredient] + "\n";
            }
        } else {
            ingredientOptionalText.text = "";
        }
    }
    // set stock text disable color if none in inventory
    void QuantityCheck() {
        if (inventoryReference.stock[dataReference.id] == 0) {
            stockText.color = disableColor;
        } else {
            stockText.color = defaultColor;
        }
        stockText.text = "Currently In Inventory: " + inventoryReference.stock[dataReference.id];
    }
    // create if the player has the ingredients, optional ingredients will be used to increase quality (not yet implemented)
    public void Purchase() {
        bool canCraft = true;
        foreach (int ingredient in dataReference.requiredIngredients) {
            if (inventoryReference.stock[ingredient] <= 0) {
                canCraft = false;
            }
        }
        if (canCraft) {
            foreach (int ingredient in dataReference.requiredIngredients) {
                inventoryReference.stock[ingredient]--;    
            }
            foreach (int ingredient in dataReference.optionalIngredients) {
                if (inventoryReference.stock[ingredient] >= 1) {
                    inventoryReference.stock[ingredient]--;
                }
            }
            inventoryReference.stock[dataReference.id]++;
            Debug.Log("successful prep check");
            success.TriggerEvent();
        } else {

            Debug.Log("failed prep check");
            fail.TriggerEvent();
        }
    }
    #endregion
}
