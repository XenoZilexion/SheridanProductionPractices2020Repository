using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // simple drag code for intaracting with foods
    // improve if time allows
    #region variables
        // dragging state
    bool dragging = false;
    // offset to avoid center snap
    float xOffset;
    float yOffset;
    #endregion

    #region dragging
    // constant drag
    void Update()
    {
        if (dragging) {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.gameObject.transform.position = new Vector3(mousePosition.x - xOffset, mousePosition.y - yOffset, this.transform.position.z);
        }
    }

    // begin drag
    private void OnMouseDown() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            xOffset = mousePosition.x - this.transform.localPosition.x;
            yOffset = mousePosition.y - this.transform.localPosition.y;

            dragging = true;
        }
       
    }
    // release drag state
    private void OnMouseUp() {
        dragging = false;
    }
    #endregion
}
