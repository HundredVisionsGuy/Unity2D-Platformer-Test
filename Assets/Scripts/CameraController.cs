using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private float minimum, maximum;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
		minimum = -2.0f;
		maximum = 2.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
		transform.position = new Vector3(
			transform.position.x,
			Mathf.Clamp(transform.position.y, minimum, maximum), transform.position.z);
	}
}
