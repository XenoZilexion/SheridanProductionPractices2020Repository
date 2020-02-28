using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour {
    public int orderCount;
    public Inventory inventoryReference;
    public Food[] orderableFoods;

    public float rewardMultiplier;
    public Food order;
    // Start is called before the first frame update

    public bool activeOrders = false;

    public Text title;
    public Text reward;
    public Image art;

    private void Update() {
        CheckOrderFulfilment();
    }

    public void StartOrders() {
        activeOrders = true;
        orderCount = 0;
        GenerateOrder();
    }

    public void GenerateOrder() {
        order = orderableFoods[(int)Random.Range(0, orderableFoods.Length)];
        title.text = "" + order.itemName;
        reward.text = "" + (order.price * rewardMultiplier);
        art.sprite = order.cookedArt;
    }

    public void FulfillOrder() {
        orderCount++;
        inventoryReference.gold += (order.price * rewardMultiplier);
        if (activeOrders) {
            GenerateOrder();
        }
    }

    public void StopOrders() {
        activeOrders = false;
    }

    public void CheckOrderFulfilment() {
        GameObject orderFulfilment = null;
        foreach (GameObject food in inventoryReference.activeFood) {
            if (food.GetComponent<Cookable>().dataReference == order && food.GetComponent<Cookable>().serving) {
                orderFulfilment = food;
            }
        }
        if (orderFulfilment != null) {
            FulfillOrder();
            inventoryReference.activeFood.Remove(orderFulfilment);
            Destroy(orderFulfilment);
        }


    }
}
