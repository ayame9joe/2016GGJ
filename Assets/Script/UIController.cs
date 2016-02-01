using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Animation))]
public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameStart ();
	}

	void GameStart () {
		if (Input.anyKeyDown) {

			//this.GetComponent<Animation> ().Play ();
			this.GetComponent<Animation>().Play("eyeBallOpenAndClose");
						
		}
	}
}
