﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GameManager : MonoBehaviour {

	/// <summary>
	/// 思绪片段
	/// </summary>
	public GameObject thought;

	/// <summary>
	/// The sword.
	/// </summary>
	public GameObject sword;

	public GameObject boom;

	private float timeInterval;
	private float timeTemp = 0f;
	private bool countTime;

	private float holdTime;
	private float holdTimeTemp;
	private float holdTimeInterval;

	private float stopTime;
	private float stopTimeTemp;
	private float stopTimeInterval;

	/// <summary>
	/// 固有频率。
	/// </summary>
	private float natualTimeInterval;

	/// <summary>
	/// 体力值。
	/// </summary>
	public float vitality = 10;

	private int swordNumber;

	/// <summary>
	/// 连击次数。
	/// </summary>
	private int hitTimes;

	/// <summary>
	/// 等级。
	/// </summary>
	private int level;

	private int dayTimes;

	Animator anim;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("InitiationThoughts", 0 + Mathf.Abs (stopTimeInterval), Random.Range (Defines.minThoughtsTime, Defines.maxThoughtsTime));
		InvokeRepeating ("ChangeDayAndNight", 0, 5);

		anim = this.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		
		LevelUp ();

		if (level == 0) {
			SwordAttack ();
		} else if (level == 1) {
			SwordAttack ();
			Bomb ();
		} else if (level == 2) {
			SwordAttack ();
			Bomb ();
			StopInitThoughts ();
		}





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

			vitality -= 1f;

			if (timeInterval < 1) {
				hitTimes++;
			} else {
				hitTimes = 0;
			}

			CalculationSwordNumber ();
			InitiationSword ();
			CheckNatualTimeInternalDiff ();
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
			Instantiate (sword, new Vector3 (0, 0, 0), Quaternion.identity);
		}

	}

	void CheckNatualTimeInternalDiff () {
		if (Mathf.Abs (natualTimeInterval - timeInterval) < 0.5f) {
			vitality += 2f;
		}
	}

	void LevelUp () {

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

			vitality -= 0.1f;

			holdTime += 1f;

			holdTimeInterval = (holdTime - holdTimeTemp);

		} 

		GameObject.Instantiate (boom, new Vector3 (0, 0, 0), Quaternion.identity);

		GameObject[] go = GameObject.FindGameObjectsWithTag ("Thought");
		for (int i = 0; i < go.Length; i++) {
			if (go [i].transform.position.x < -2 ||
			    go [i].transform.position.x > 2 ||
			    go [i].transform.position.y < -2 ||
			    go [i].transform.position.y > 2) {
				Destroy (go [i].transform.gameObject);
			}
		}
	}

	void StopInitThoughts () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			stopTimeTemp = stopTime;
			stopTime = 0;

		}

		if (Input.GetKey (KeyCode.Space)) {

		} else {

			vitality -= 0.1f;

			stopTime += 1f;

			stopTimeInterval = stopTime - stopTimeTemp;
		}
	}

	void ChangeDayAndNight () {
		dayTimes++;
		if (dayTimes % 2 == 0) {
			natualTimeInterval = 2;
		} else {
			natualTimeInterval = 5;
		}

	}
		
}
