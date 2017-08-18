using UnityEngine;

public class Controller : MonoBehaviour {

	public Initialize prefab;

	Initialize newRound;
	GameObject[] children;
	bool roundOver = true;



	void StartNewRound(){

		if (Input.GetKeyDown (KeyCode.N) && roundOver) {
			roundOver = false;
			newRound = Instantiate<Initialize> (prefab);
		}

	}

	void EndRound(){

		if (Input.GetKeyDown (KeyCode.Space)) {

			GameObject.Destroy(newRound.gameObject);
			roundOver = true;
		}

	}





	void Start(){

		newRound = Instantiate<Initialize> (prefab);

	}

	void Update () {

		StartNewRound ();
		EndRound ();
		
	}


}
