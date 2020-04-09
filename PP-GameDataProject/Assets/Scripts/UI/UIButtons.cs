using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {
    // this script is a compilation of very simple UI Button functions in one for convenience.
    #region variables
    public string sceneName;
    public CameraManager cameraReference;
    #endregion
    #region functions
    //scene managing functions
    public void SceneChange() {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitTheGame() {
        Debug.Log("quit check");
        Application.Quit();
    }
    //tie in functions for other game management functions to change game 'phase'
    public void SetGameStateMainMenu() {
        cameraReference.ChangeCameraLocation(CameraManager.gameState.MainMenu);
    }
    public void SetGameStateMarket() {
        cameraReference.ChangeCameraLocation(CameraManager.gameState.Market);
    }
    public void SetGameStatePreparation() {
        cameraReference.ChangeCameraLocation(CameraManager.gameState.Prep);
    }
    public void SetGameStateCooking() {
        cameraReference.ChangeCameraLocation(CameraManager.gameState.Cooking);
    }
    public void SetGameStateResults() {
        cameraReference.ChangeCameraLocation(CameraManager.gameState.Results);
    }
    #endregion
}
