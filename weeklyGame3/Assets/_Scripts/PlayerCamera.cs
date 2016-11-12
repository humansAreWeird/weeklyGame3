using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float cameraSpeed = 1f;

    private float jaw;
    private float pitch;
    private Vector3 mouseMovement;

    private Rigidbody playerRigidBody;


	void Start () {

	}
	

	void Update () {

        pitch = Input.mousePosition.x;
        jaw  = Input.mousePosition.y;
        mouseMovement = new Vector3(jaw, pitch, 0f);
	}

    void FixedUpdate() {
       gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(mouseMovement), Time.deltaTime * cameraSpeed);
    }
}
