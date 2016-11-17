using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public GameObject playerCamera;

    public float speed = 5f;
    public float jumpSpeed = 5;
    public float fall = 1f;
    public float hookForse = 500f;

    private Rigidbody rb;
    private Vector3 movement;

    private float mouseY;
    private float mouseX;

    private Vector3 mouseMovement;
    private Vector3 fwd;

    private float horizontalMovement;
    private float verticalMovement;
    private float jump = 0f;

    private bool isJumping = false;

    private RaycastHit hit;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Update () {
        moving();
        jumping();
        fire();
    }

    void FixedUpdate() {
        rb.AddRelativeForce(movement * speed * Time.deltaTime * 60);
        gameObject.transform.rotation = Quaternion.Euler(mouseMovement);
    }



    void moving() {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalMovement, jump, verticalMovement);
        mouseMovement = new Vector3(0f, Input.mousePosition.x, 0f);
    }

    void jumping() {
        if (isJumping) {
            movement /= 2;
            jump = -fall;
        }
        else if (Input.GetButtonDown("Jump")) {
            jump = jumpSpeed;
            isJumping = true;
        }
        else
            jump = 0f;

        isJumping = true;
    }

    void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fwd =  playerCamera.transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(playerCamera.transform.position, fwd,out hit, 50))
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    rb.AddForce(fwd * hookForse * 100);
                }
            }
        }

    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Floor") && isJumping)
            isJumping = false; 
    }
}
