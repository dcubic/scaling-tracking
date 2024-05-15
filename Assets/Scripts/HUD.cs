using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Target target;
    private TMP_Text tmpText;

    private void Start() {
        tmpText = GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update() {
        tmpText.text = $"Speed: {target.speed.ToString("0.0")}";
    }
}
