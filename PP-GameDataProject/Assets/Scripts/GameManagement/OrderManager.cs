using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class OrderManager : MonoBehaviour {
    #region variables
    // number of orders per day
    public int orderCount;
    public int orderSkips;
    //reference to inventory
    public Inventory inventoryReference;
    //foods that can be selected for orders
    public Food[] orderableFoods;
    //multiplier applied to market value for reward
    public float rewardMultiplier;
    //order system
    public Food order;
    public bool activeOrders = false;
    //ui references
    public Text title;
    public Text reward;
    public Image art;
    //analytics
    public AnalyticsEventTracker orderSkipEvent;
    #endregion
    #region updates
    private void Update() {
        CheckOrderFulfilment();
    }
    #endregion
    #region orderfunctions
    // begin order generation, reset order count
    public void StartOrders() {
        activeOrders = true;
        orderCount = 0;
        orderSkips = 0;
        GenerateOrder();
    }
    // generate order, update ui, set reward
    public void GenerateOrder() {
        if (activeOrders) {
            order = orderableFoods[(int)Random.Range(0, orderableFoods.Length)];
            title.text = "" + order.itemName;
            reward.text = "" + (order.price * rewardMultiplier);
            art.sprite = order.cookedArt;
        }
    }
    // complete order, apply reward, if orders still active, generate new order
    public void FulfillOrder() {
        orderCount++;
        inventoryReference.gold += (order.price * rewardMultiplier);
        if (activeOrders) {
            GenerateOrder();
        }
    }
    // stop generating orders at about 1 minute remaining
    public void StopOrders() {
        activeOrders = false;
    }
    // check foods through inventory reference to check for order fulfilment
    public void CheckOrderFulfilment() {
        GameObject orderFulfilment = null;
        foreach (GameObject food in inventoryReference.activeFood) {
            if (food.GetComponent<Cookable>().dataReference == order && food.GetComponent<Cookable>().serving) {
                orderFulfilment = food;
            }
        }
        // if order fulfilled, fulfil order, destroy consumed food.
        if (orderFulfilment != null) {
            FulfillOrder();
            inventoryReference.activeFood.Remove(orderFulfilment);
            Destroy(orderFulfilment);
        }


    }

    public void OrderSkipped() {
        //Debug.Log("skip check");
        //analytic event
        orderSkipEvent.TriggerEvent();
        // skip order
        orderSkips++;
        // if still taking orders, generate new order
        if (activeOrders) {
            GenerateOrder();
        } else {
            // set order blank
            title.text = "";
            reward.text = "";
            art.sprite = null;
        }
    }
    #endregion
}
