using System.Collections;
using UnityEngine;

public class StartPhaseController : MonoBehaviour {

	public GameObject userInterfacePrefab;

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


	void Start(){

		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();

		masterController.userInterface = Instantiate<GameObject> (userInterfacePrefab);
		masterController.userInterface.transform.SetParent (gameObject.transform);

	}


	void Update () {


		ChangePhase();

		/*
		string lastWinner = PlayerPrefs.GetString("Last Winner");

		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = lastWinner;
		*/

	}

}


