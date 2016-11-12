using UnityEngine;
public class Mover : MonoBehaviour{

    public enum MotionState {SpinClockWise, SpinAntiClockwise, Vertical};

    public MotionState motionState = MotionState.SpinClockWise;

    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;

    public Transform targetTransform;

    void Update () {
        switch(motionState) {
            case MotionState.SpinClockWise:
                gameObject.transform.RotateAround(targetTransform.position, targetTransform.forward, spinSpeed * Time.deltaTime);
                break;
            case MotionState.SpinAntiClockwise:
                gameObject.transform.RotateAround(targetTransform.position, targetTransform.forward, - spinSpeed * Time.deltaTime);
                break;
            case MotionState.Vertical:
                gameObject.transform.Translate(Vector3.forward * Mathf.Sin(Time.timeSinceLevelLoad * 5f) * motionMagnitude);
                break;
        }
    }



}
