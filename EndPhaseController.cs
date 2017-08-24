using UnityEngine;

public class EndPhaseController : MonoBehaviour {

	// Phase Change Logic
	MasterController masterController ;
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
	
	}


	void Update () {

		ChangePhase();

	}

}
