using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookable : MonoBehaviour
{
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

    public bool cooked = false;
    public bool spoiled = false;
   public  bool burnt = false;

    public float spoilTime;
    public float cookTime;

    public bool cooking = false;
    public bool serving = false;
    public bool preparing = false;

    // Start is called before the first frame update
    void Start()
    {
        art.sprite = dataReference.rawArt;
        outline.effectColor = rawColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking) {
            cookTime += Time.deltaTime;
        } else {
            spoilTime += Time.deltaTime;
        }

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
