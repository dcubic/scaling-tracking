using UnityEngine;

public class ShootController : MonoBehaviour {

    public Camera fpsCamera;
    public Target expectedTarget;

    private float speedModifier = 0.1f;

    public int totalHitCount = 0;
    public int totalShotCount = 0;

    private int sessionHitCount = 0;
    private int sessionShotCount = 0;

    private int sessionSize = 500;

    private double shotsPerSecond = 1000d;
    private double nextTimeToFire = 0d;

    // Update is called once per frame
    void Update() {
        if (Time.timeAsDouble >= nextTimeToFire) {
            Shoot();
            nextTimeToFire = Time.timeAsDouble + 1d / shotsPerSecond;
        }
    }

    void Shoot() {
        RaycastHit hitInfo;
        totalShotCount++;
        sessionShotCount++;
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hitInfo)) {

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null) {
                sessionHitCount++;
                totalHitCount++;
            }
        }

        if (sessionShotCount == sessionSize) {
            float hitPercentage = (float)sessionHitCount / sessionSize * 100;
            if (hitPercentage >= GameSettings.increaseSpeedThreshold) {
                expectedTarget.speed += speedModifier;
            } else if (hitPercentage < GameSettings.maintainSpeedThreshold) {
                expectedTarget.speed -= speedModifier;
                if (expectedTarget.speed < 0) expectedTarget.speed = 0;
            }

            sessionHitCount = 0;
            sessionShotCount = 0;
        }
    }
}
