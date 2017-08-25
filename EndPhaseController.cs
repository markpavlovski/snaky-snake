using System.Collections;
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


	public string finalMessage;
	

	void Start(){

		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();
		/*
		GameObject panel = GameObject.Find ("End Panel");
		panel.GetComponent<EndDisplay> ().message.text = masterController.gameWinnerMessage;
		*/
	}


	void Update () {




		ChangePhase();

	}

}


