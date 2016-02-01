using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SwordScript : MonoBehaviour {

	float tempX;
	float tempY;
	float angle;
	// Use this for initialization
	void Start () {


		tempX = Random.Range (-Defines.radius, Defines.radius);
		//Debug.Log (tempX);
		tempY = Random.Range (-10, 10);





	}

	// Update is called once per frame
	void Update () {

		if ( tempY < 0) { 
			this.transform.DOMove (new Vector3 (tempX, -1 * Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX), 0), 2);
			if (tempX > 0) {
				angle = Mathf.Asin (Mathf.Abs (tempX) / Defines.radius);
				transform.localRotation = Quaternion.Euler (0f, 0f, this.angle * Mathf.Rad2Deg);
			} else {
				angle = - Mathf.Asin (Mathf.Abs (tempX) / Defines.radius);
				transform.localRotation = Quaternion.Euler (0f, 0f, this.angle * Mathf.Rad2Deg);
			}
		} else {
			this.transform.DOMove (new Vector3 (tempX, Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX), 0), 2);
			if (tempX > 0) {
				angle = 90 + Mathf.Acos(Mathf.Abs(tempX / Defines.radius));
				transform.localRotation = Quaternion.Euler (0f, 0f, this.angle * Mathf.Rad2Deg);
			} else {
				angle = - 90 - Mathf.Acos(Mathf.Abs(tempX / Defines.radius));
				transform.localRotation = Quaternion.Euler (0f, 0f, this.angle * Mathf.Rad2Deg);
			}
		}
			
		if (Mathf.Abs(Vector3.Distance (this.transform.position, new Vector3 (0, 0, 0)) - Defines.radius) < 0.1f) {
			Destroy (this.transform.gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Thought") {
			Destroy (other.gameObject);
		}
	}
}