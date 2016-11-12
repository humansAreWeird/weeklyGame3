using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 5f;
    public float jumpSpeed = 5;


    private Rigidbody rb;
    private Vector3 movement;
    private float horizontalMovement;
    private float verticalMovement;
    private float jump = 0f;
    bool isJumping = false;
    public Transform playerCameraTranform;

	void Start () {
        rb = GetComponent<Rigidbody>();
//        playerCamera = GetComponent<Transform>();
	}

    void Update () {
        Quaternion.

        horizontalMovement = Input.GetAxis("Horizontal");
    verticalMovement = Input.GetAxis("Vertical");
    jump = 0f;

    if (!isJumping && Input.GetButtonDown("Jump"))
        {
            jump = jumpSpeed;
            isJumping = true;
        }
    if (isJumping)
        movement /= 2;

    movement = new Vector3(horizontalMovement, jump, verticalMovement);
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.deltaTime * 60);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor") && isJumping)
            isJumping = false;
    }
}
