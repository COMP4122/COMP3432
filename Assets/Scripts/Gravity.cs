using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
    public float gravityMagnitude;
    public InputManager rotationInput;

    private Vector3 gravityDirection;
    private float zAngle;
    private float xAngle;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;
	}

    void FixedUpdate() {
        // gravityDirection = GetGyroScopeGravity();
        ModifyGravityDirection();

        rb.AddForce(gravityDirection * gravityMagnitude, ForceMode.Force);
    }

    void ModifyGravityDirection() {
        zAngle = rotationInput.GetZRotationInRad();
        xAngle = rotationInput.GetXRotationInRad();

        gravityDirection.x = Mathf.Sin(xAngle);
        gravityDirection.y = -1f;
        gravityDirection.z = Mathf.Sin(zAngle);
        gravityDirection = gravityDirection.normalized;
    }
}
