using UnityEngine;

public class Target : MonoBehaviour {

    private double nextTimeToChangeDirection = 0d;
    private int millisecondsPerSecond = 1000;

    public Transform playerBody;
    public float speed = 1f;
    private float direction = 1f;

    // Update is called once per frame
    void Update() {
        if (Time.timeAsDouble >= nextTimeToChangeDirection) {
            nextTimeToChangeDirection = Time.timeAsDouble + ((double) Random.Range(GameSettings.minStrafeDurationMilliseconds, GameSettings.maxStrafeDurationMilliseconds)) / millisecondsPerSecond;
            changeDirection();
        }
        lookAtPlayer();
        strafe();
    }
    private void changeDirection() {
        direction = -direction;
    }

    private void lookAtPlayer() {
        Vector3 playerPosition = playerBody.position;
        transform.LookAt(playerPosition, transform.up);
    }

    private void strafe() {
        Vector3 strafeDirection = Vector3.Cross(transform.forward, transform.up);
        transform.position += strafeDirection * speed * direction * Time.deltaTime;
    }
}
