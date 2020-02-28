using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationArea : MonoBehaviour
{
    public Inventory inventoryReference;

    public GameObject foodPrefab;

    List<int> currentlyAvailableID;
    List<GameObject> currentlyAvailable;

    private void Update() {
        if (currentlyAvailableID.Contains(8)&& currentlyAvailableID.Contains(6)&&currentlyAvailableID.Contains(1)&& currentlyAvailableID.Contains(0)) {

        }
        if (currentlyAvailableID.Contains(0) && currentlyAvailableID.Contains(1)&&currentlyAvailableID.Contains(2) && currentlyAvailableID.Contains(5)) {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        currentlyAvailableID.Add(collision.gameObject.GetComponent<Cookable>().dataReference.id);
        currentlyAvailable.Add(collision.gameObject);
    }


    private void OnTriggerExit2D(Collider2D collision) {
        
    }

}
