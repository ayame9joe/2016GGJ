using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ThoughtScript : MonoBehaviour {

	Vector2 thisPos;

	void Start () {
		
		thisPos = this.transform.position;
		this.transform.DORotate (new Vector3 (0, 0, Random.Range (-180, 180)), 0);

		MoveThoughts ();
	}

	void Update () {

		DestroyThoughts ();

	}

	void MoveThoughts () {
		this.transform.DOMove (new Vector2 (thisPos.x + Random.Range (-10, 10),
			thisPos.y + Random.Range (-10, 10)), 15f);
	}

	void DestroyThoughts () {
		if (this.transform.position.x > Defines.radius ||
			this.transform.position.x < -Defines.radius ||
			this.transform.position.y > Defines.radius ||
			this.transform.position.y < -Defines.radius ) {
			Destroy (this.gameObject);
			//GameManager.vitality -= 0.1f;
			Defines.maxVitality -= 0.1f;
		}
	}
		
}
