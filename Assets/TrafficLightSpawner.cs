using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSpawner : MonoBehaviour
{
	public int lightCount,radius;
	public GameObject LightPrefab;
	public GameObject[] lights;

	// Start is called before the first frame update
	void Start()
	{
		Vector3 position;
		lights=new GameObject[lightCount];

		for(int i=0; i<lightCount; i++)
		{
			float angle=(Mathf.PI*2)*((float)i/lightCount);
			position=new Vector3(radius*Mathf.Cos(angle),0,radius*Mathf.Sin(angle));
			lights[i]=Instantiate(LightPrefab,position,Quaternion.identity);
		}
	}
}
