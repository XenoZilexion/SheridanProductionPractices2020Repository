using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    bool dragging = false;
    float xOffset;
    float yOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.gameObject.transform.position = new Vector3(mousePosition.x - xOffset, mousePosition.y - yOffset, this.transform.position.z);
        }
    }

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

    private void OnMouseDrag() {
        
    }

    private void OnMouseUp() {
        dragging = false;
    }
}
