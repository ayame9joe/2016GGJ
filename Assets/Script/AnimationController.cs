using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			anim.Play ("EyeBallOpen");
		}
	
	}
}
