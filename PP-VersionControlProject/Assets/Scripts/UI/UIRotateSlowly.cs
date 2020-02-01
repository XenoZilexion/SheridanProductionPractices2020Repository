using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateSlowly : MonoBehaviour
{

    public float startRotation = 0;
    public float maxRotation;
    public float rotationSpeed;

    public bool rotateY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateY)
        {
            this.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(Vector3.zero, Vector3.right, rotationSpeed * Time.deltaTime);
        }
       
    }
}
