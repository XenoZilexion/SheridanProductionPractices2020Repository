using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region variables
    public Transform[] cameraLocations;
    public enum gameState { MainMenu, Market, Prep, Cooking, Results}
    public gameState currentState = gameState.MainMenu;
    #endregion
    #region stateSwitching
    public void Update() { 
        // automatically relocates camera based on gameState 
        switch (currentState) {
            case gameState.MainMenu:
                Camera.main.transform.position = cameraLocations[0].position;
                break;
            case gameState.Market:
                Camera.main.transform.position = cameraLocations[1].position;
                break;
            case gameState.Prep:
                Camera.main.transform.position = cameraLocations[2].position;
                break;
            case gameState.Cooking:
                Camera.main.transform.position = cameraLocations[3].position;
                break;
            case gameState.Results:
                Camera.main.transform.position = cameraLocations[4].position;
                break;
        }
    }
    // public function to change state from other managers
    public void ChangeCameraLocation(gameState state) {
        currentState = state;
    }
    #endregion
}
