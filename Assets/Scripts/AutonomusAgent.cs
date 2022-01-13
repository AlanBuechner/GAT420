using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomusAgent : Agent
{
	[SerializeField]
	private Perseption m_Perseption;
	[SerializeField]
	private Steering m_Steering;

	public float m_MaxSpeed;
	public float m_MaxForce;

	public Vector3 m_Velocity = Vector3.zero;

	void Update()
	{
		Vector3 acceleration = Vector3.zero;

		GameObject[] objects = m_Perseption.GetGameObjects();
		if(objects.Length != 0)
		{
			// draw debug lines
			Debug.DrawLine(transform.position, objects[0].transform.position);

			Vector3 force = transform.position - objects[0].transform.position;
			acceleration += force.normalized * 3;
		}

		m_Velocity += acceleration * Time.deltaTime;
		m_Velocity = Vector3.ClampMagnitude(m_Velocity, m_MaxSpeed);
		transform.position += m_Velocity * Time.deltaTime;
		transform.position = Utills.Wrap(transform.position, new Vector3(-25.0f, 0, -25.0f), new Vector3(25.0f, 0, 25.0f));

	}
}
