using UnityEngine;
using System.Collections;

public class SunAndMoonScript : MonoBehaviour {

	public float rotateSpeed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);
		//Debug.Log (Time.deltaTime * rotateSpeed);
	}
}
