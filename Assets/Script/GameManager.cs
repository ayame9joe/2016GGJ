using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text txtVitality;
	public Text txtLevel;
	public Text txtNaturalTimeInterval;

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
	private float timeIntervalTemp;
	private float timeIntervalDiff;
	private bool countTime;
	private bool countTimeInterval;


	private float holdTime;
	private float holdTimeTemp;
	private float holdTimeInterval;

	private float stopTime;
	private float stopTimeTemp;
	private float stopTimeInterval;

	/// <summary>
	/// 固有频率。
	/// </summary>
	private float naturalTimeInterval;

	/// <summary>
	/// 体力值。
	/// </summary>
	public static float vitality = Defines.maxVitality;

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

	int spaceHoldTime;

	Animator anim;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("InitiationThoughts", 0 + Mathf.Abs (stopTimeInterval), Random.Range (Defines.minThoughtsTime, Defines.maxThoughtsTime));
		InvokeRepeating ("ChangeDayAndNight", 0, 8);

		anim = this.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		
		LevelUp ();


		if (vitality > 0) {
			if (level == 0) {
				SwordAttack ();
			} else if (level == 1) {
				SwordAttack ();
				Bomb ();
			} else if (level ==2) {
				SwordAttack ();
				Bomb ();
//				StopInitThoughts ();
			}
		}

		if (level > 2) {
			level = 2;
		}

		if (Input.GetKey (KeyCode.Space)) {
		
		} else {
			if (vitality < Defines.maxVitality) {
				vitality += 0.011f;
			}
		}

		txtVitality.text = "Vitality: " + vitality.ToString ();
		txtLevel.text = "Level: " + level.ToString ();
		txtNaturalTimeInterval.text = "Natural Time Interval: " + naturalTimeInterval.ToString ();

		Debug.Log (timeInterval);


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

			if (Mathf.Abs(timeIntervalDiff) < 0.3f) {
				hitTimes++;
			} else {
				hitTimes = 0;
			}

			CalculationSwordNumber ();
			InitiationSword ();
			ChecknaturalTimeInternalDiff ();
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

		if (countTimeInterval) {
			timeIntervalDiff = timeInterval - timeIntervalTemp;
			countTimeInterval = false;
		}
		if (!countTimeInterval) {
			timeIntervalTemp = timeInterval;
			countTimeInterval = true;
		}

		swordNumber = (int)(Defines.maxSwordNumber / Mathf.Abs(timeIntervalDiff) / 10);
			
	}

	/// <summary>
	/// Initiations the sword.
	/// </summary>
	void InitiationSword () {

		for (int i = 0; i <= swordNumber; i++) {
			Instantiate (sword, new Vector3 (0, 0, 0), Quaternion.identity);
		}

	}

	void ChecknaturalTimeInternalDiff () {
		if (Mathf.Abs (naturalTimeInterval - timeInterval) < 0.5f) {
			vitality += 1f;
			// TODO: 飘字
			Debug.Log ("vitality++");
		}
	}

	void LevelUp () {

		if (hitTimes > 5) {
			level++;
			hitTimes = 0;
		}
	}

	void Bomb () {
		if (Input.GetKeyDown (KeyCode.X)) {

			holdTimeTemp = holdTime;
			holdTime = 0;

		}

		if (Input.GetKey (KeyCode.X)) {

			vitality -= 0.5f;

			holdTime += 1f;

			holdTimeInterval = (holdTime - holdTimeTemp);

			if (vitality > 0) {
				if (!GameObject.FindGameObjectWithTag ("Boom")) {
					GameObject.Instantiate (boom, new Vector3 (0, 0, 0), Quaternion.identity);
				} else {
					Destroy (GameObject.FindGameObjectWithTag ("Boom"));
					GameObject.Instantiate (boom, new Vector3 (0, 0, 0), Quaternion.identity);
				}
			}
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


	}
		

	/*void StopInitThoughts () {
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
	}*/

	void ChangeDayAndNight () {
		dayTimes++;
		if (dayTimes % 2 == 0) {
			naturalTimeInterval = 0.5f;
		} else {
			naturalTimeInterval = 2;
		}

	}
		
}
