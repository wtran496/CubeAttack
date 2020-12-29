using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    //Player
    private Vector3 playerVelocity;
    [SerializeField]
    private CharacterController controller = null;
    private bool groundedPlayer;
    private PhotonView PV;

    //Movement
    public float movementSpeed = 100.0f;

    //Jump 
    private float jumpForce = -.6f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        PV = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (!PV.IsMine)
            return;
        KeepOnGround();
        JumpAndGravity();
    }

    void FixedUpdate() {
        if (PV.IsMine)
           Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerVelocity = new Vector3(horizontal * movementSpeed * Time.deltaTime, playerVelocity.y, vertical * movementSpeed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime * movementSpeed);
    }

    private void JumpAndGravity()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    //Don't go below surface
    private void KeepOnGround() {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }
}
