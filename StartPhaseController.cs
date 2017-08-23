using UnityEngine;
using System.Collections;

public class StartPhaseController : MonoBehaviour {

	// Phase Change Logic
	GameObject gameMaster = GameObject.Find ("Game Master");
	MasterController masterController = gameMaster.GetComponent<MasterController> ();
	bool changePhase = false;

	void ChangePhase(){

		changePhase = Input.GetKeyDown (KeyCode.Z);
		if (changePhase) {

			changePhase = false;
			masterController.loadNextPhase = true;

		}

	}

	IEnumerator  AutoStart(){

		WaitForSeconds wait = new WaitForSeconds(10.0f);
		masterController.loadNextPhase = true;

	}


	// Get Stats from user preference file

	string lastWinner = PlayerPrefs.GetString("Last Winner"));
	



	void Awake (){

		StartCoroutine(AutoStart());

	}

	void Start(){
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = lastWinner;
	}


	void Update () {

		ChangePhase();

	}

}


