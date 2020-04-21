//HERE BEGIN DIRECT QUOTES FROM SKOOTER500
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class SteeringBehaviour:MonoBehaviour
{
	public float weight = 1.0f;
	public Vector3 force;

	[HideInInspector]
	public CarBoid boid;

	public void Awake()
	{
		boid = GetComponent<CarBoid>();
	}

	public abstract Vector3 Calculate();
}
//HERE CONCLUDE DIRECT QUOTES FROM SKOOTER500
