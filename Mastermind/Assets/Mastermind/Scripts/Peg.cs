using UnityEngine;
public class Peg : MonoBehaviour 
{
	public Material[] pegcolors; 
	public int pegcolornr = 0; 
	
	// Change color of peg - Will be set in Logic when it instantiate a peg.
	void Start () 
	{
		GetComponent<Renderer>().material = pegcolors[pegcolornr];
	}
}
