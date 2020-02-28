using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepMenu : MonoBehaviour {
    // initializes menu buttons
    #region variables
    // reference to give buttons
    public Inventory inventoryReference;
    //purchasable items (varying stock not yet implemented)
    public Food[] prepStock;
    //base button prefab
    public GameObject buttonPrefab;
    //list storing button references
    public List<GameObject> prepButtons;
    //spacing variables
    public int prepButtonVerticalPadding;
    public int prepButtonHorizontalPadding;
    public int prepButtonColumnLimit;
    #endregion
    #region setup
    void Start() {
        //loop to initialize peparation buttons by column
        int z = 0;
        for (int x = 0; x < (prepStock.Length) && z < prepStock.Length; x++) {
            for (int y = 0; y < prepButtonColumnLimit && z < prepStock.Length; y++) {
                GameObject newPrepButton = Instantiate(buttonPrefab, new Vector3(this.transform.position.x + (x * prepButtonHorizontalPadding), this.transform.position.y + (y * prepButtonVerticalPadding), this.transform.position.z), Quaternion.identity);
                UIPrepButton functionReference = newPrepButton.GetComponentInChildren<UIPrepButton>();
                functionReference.dataReference = prepStock[z];
                functionReference.inventoryReference = inventoryReference;
                prepButtons.Add(newPrepButton);
                z++;
            }
        }
    }
    #endregion

}
