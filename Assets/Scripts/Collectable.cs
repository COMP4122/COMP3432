using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public int Score;

    public enum MotionState {Spin,Horizontal, Vertical};

    public MotionState motionState = MotionState.Horizontal;

    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;

    void Update () {
        switch(motionState) {
            case MotionState.Spin:
                gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
                break;
            case MotionState.Horizontal:
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
            case MotionState.Vertical:
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
    }

}
