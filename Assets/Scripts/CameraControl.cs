using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float cameraHeight = 120f;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float zMin;
    public float zMax;

    public GameObject player;

    void Start() {
        transform.position = new Vector3(0f, cameraHeight, 0f);
    }
	void FixedUpdate () {
		
		if (player.transform.position.x < xMin) {
            transform.position = new Vector3(player.transform.position.x - xMin, transform.position.y, transform.position.z);
        }
        
        if (player.transform.position.x > xMax) {
            transform.position = new Vector3(player.transform.position.x - xMax, transform.position.y, transform.position.z);
        }

        if (player.transform.position.y < yMin) {
            transform.position = new Vector3(transform.position.x, cameraHeight + player.transform.position.y - yMin, transform.position.z);
        }

        if (player.transform.position.y > yMax) {
            transform.position = new Vector3(transform.position.x, cameraHeight + player.transform.position.y - yMax, transform.position.z);
        }

        if (player.transform.position.z < zMin) {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - zMin);
        }

        if (player.transform.position.z > zMax) {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - zMax);
        }
	}
}
