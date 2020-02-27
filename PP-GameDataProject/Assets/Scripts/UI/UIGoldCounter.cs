using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGoldCounter : MonoBehaviour {

    #region variables
    //reference to gold count
    public Inventory inventoryReference;
    //self references
    public Text counter;
    public Color goldColor;
    public Color brokeColor;
    #endregion

    #region updates
    // Update is called once per frame
    void Update() {
        // constantly adjust gold counter
        if (inventoryReference.gold > 0) {
            counter.color = goldColor;
        } else {
            counter.color = brokeColor;
        }
            counter.text = "" + inventoryReference.gold;
    }
    #endregion
}
