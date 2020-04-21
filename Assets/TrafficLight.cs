using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
	public enum Colour{GREEN,ORANGE,RED};
	public Material[] materials;
	public Colour colour;
	
	// Start is called before the first frame update
	void Start()
	{
		SetColour((Colour)Random.Range(0,materials.Length));
		StartCoroutine(ChangeColour());
	}

	IEnumerator ChangeColour()
	{
		while(true)
		{
			if(colour==Colour.ORANGE)
			{
				yield return new WaitForSeconds(4);
			}
			
			else	//red and green have the same behaviour. if they need
					//to specify different times an else if block for each
					//should be created. alternatively the entire if else
					//block could be converted to a switch statement
			{
				yield return new WaitForSeconds(Random.Range(5,10));
			}
			
			SetColour((Colour)((int)(colour+1)%materials.Length));
		}
	}
	
	public void SetColour(Colour colour)
	{
		this.colour=colour;
		GetComponent<Renderer>().material=materials[(int)colour];
	}
}
