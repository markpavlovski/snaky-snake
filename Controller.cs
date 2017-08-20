using UnityEngine;
using UnityEngine.UI; 
using System;

public class Controller : MonoBehaviour {

	public Initialize prefab;
	public Text roundTextLabel;

	Initialize newRound;
	GameObject[] children;
	bool roundOver = true;
	int roundCounter = 0;



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

	void ChangeRoundName(String name){
		
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = name;

	}




	void Start(){

		roundCounter = 0; 
		newRound = Instantiate<Initialize> (prefab);

	}

	void Update () {

		ChangeRoundName ("Round Two");
		StartNewRound ();
		EndRound ();
		
	}


}
