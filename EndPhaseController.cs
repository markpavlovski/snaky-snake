using UnityEngine;

public class EndPhaseController : MonoBehaviour {

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


	void Update () {

		ChangePhase();

	}

}
