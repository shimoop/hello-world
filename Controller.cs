using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody rigbody;
	Camera viewCamera;
	Vector3 velocity;

	void Awake()
	{
		rigbody = GetComponent<Rigidbody>();
		viewCamera = Camera.main;	
	}

	void Start () {
	
	}

	void Update () 
	{
		Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		transform.LookAt(mousePos + Vector3.up * transform.position.y);
		velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
	}

	void FixedUpdate ()
	{
		rigbody.MovePosition(rigbody.position + velocity * Time.fixedDeltaTime);
	}
}
