using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerseption : Perseption
{
	[SerializeField]
	private float m_Radius = 10.0f;
	[SerializeField]
	private float m_MaxAngle = 45.0f;
	[SerializeField]
	private LayerMask m_Mask;

	public override GameObject[] GetGameObjects()
	{
		var colliders = Physics.OverlapSphere(transform.position, m_Radius, m_Mask);
		List<GameObject> result = new List<GameObject>(colliders.Length);
		foreach (var c in colliders)
		{
			if (c.gameObject == gameObject) continue;
			if(m_TagName == "" || c.tag == m_TagName)
			{
				float angle = Mathf.Acos(Vector3.Dot(transform.forward, (c.transform.position - transform.position).normalized));
				if(Mathf.Rad2Deg * angle <= m_MaxAngle)
					result.Add(c.gameObject);
			}
		}

		return result.ToArray();
	}
}
