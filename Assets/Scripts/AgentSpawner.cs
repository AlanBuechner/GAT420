using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
	[SerializeField]
	private Agent m_Agent;
	[SerializeField]
	private LayerMask m_LayerMask;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, m_LayerMask))
			{
				Instantiate(m_Agent, hitInfo.point, Quaternion.identity);
			}
		}
	}
}
