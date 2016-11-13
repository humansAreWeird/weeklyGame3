using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 5f;
    public float jumpSpeed = 5;
    public float fall = 1f;


    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 mouseMovement;
    private float horizontalMovement;
    private float verticalMovement;
    private float jump = 0f;
    private bool isJumping = false;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Update () {

    horizontalMovement = Input.GetAxis("Horizontal");
    verticalMovement = Input.GetAxis("Vertical");

        if (isJumping)
        {
            movement /= 2;
            jump = -fall;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            jump = jumpSpeed;
            isJumping = true;
        }
        else
            jump = 0f;


        movement = new Vector3(horizontalMovement, jump, verticalMovement);
    
        mouseMovement = new Vector3(0f, Input.mousePosition.x, 0f);
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(movement * speed * Time.deltaTime * 60);

        gameObject.transform.rotation = Quaternion.Euler(mouseMovement);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor") && isJumping)
            isJumping = false;
    }
}
