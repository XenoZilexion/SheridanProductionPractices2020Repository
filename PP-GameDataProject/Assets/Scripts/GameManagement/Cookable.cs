using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookable : MonoBehaviour {
    #region variables
    //reference to food data
    public Food dataReference;
    //ui elements
    public Image art;
    public Outline outline;
    //text colors
    public Color rawColor;
    public Color cookedColor;
    public Color spoiledColor;
    public Color burntColor;
    //reference to inventory
    public Inventory inventoryReference;
    // state triggers
    public bool cooked = false;
    public bool spoiled = false;
    public bool burnt = false;
    // time spent in either state
    public float spoilTime;
    public float cookTime;
    // present area
    public bool cooking = false;
    public bool serving = false;
    public bool preparing = false;
    #endregion
    #region setup
    // Start is called before the first frame update
    void Start() {
        art.sprite = dataReference.rawArt;
        outline.effectColor = rawColor;
    }
    #endregion
    #region updates
    // Update is called once per frame
    void Update() {
        // progress age based on state
        if (cooking) {
            cookTime += Time.deltaTime;
        } else {
            spoilTime += Time.deltaTime;
        }
        // set state triggers based on age
        if (spoilTime >= dataReference.timeToSpoil) {
            spoiled = true;
        }
        if (cookTime >= dataReference.timeToCook) {
            cooked = true;
            art.sprite = dataReference.cookedArt;
            if (cookTime >= (dataReference.timeToCook + dataReference.timeToBurn)) {
                burnt = true;
            }
        }
        StateColor();
    }
    #endregion
    #region areas
    // set area triggers
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            cooking = true;
        }
        if (collision.gameObject.layer == 10) {
            serving = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            cooking = true;
        }
        if (collision.gameObject.layer == 10) {
            serving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 8) {
            cooking = false;
        }
        if (collision.gameObject.layer == 10) {
            serving = false;
        }
    }
    #endregion
    // color setting heiarchy, spoiled is the worst
    void StateColor() {
        if (!cooked && !burnt && !spoiled) {
            outline.effectColor = rawColor;
        } else if (cooked && !burnt && !spoiled) {
            outline.effectColor = cookedColor;
        } else if (burnt && !spoiled) {
            outline.effectColor = burntColor;
        } else if (spoiled) {
            outline.effectColor = spoiledColor;
        } else {

        }
    }
}
