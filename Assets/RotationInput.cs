using UnityEngine;

public class RotationInput : MonoBehaviour{

    public float rotationSpeedInEulerAngle;

    void Start() {
        Input.gyro.enabled = true;
    }
    void Update() {
        // Debug.Log("X angle: " + GetXRotationInEulerAngle());
        // Debug.Log("Z angle: " + GetZRotationInEulerAngle());
        // Debug.Log(Input.gyro.gravity);
    }

    public float GetXRotationInEulerAngle() {
        float sinInRad = Input.gyro.gravity.x;
        float angleInRad = Mathf.Asin(sinInRad);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        return angleInDeg;
    }

    public float GetXRotationInRad() {
        return Input.gyro.gravity.x;
    }

    public float GetZRotationInEulerAngle() {
        float sinInRad = Input.gyro.gravity.y;
        float angleInRad = Mathf.Asin(sinInRad);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        return angleInDeg;
    }

    public float GetZRotationInRad() {
        return Input.gyro.gravity.y;
    }

    public float GetZRotationChangeInEulerAngle() {
        return Input.GetAxis("Vertical") * rotationSpeedInEulerAngle * Time.deltaTime;
    }

    public float GetXRotationChangeInEulerAngle() {
        return Input.GetAxis("Horizontal") * rotationSpeedInEulerAngle * Time.deltaTime;
    }

    public Vector3 GetGyroGravity() {
        return Input.gyro.gravity;
    }
}
