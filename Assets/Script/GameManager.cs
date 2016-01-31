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

	private float holdTime;
	private float holdTimeTemp;
	private float holdTimeInterval;

	private float stopTime;
	private float stopTimeTemp;
	private float stopTimeInterval;

	private int swordNumber;

	private int hitTimes;

	private int level;



	// Use this for initialization
	void Start () {

		InvokeRepeating ("InitiationThoughts", 0, Random.Range (0, 0.5f));

	}

	// Update is called once per frame
	void Update () {

		SwordAttack ();
		Bomb ();
		StopInitThoughts ();
		LevelUp ();

	}

	/// <summary>
	/// Initiations the thoughts.
	/// </summary>
	void InitiationThoughts () {

		GameObject go = Instantiate (thought, new Vector2 (Random.Range (-Defines.radius, Defines.radius), 
			Random.Range (-Defines.radius, Defines.radius)), Quaternion.identity) as GameObject;

	}


	/// <summary>
	/// Calculate and init sword.
	/// </summary>
	void SwordAttack () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			CalculationSwordNumber ();
			InitiationSword ();
		}

	}

	/// <summary>
	/// Calculations the sword number.
	/// </summary>
	void CalculationSwordNumber () {

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

	/// <summary>
	/// Initiations the sword.
	/// </summary>
	void InitiationSword () {

		for (int i = 0; i <= swordNumber; i++) {
			Instantiate (sword, new Vector2 (0, 0), Quaternion.identity);
		}

	}

	void LevelUp () {
		if (timeInterval < 1) {
			hitTimes++;
		} else {
			hitTimes = 0;
		}

		if (hitTimes > 5) {
			level++;
			hitTimes = 0;
		}
	}

	void Bomb () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			holdTimeTemp = holdTime;
			holdTime = 0;

		}

		if (Input.GetKey (KeyCode.Space)) {

			holdTime += 1f;

			holdTimeInterval = (holdTime - holdTimeTemp);

		} 
	}

	void StopInitThoughts () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			stopTimeTemp = stopTime;
			stopTime = 0;

		}

		if (Input.GetKey (KeyCode.Space)) {

		} else {

			stopTime += 1f;

			stopTimeInterval = stopTime - stopTimeTemp;
		}
	}
}
