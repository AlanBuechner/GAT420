using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerseption : Perseption
{

	[SerializeField]
	private float m_Radius = 10.0f;
	[SerializeField]
	private float m_MaxAngle = 45.0f;
	public override GameObject[] GetGameObjects()
	{
		var colliders = Physics.OverlapSphere(transform.position, m_Radius);
		List<GameObject> result = new List<GameObject>(colliders.Length);
		foreach (var c in colliders)
			if(m_TagName == "" || c.tag == m_TagName)
				result.Add(c.gameObject);

		return result.ToArray();
	}
}
