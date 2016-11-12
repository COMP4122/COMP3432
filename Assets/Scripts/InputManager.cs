using UnityEngine;

public class InputManager : MonoBehaviour{

    public float rotationSpeedInEulerAngle;

    void Start() {
        Input.gyro.enabled = true;
    }

    void Update() {
        // Debug.Log(Input.gyro.userAcceleration.magnitude);
    }

    public float GetXRotationInRad() {
        return Input.gyro.gravity.x;
    }

    public float GetZRotationInRad() {
        return Input.gyro.gravity.y;
    }

    public float GetAccelerationMagnitude() {
        return Input.gyro.userAcceleration.magnitude;
    }

    #region not used yet
    private float GetXRotationInEulerAngle() {
        float sinInRad = Input.gyro.gravity.x;
        float angleInRad = Mathf.Asin(sinInRad);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        return angleInDeg;
    }

    private float GetZRotationInEulerAngle() {
        float sinInRad = Input.gyro.gravity.y;
        float angleInRad = Mathf.Asin(sinInRad);
        float angleInDeg = angleInRad * Mathf.Rad2Deg;
        return angleInDeg;
    }
    #endregion
}
