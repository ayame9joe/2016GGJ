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
			//this.transform.LookAt (new Vector3 (tempX, -1 * Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)));
			//transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Asin ( (Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX))) * Mathf.Rad2Deg);
			//Quaternion rotation = Quaternion.LookRotation(new Vector3 (tempX, - Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)));
			//transform.Rotate(new Vector3 (0, 0, 90 + Mathf.Asin ( (Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)))) * 100);
			//transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Asin ((Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX))));
//			transform.rotation = Quaternion.Euler(transform.eulerAngles + (new Vector3 (0, 0, 90 + Mathf.Asin ((Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX))))));
			angle = Mathf.Asin ( Mathf.Abs(tempX) / Defines.radius);

			Debug.Log (angle);
			//Debug.Log((Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)) / Defines.radius);
			transform.localRotation = Quaternion.Euler(0f, 0f, this.angle * Mathf.Rad2Deg);
		} else {
			// Destroy (this.gameObject);
			this.transform.DOMove (new Vector3 (tempX, Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX), 0), 2);
			//this.transform.LookAt (new Vector3 (tempX, Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)));
			//Quaternion rotation = Quaternion.LookRotation(new Vector3 (tempX, Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)));
			//transform.rotation = rotation;
			//transform.Rotate(new Vector3 (0, 0, Mathf.Asin (tempX / Defines.radius)) * 100);
			//transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Asin (tempX / Defines.radius) * Mathf.Rad2Deg);
			//transform.eulerAngles = new Vector3 (0, 0, Mathf.Asin (tempX / Defines.radius));
			//transform.rotation = Quaternion.Euler(transform.eulerAngles + (new Vector3 (0, 0, Mathf.Asin (tempX / Defines.radius))));
angle = 90 + Mathf.Acos ( (Mathf.Sqrt (Defines.radius * Defines.radius - tempX * tempX)) / Defines.radius);
			//Debug.Log(tempX / Defines.radius);
			Debug.Log(this.angle);
			transform.localRotation = Quaternion.Euler(0f, 0f, this.angle * Mathf.Rad2Deg);
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