using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public InputManager inputManager;
    public float jumpAccelerationThreshold;
    public float jumpSpeed;

    private Rigidbody rb;
    private bool jumping = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
        if (inputManager.GetAccelerationMagnitude() > jumpAccelerationThreshold && !jumping) {
            DoJump();
        }
    }

    private void DoJump() {
        rb.velocity = new Vector3(
                rb.velocity.x,
                jumpSpeed,
                rb.velocity.z);
        jumping = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            jumping = false;
        }
    }
}
