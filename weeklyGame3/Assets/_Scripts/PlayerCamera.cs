using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float cameraSpeed = 1f;
    public float jawRange = 3f;

    private float jaw;
    private float pitch;
    private Vector3 mouseMovement;

    private Rigidbody playerRigidBody;

	void Update () {
        pitch = Input.mousePosition.x;
        jaw  = Input.mousePosition.y;
        mouseMovement = new Vector3((-jaw / jawRange) + 75, pitch, 0f);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, fwd, 10))
            {
                print("object detected");
            }
        }
    }

    void FixedUpdate() {
        gameObject.transform.rotation = Quaternion.Euler(mouseMovement);
    }
}
