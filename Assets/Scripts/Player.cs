using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameManager gameManager;

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Collectable") {
            gameManager.AddScore(collision.gameObject.GetComponent<Collectable>().Score);
            Destroy(collision.gameObject);
        }
    }

    public void Win() {
        gameManager.Win();
    }
    public void Die() {
        gameManager.Lose();
    }
}
