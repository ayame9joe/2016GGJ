using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SwordScript : MonoBehaviour {

	float tempX;
	float tempY;
	// Use this for initialization
	void Start () {


		tempX = Random.Range (-Defines.radius, Defines.radius);
		//Debug.Log (tempX);
		tempY = Random.Range (-10, 10);



	}

	// Update is called once per frame
	void Update () {

		if ( tempY > 0) {
			this.transform.DOMove (new Vector3 (tempX, -1 * Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX), 0), 2);
			//transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Asin ( (Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX))) * Mathf.Rad2Deg);

		} else {
			this.transform.DOMove (new Vector3 (tempX, Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX), 0), 2);
			//transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Asin (tempX / Defines.radius) * Mathf.Rad2Deg);
		}

		/*if (tempY > 0) {
			this.transform.DORotate (new Vector3 (0, 0, Mathf.Asin (tempX / Defines.radius)), 0.01f);
		} else {
			this.transform.DORotate (new Vector3 (0, 0, 90 + Mathf.Asin ( (Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)))), 0.01f);
		}*/

		//Debug.Log (Vector3.Distance (this.transform.position, new Vector3 (0, 0, 0)));

		if (Mathf.Abs(Vector3.Distance (this.transform.position, new Vector3 (0, 0, 0)) - Defines.radius) < 0.1f) {
			//moveHasFinished = true;
			Destroy (this.transform.gameObject);


		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Thought") {
			Destroy (other.gameObject);
		}
	}
}