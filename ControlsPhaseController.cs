using UnityEngine;
using UnityEngine.UI; 
using System;
using System.Collections.Generic;

public class ControlsPhaseController : MonoBehaviour {

	MasterController masterController;
	bool changePhase = false;
	bool nextKey = false;
	float timeSinceStart = 0f;
	float initialWaitTime = 3f;

	void ChangePhase(){


		if (changePhase) {
			changePhase = false;
			masterController.loadNextPhase = true;
		}

	}




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


	void Update (){

		nextKey = Input.GetKeyDown (KeyCode.Space);
	}


}




