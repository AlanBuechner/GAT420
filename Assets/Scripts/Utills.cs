using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utills
{
	public static Vector3 Wrap(Vector3 v, Vector3 min, Vector3 max)
	{
		Vector3 result = v;
		if (result.x > max.x) result.x = min.x + (v.x - max.x);
		if (result.x < min.x) result.x = max.x + (v.x - min.x);

		if (result.y > max.y) result.y = min.y + (v.y - max.y);
		if (result.y < min.y) result.y = max.y + (v.y - min.y);

		if (result.z > max.z) result.z = min.z + (v.z - max.z);
		if (result.z < min.z) result.z = max.z + (v.z - min.z);
		return result;
	}
}
