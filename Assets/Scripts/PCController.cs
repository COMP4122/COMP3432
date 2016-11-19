using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PCController : NetworkBehaviour {
    public float gravityMagnitude;
    
    private Vector3 gravityDirection;
    private float zAngle = 0.0f;
    private float xAngle = 0.0f;
    public float jumpAccelerationThreshold;
    public float jumpSpeed;

    private int levelNo;
    private const int totalScene = 5;
    private bool jumping = false, requestJump = false, jumpRequested = false;
    public string localip;

    private NetworkManager manager;
    private Rigidbody rb;
    private InputManager inputManager;

    void Start ()
    {
        //Debug.Log(GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().IsClientConnected());
        //Debug.Log(GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().numPlayers);
        levelNo = SceneManager.GetActiveScene().buildIndex;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        inputManager = GameObject.FindGameObjectWithTag("Input Manager").GetComponent<InputManager>();
        manager = GameObject.FindObjectOfType<NetworkManager>();
        gravityDirection = Vector3.down;
        //Debug.Log(GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().IsClientConnected());    
        //Debug.Log(isServer); Debug.Log(levelNo);
        if (isServer && levelNo == 0)
        {
            localip = "HostIP: " + Network.player.ipAddress;
            GameObject.Find("HostIP").GetComponent<Text>().text = localip;
        }
    }
	
    /*
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdJump();
            CmdJump();
        }

        float x = 0.0f, z = 0.0f;
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
        if (!isServer)
        {
            CmdMove(x, z);
        }
        else {
            rb.velocity = new Vector3(rb.velocity.x + x, 0.0f, rb.velocity.z + z);
        }
    }

    [Command]
    void CmdMove(float x, float z) {
        rb.velocity = new Vector3(rb.velocity.x+x, rb.velocity.y, rb.velocity.z+z);
    }*/
    

    void FixedUpdate() {
        
        if (isServer)
        {
            zAngle = inputManager.GetZRotationInRad();
            CmdModifyGravityDirection(zAngle, true);
        }
        else
        {
            xAngle = inputManager.GetXRotationInRad();
            CmdModifyGravityDirection(xAngle, false);
        }
        
        /*zAngle = inputManager.GetZRotationInRad();
        xAngle = inputManager.GetXRotationInRad();
        CmdModifyGravityDirection(xAngle, false);
        CmdModifyGravityDirection(zAngle, true);
        */
        if (inputManager.GetAccelerationMagnitude() > jumpAccelerationThreshold && !jumping && !jumpRequested)
        {
            CmdJump();
            jumpRequested = true;
            StartCoroutine(JumpCount());
        }
    }

    [Command]
    void CmdModifyGravityDirection(float angle, bool mode)
    {
        
        if (!mode)
        {
            gravityDirection.x = Mathf.Sin(angle);
            gravityDirection.z = 0.0f;
        }
        else
        {
            gravityDirection.z = Mathf.Sin(angle);
            gravityDirection.x = 0.0f;
        }

        gravityDirection.y = -1f;
        gravityDirection = gravityDirection.normalized;
        rb.AddForce(gravityDirection * gravityMagnitude, ForceMode.Force);
    }

    public bool isJumping()
    {
        return jumping;
    }

    [Command]
    void CmdJump()
    {

        if (requestJump)
        {
            rb.velocity = new Vector3(
                    rb.velocity.x,
                    jumpSpeed,
                    rb.velocity.z);
            RpcJumping();
        }
        else {
            requestJump = true;
            StartCoroutine(JumpCount());
        }
    }

    IEnumerator JumpCount() {
        yield return new WaitForSeconds(0.5f);
        requestJump = false;
        jumpRequested = false;
    }

    [Command]
    public void CmdHitGround()
    {
        RpcNotJumping();
    }

    [ClientRpc]
    void RpcNotJumping()
    {
        jumping = false;
    }

    [ClientRpc]
    void RpcJumping()
    {
        jumping = true;
        GetComponent<AudioSource>().Play();
    }

    public void ReloadLevel()
    {
        if (isServer)
        {
            manager.ServerChangeScene("Level" + levelNo);
        }
            
    }

    public void LoadNextScene()
    {
        if (isServer)
        {
            if (levelNo < totalScene)
            {
                int nextLevelNo = levelNo + 1;
                manager.ServerChangeScene("Level" + nextLevelNo);
            }
        }
    }
}
