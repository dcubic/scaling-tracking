using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public TMP_InputField minStrafeDurationInputField;
    public TMP_InputField maxStrafeDurationInputField;
    public TMP_InputField mouseSensitivityInputField;
    public TMP_InputField increaseSpeedThresholdInputField;
    public TMP_InputField maintainSpeedThresholdInputField;

    private string mainGameSceneName = "GameScene";

    public void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        minStrafeDurationInputField.text = GameSettings.minStrafeDurationMilliseconds.ToString();
        maxStrafeDurationInputField.text = GameSettings.maxStrafeDurationMilliseconds.ToString();
        mouseSensitivityInputField.text = GameSettings.mouseSensitivity.ToString();
        increaseSpeedThresholdInputField.text = GameSettings.increaseSpeedThreshold.ToString();
        maintainSpeedThresholdInputField.text = GameSettings.maintainSpeedThreshold.ToString();
    }

    public void saveSettings() {
        GameSettings.minStrafeDurationMilliseconds = int.Parse(minStrafeDurationInputField.text);
        GameSettings.maxStrafeDurationMilliseconds = int.Parse(maxStrafeDurationInputField.text);
        GameSettings.mouseSensitivity = float.Parse(mouseSensitivityInputField.text);
        GameSettings.increaseSpeedThreshold = float.Parse(increaseSpeedThresholdInputField.text);
        GameSettings.maintainSpeedThreshold = float.Parse(maintainSpeedThresholdInputField.text);
    }

    public void startGame() {
        saveSettings();
        SceneManager.LoadScene(mainGameSceneName);
    }
  
}
