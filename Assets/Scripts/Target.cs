using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().Win();
        }
    }
}
