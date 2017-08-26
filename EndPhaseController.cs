using UnityEngine;
using UnityEngine.UI; 
using System;
using System.Collections.Generic;

public class EndPhaseController : MonoBehaviour {

	MasterController masterController;
	bool changePhase = false;
	bool nextKey = false;
	float timeSinceStart = 0f;
	float initialWaitTime = 10f;


	void ChangePhase(){
		if (changePhase) {
			changePhase = false;
			masterController.loadNextPhase = true;
		}
	}


	public string finalMessage;
	

	void Start(){

		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();

	}


	void FixedUpdate () {

		timeSinceStart += Time.deltaTime;

		if ( nextKey || timeSinceStart >= initialWaitTime){

			changePhase = true;
		}

		ChangePhase();

	}

	void Update () {

		nextKey = Input.GetKeyDown (KeyCode.Space);

	}


}


