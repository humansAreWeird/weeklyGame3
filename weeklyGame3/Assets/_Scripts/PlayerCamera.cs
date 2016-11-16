using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float cameraSpeed = 1f;
    public float jawRange = 3f;
    public Vector3 fwd;

    private float jaw;
    private float pitch;
    private Vector3 mouseMovement;

    private Rigidbody playerRigidBody;

	void Update () {
        cameraMovement();
    }

    void FixedUpdate() {
        gameObject.transform.rotation = Quaternion.Euler(mouseMovement);


    }

    void cameraMovement()
    {
        pitch = Input.mousePosition.x;
        jaw = Input.mousePosition.y;
        mouseMovement = new Vector3((-jaw / jawRange) + 75, pitch, 0f);
    }

}
