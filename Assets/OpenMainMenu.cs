using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenu : MonoBehaviour {

    private string mainMenuSceneName = "Menu";

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
