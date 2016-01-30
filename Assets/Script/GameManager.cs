using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject thought;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("InitThoughts", 0, Random.Range (0, 5));

	}

	// Update is called once per frame
	void Update () {

	}

	void InitThoughts () {

		GameObject go = Instantiate (thought, new Vector2 (Random.Range (-Defines.radius, Defines.radius), 
			Random.Range (-Defines.radius, Defines.radius)), Quaternion.identity) as GameObject;

	}
}
