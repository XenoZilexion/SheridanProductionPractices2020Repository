using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateSlowly : MonoBehaviour
{
    #region Variables
    public float startRotation = 0;
    public float maxRotation;
    public float rotationSpeed;
    private float finalRotationSpeed;
    public bool rotateY;
    public float rotationSpeedModifier;
    #endregion
    #region Updates
    void Update()
    {
        if (Input.GetKey("space"))
        {
            finalRotationSpeed = rotationSpeed * rotationSpeedModifier;
            Debug.Log("success");
        }
        else
        {
            finalRotationSpeed = rotationSpeed;
        }
        if (rotateY)
        {
            this.transform.RotateAround(Vector3.zero, Vector3.up, finalRotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.RotateAround(Vector3.zero, Vector3.right, finalRotationSpeed * Time.deltaTime);
        }
       
    }
    #endregion
}
