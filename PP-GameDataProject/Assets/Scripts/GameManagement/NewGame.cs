using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {
    //simple script to set New Game parameters
    #region variables
    public Inventory inventoryReference;
    public DayManager dayReference;
    public float startGold;
    #endregion
    #region functions
    public void StartNewGame() {
        inventoryReference.gold = startGold;
        dayReference.StartDay();
        for (int x = 0; x < inventoryReference.stock.Length; x++) {
            inventoryReference.stock[x] = 0;
        }
    }
    #endregion
}
