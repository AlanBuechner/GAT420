using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
	[SerializeField]
	private float m_WanderRadius = 1.0f;
	[SerializeField]
	private float m_WanderDistance = 1.0f;
	[SerializeField]
	private float m_WanderFrequency = 1.0f;
	private float m_Angle = 0.0f;

	public Vector3 Steer(AutonomusAgent agent, Vector3 target)
	{
		return CalculateSteering(agent, (target - agent.transform.position));
	}

	public Vector3 Flee(AutonomusAgent agent, Vector3 target)
	{
		return CalculateSteering(agent, (agent.transform.position - target));
	}

	public Vector3 Wander(AutonomusAgent agent)
	{
		m_Angle += Random.Range(-m_WanderFrequency, m_WanderFrequency);
		Vector3 dir = (new Vector3(Mathf.Cos(m_Angle), 0, Mathf.Sin(m_Angle)) * m_WanderRadius) + (agent.transform.forward * m_WanderDistance);
		return CalculateSteering(agent, dir);
	}

	private Vector3 CalculateSteering(AutonomusAgent agent, Vector3 dir)
	{
		Vector3 steering = (dir - agent.m_Velocity);
		Vector3.ClampMagnitude(steering, agent.m_MaxForce);
		return steering;
	}
}
