using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayManager : MonoBehaviour {
    #region variables
    // current day
    public int dayCount;
    // reference to inventory
    public Inventory inventoryReference;
    // preserved gold at start of day for end of day result calcualtion
    public float goldAtStartOfDay;
    // reputation not yet implemented
    public float reputationAtStartOfDay;
    // duration of cooking segment of the day;
    public float dayDuration;
    // timer variables
    float dayEndTime;
    float dayStartTime;
    bool dayActive = false;
    // colors
    public Color textColor;
    public Color disabledColor;
    // day widget texts
    public Text[] countTexts;
    public Image progressBar;
    // button to progress at the end of the day
    public Button progressButton;
    // result screen text
    public Text resultsText;
    public Text resultsTitle;
    // reference to order management
    public OrderManager orderReference;
    #endregion

    #region updates
    // Update is called once per frame
    void Update() {
        // update the ui, if day duration is matched or exceeded, end day
        UpdateUI();
        if (Time.time >= dayEndTime && dayActive) {
            EndOfDay();
        }
    }
    #endregion
    #region functions
    // start a day, lock stat variables
    public void StartDay() {
        dayCount++;
        goldAtStartOfDay = inventoryReference.gold;
    }
    // start cooking section timer
    public void StartDayTimer() {
        dayStartTime = Time.time;
        dayEndTime = Time.time + dayDuration;
        dayActive = true;
        inventoryReference.GenerateInventory();
        orderReference.StartOrders();
    }
    // end of cooking section, set results
    void EndOfDay() {
        dayActive = false;
        resultsTitle.text = "Day " + dayCount + " Results";
        resultsText.text = (inventoryReference.gold - goldAtStartOfDay) + " Gold Earned\n" + orderReference.orderCount + " Orders Fulfilled\n";
        inventoryReference.ClearInventory();

    }
    // update widgets
    void UpdateUI() {
        for (int x = 0; x < countTexts.Length; x++) {
            countTexts[x].text = "" + dayCount;
        }
        progressBar.fillAmount = 1 - ((Time.time - dayStartTime) / (dayEndTime - dayStartTime));
        if (progressBar.fillAmount <= .2f) {
            orderReference.StopOrders();
        }
     
        if (dayActive) {
            progressButton.interactable = false;
            progressButton.enabled = false;
            progressButton.GetComponentInChildren<Text>().color = disabledColor;
        } else {
            progressButton.interactable = true;
            progressButton.enabled = true;
            progressButton.GetComponentInChildren<Text>().color = textColor;
        }
    }
    #endregion
}
