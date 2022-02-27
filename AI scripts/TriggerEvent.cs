using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour {
	void OnTriggerEnter (Collider other)
	{
		if(other.CompareTag("food"))
		{
			Debug.Log("HELLO");
		}
	}
	void OnTriggerExit (Collider other)
	{
		if(other.CompareTag("food"))
		{
			Debug.Log("GOODBYE");
		}
	}
}
