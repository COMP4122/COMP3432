using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    public AudioClip[] audioclips;
	public GameManager gameManager;
    private PCController controller;

    void Start() {
        
    }

    void OnTriggerEnter(Collider collision) {
        if (!isServer)
            return;
        if (collision.gameObject.tag == "Collectable") {
            RpcAddScore(collision.gameObject.GetComponent<Collectable>().Score);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Trigger1")
        {
            RpcInfo(1);
        }
        if (collision.gameObject.tag == "Trigger2")
        {
            RpcInfo(2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isServer)
            return;
        if (collision.gameObject.tag == "Target")
        {
            RpcWin();
        }
        if (collision.gameObject.tag == "Boundary") {
            RpcDie();
        }
        if (collision.gameObject.tag == "Ground") {
            controller = GameObject.FindObjectOfType<PCController>().GetComponent<PCController>();
            if (controller.isJumping())
                controller.CmdHitGround();
        }
    }

    [ClientRpc]
    public void RpcWin() {
        GetComponent<AudioSource>().clip = audioclips[0];
        GetComponent<AudioSource>().Play();
        gameManager.Win();
    }

    [ClientRpc]
    public void RpcDie() {
        GetComponent<AudioSource>().clip = audioclips[1];
        GetComponent<AudioSource>().Play();
        gameManager.Lose();
    }

    [ClientRpc]
    public void RpcAddScore(int score) {
        GetComponent<AudioSource>().clip = audioclips[0];
        GetComponent<AudioSource>().Play();
        gameManager.AddScore(score);
    }

    [ClientRpc]
    public void RpcInfo(int i)
    {
        if (i == 1)
        {
            GameObject.Find("Player1 Text").GetComponent<Text>().enabled = false;
            GameObject.Find("Player2 Text").GetComponent<Text>().enabled = true;
        }
        if (i == 2)
        {
            GameObject.Find("Player2 Text").GetComponent<Text>().enabled = false;
            GameObject.Find("Jump Text").GetComponent<Text>().enabled = true;
        }
    }
}
