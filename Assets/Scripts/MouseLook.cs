using UnityEngine;

public class MouseLook : MonoBehaviour {
    public Transform playerBody;

    private float xRotation = 0;
    private float verticalRotationLimit = 90f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * GameSettings.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * GameSettings.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
