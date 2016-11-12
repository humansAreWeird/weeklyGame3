using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float cameraSpeed = 1f;

    private Vector3 mousePosition;


	void Start () {
        mousePosition = new Vector3();
	}
	

	void Update () {
        mousePosition = Input.mousePosition;
	}

    void FixedUpdate() {
       gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(mousePosition), Time.deltaTime * cameraSpeed);
    }
}
