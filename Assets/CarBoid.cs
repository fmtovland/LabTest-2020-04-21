using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBoid : MonoBehaviour
{
	//HERE BEGIN DIRECT QUOTES FROM SKOOTER500
	List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

	public Vector3 force = Vector3.zero;
	public Vector3 acceleration = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	public float mass = 1;
	public float maxForce = 10.0f;

	void Start()
	{

		SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

		foreach (SteeringBehaviour b in behaviours)
		{
			this.behaviours.Add(b);			
		}
	}

	Vector3 Calculate()
	{
		force = Vector3.zero;

		// Weighted prioritised truncated running sum
		// 1. Behaviours are weighted
		// 2. Behaviours are prioritised
		// 3. Truncated
		// 4. Running sum


		foreach (SteeringBehaviour b in behaviours)
		{
			if (b.isActiveAndEnabled)
			{
				force += b.Calculate() * b.weight;

				float f = force.magnitude;
				if (f >= maxForce)
				{
					force = Vector3.ClampMagnitude(force, maxForce);
					break;
				}			   
			}
		}
		
		return force;
	}
	//HERE ENDS DIRECT QUOTES FROM SKOOTER500
}
