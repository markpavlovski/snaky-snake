﻿using System.Collections;
using UnityEngine;

public class EndPhaseController : MonoBehaviour {

	MasterController masterController;
	bool changePhase = false;

	void ChangePhase(){
		changePhase = Input.GetKeyDown (KeyCode.Return);
		if (changePhase) {
			changePhase = false;
			masterController.loadNextPhase = true;
		}
	}



	

	void Start(){

		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();

	}


	void Update () {

		ChangePhase();

	}

}


