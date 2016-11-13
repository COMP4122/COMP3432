using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

	public float rotateSpeed = 45f;

    void Update() {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
