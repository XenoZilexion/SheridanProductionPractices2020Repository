using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayManager : MonoBehaviour
{
    public int dayCount;
    public Inventory inventoryReference;
    public float goldAtStartOfDay;
    public float reputationAtStartOfDay;
    public float dayDuration;
    float dayEndTime;
    float dayStartTime;
    bool dayActive = false;

    public Color textColor;
    public Color disabledColor;

    public Text[] countTexts;
    public Image progressBar;

    public Button progressButton;

    public Text resultsText;
    public Text resultsTitle;

    public OrderManager orderReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Time.time>=dayEndTime&&dayActive) {
            EndOfDay();
        }
    }

    public void StartDay() {
        dayCount++;
        goldAtStartOfDay = inventoryReference.gold;
    }

    public void StartDayTimer() {
        dayStartTime = Time.time;
        dayEndTime = Time.time + dayDuration;
        dayActive = true;
        //goldAtStartOfDay = inventoryReference.gold;
        inventoryReference.GenerateInventory();
        orderReference.StartOrders();
    }

    void EndOfDay() {
        dayActive = false;
        resultsTitle.text = "Day " + dayCount + " Results";
        resultsText.text = (inventoryReference.gold - goldAtStartOfDay) + " Gold Earned\n";
        inventoryReference.ClearInventory();
        
    }

    void UpdateUI() {
        for (int x = 0; x<countTexts.Length;x++) {
            countTexts[x].text = "" + dayCount;
        }
        progressBar.fillAmount = 1-((Time.time - dayStartTime)/ (dayEndTime - dayStartTime));
        if (progressBar.fillAmount<=.2f) {
            orderReference.StopOrders();
        }
        //progressBar.fillAmount = 1 - (Time.time);
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
}
