using System.Collections;
using UnityEngine;

public class StartPhaseController : MonoBehaviour {

	// Phase Change Logic
	MasterController masterController;
	bool changePhase = false;

	void ChangePhase(){

		changePhase = Input.GetKeyDown (KeyCode.Z);
		if (changePhase) {

			changePhase = false;
			masterController.loadNextPhase = true;

		}

	}



	/*


	private void Awake () {
		StartCoroutine(AutoStart());
	}



	private IEnumerator AutoStart(){

		WaitForSeconds wait = new WaitForSeconds(10.0f);
		masterController.loadNextPhase = true;
		yield return wait;


	}*/

	void Start(){


		string lastWinner = PlayerPrefs.GetString("Last Winner");

		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();
		/*
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = "lastWinner";*/


	}


	void Update () {

		ChangePhase();

	}

}


