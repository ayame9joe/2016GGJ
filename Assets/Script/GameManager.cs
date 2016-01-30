using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/// <summary>
	/// 思绪片段
	/// </summary>
	public GameObject thought;

	private float timeInterval;
	private float timeTemp = 0f;
	private float timeIntervalDeviation;

	private int meditationTimes;

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

		Instantiate (thought, new Vector2 (Random.Range (-Defines.radius, Defines.radius), 
			Random.Range (-Defines.radius, Defines.radius)), Quaternion.identity) as GameObject;

	}

	void Meditation () {
	
		TimeIntervalDeviationCalculation ();

	}

	void TimeIntervalDeviationCalculation () {

		meditationTimes++;

		timeTemp = Time.time;
		if (meditationTimes == 1) {
			timeInterval = Time.time - timeTemp;
		}

		timeIntervalDeviation = (Time.time - timeTemp) - timeInterval;

	}
}
