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
        mouseMovement = new Vector3(-jaw / jawRange, pitch, 0f);
	}

    void FixedUpdate() {
        gameObject.transform.rotation = Quaternion.Euler(mouseMovement);
    }
}
