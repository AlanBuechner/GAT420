using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perseption : MonoBehaviour
{
	public string m_TagName;

	public abstract GameObject[] GetGameObjects();
}
