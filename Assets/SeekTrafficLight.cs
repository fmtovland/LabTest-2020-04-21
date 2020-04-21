using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTrafficLight : SteeringBehaviour
{
	public float arriveRadius;
	public TrafficLightSpawner tls;
	public TrafficLight target;
	
	void Start()
	{
		StartCoroutine(waitForSpawner());
	}

	public override Vector3 Calculate()
	{
		if(target==null) return Vector3.zero;

		if(Vector3.Distance(transform.position, target.transform.position) < arriveRadius||
		target.colour!=TrafficLight.Colour.GREEN)
		{
			try
			{
				ChangeTarget();
			}
			
			catch(AllLightsRed e)
			{
				return Vector3.zero;
			}
		}
	
		return boid.ArriveForce(target.transform.position);
	}
	
	void ChangeTarget()
	{
		int i=0;

		do{
			target=tls.lights[Random.Range(0,tls.lightCount)].GetComponent<TrafficLight>();
			i++;
		} while (target.colour!=TrafficLight.Colour.GREEN && i<30);
		
		if(i==30)
		{
			throw new AllLightsRed();
		}
	}

	IEnumerator waitForSpawner()
	{
		while(!tls.ready)
		{
			yield return new WaitForEndOfFrame();
		}
		
		ChangeTarget();
	}
	
	class AllLightsRed:System.Exception{}
}
