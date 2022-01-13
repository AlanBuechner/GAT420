using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private static Player s_Instance = null;

	[SerializeField] 
	private float speed;

	Player()
	{
		if (s_Instance != null)
			return;

		s_Instance = this;
	}

	public Player Get() { return s_Instance; }

	void Update()
	{
		Vector3 direction = Vector3.zero;

		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");

		transform.position += direction * speed * Time.deltaTime;
		transform.position = Utills.Wrap(transform.position, new Vector3(-25.0f, 0, -25.0f), new Vector3(25.0f, 0, 25.0f));
	}
}
