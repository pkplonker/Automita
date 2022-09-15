using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuartH
{

	/// <summary>
	///Collectable - Provide collectable movement
	/// </summary>
	public class Collectable : MonoBehaviour
	{
		[SerializeField] private float speed = 10f;

		private void Update()
		{
			transform.Rotate(Vector3.up, speed * Time.deltaTime);
		}
	}
}
