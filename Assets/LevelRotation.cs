using UnityEngine;
using System.Collections;

public class LevelRotation : MonoBehaviour {

    public Vector3 rotationSpeed;
    public RotationInput rotationInput;

    public float xRotationLimit;
    public float zRotationLimit;

    private float xRotationChange;
    private float zRotationChange;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (IsXRotationInLimit())
            xRotationChange = GetXRotationChange();
        else
            xRotationChange = 0;

        if (IsZRotationInLimit())
            zRotationChange = GetZRotationChange();
        else
            zRotationChange = 0;

	    transform.Rotate(new Vector3(xRotationChange, 0f, zRotationChange));
	}

    float GetXRotationChange() {
        return rotationInput.GetXRotationChangeInEulerAngle() * rotationSpeed.x * Time.deltaTime;
    }

    float GetZRotationChange() {
        return - rotationInput.GetZRotationChangeInEulerAngle() * rotationSpeed.z * Time.deltaTime;
    }

    float GetXRotationEulerAngle() {
        return transform.rotation.eulerAngles.x;
    }

    float GetZRotationEulerAngle() {
        return transform.rotation.eulerAngles.z;
    }

    bool IsXRotationInLimit() {
        return Mathf.Abs(GetXRotationEulerAngle()) < xRotationLimit;
    }

    bool IsZRotationInLimit() {
        return Mathf.Abs(GetZRotationEulerAngle()) < zRotationLimit;
    }
}
