using UnityEngine;
using UnityEngine.UI; 
using System;

public class Controller : MonoBehaviour {

	public Initialize prefab;
	public Text roundTextLabel;

	Initialize newRound;
	GameObject[] children;
	bool roundOver = true;
	int roundCounter = 1;



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
			roundCounter++;
			ChangeRoundName ("ROUND " + roundCounter.ToString());


		}

	}

	void ChangeRoundName(String name){
		
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = name;

	}




	void Start(){
		
		ChangeRoundName ("ROUND " + roundCounter.ToString());

	}

	void Update () {

	
		StartNewRound ();
		EndRound ();
		
	}


}
