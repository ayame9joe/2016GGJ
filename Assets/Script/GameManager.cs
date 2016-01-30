using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/// <summary>
	/// 思绪片段
	/// </summary>
	public GameObject thought;

	/// <summary>
	/// The sword.
	/// </summary>
	public GameObject sword;

	private float timeInterval;
	private float timeTemp = 0f;
	private bool countTime;

	private int swordNumber;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("ThoughtsInitiation", 0, Random.Range (0, 0.5f));

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			Meditation ();

		}

	}

	void ThoughtsInitiation () {

		GameObject go = Instantiate (thought, new Vector2 (Random.Range (-Defines.radius, Defines.radius), 
			Random.Range (-Defines.radius, Defines.radius)), Quaternion.identity) as GameObject;

	}

	void Meditation () {
	
		SwordNumberCalculation ();
		SwordInitiation ();

	}

	void SwordNumberCalculation () {

		if (!countTime) {
			timeInterval = Time.time - timeTemp;
			countTime = true;
		} 
		if (countTime) {
			timeTemp = Time.time;
			countTime = false;
		}

		swordNumber = (int)(Defines.maxSwordNumber / timeInterval);
			
	}

	void SwordInitiation () {

		for (int i = 0; i <= swordNumber; i++) {
			Instantiate (sword, new Vector2 (0, 0), Quaternion.identity);
		}

	}
}
