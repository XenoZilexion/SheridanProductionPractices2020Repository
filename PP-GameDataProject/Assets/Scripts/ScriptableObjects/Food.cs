using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// scriptable object for ingredients
[CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Foods", order = 1)]
public class Food : ScriptableObject { 
    // id used for crafting and ordering
    public int id;
    // name
    public string itemName;
    // art for raw and cooked state
    public Sprite rawArt;
    public Sprite cookedArt;
    // market price
    public float price;
    public int quantityPerPurchase;
    // times for cooking
    public float timeToCook;
    public float timeToBurn;
    public float timeToSpoil;
    //list of ingredients required to craft
    public int[] requiredIngredients;
    public int[] optionalIngredients;
    //determines whether appears in market menu
    public bool purchasable;
    //determines whether appears in prep menu
    public bool preparable;
    //determines whether it appears in the cooking inventory
    public bool cookable;
}
