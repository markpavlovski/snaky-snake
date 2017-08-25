using UnityEngine;
using UnityEngine.UI; 
using System;
using System.Collections.Generic;

public class GameplayPhaseController : MonoBehaviour {

	// Phase Change Logic
	MasterController masterController;
	bool changePhase = false;

	void ChangePhase(){

		if (changePhase) {

			changePhase = false;
			masterController.loadNextPhase = true;

		}

	}

	// Definitions

	public Initialize prefab;
	public Text roundTextLabel;
	public Text greenScore;
	public Text pinkScore;
	public Vector2 score = new Vector2 (0,0);


	Initialize newRound;
	GameObject[] children;
	bool roundOver = true;
	int roundCounter = 1;
	string message;
	// string nameOfTheGame = "SNAKYSNAKE";



	void StartNewRound(){

		if (roundOver) {

		

				roundOver = false;
				newRound = Instantiate<Initialize> (prefab);
				newRound.transform.SetParent (gameObject.transform);
				//ChangeScoreLabel (score , nameOfTheGame);

			}

	}

	void ClearRound(){
		

			if (Input.GetKeyDown (KeyCode.Space)) {

				score += newRound.roundScore;
				message = newRound.winMessage;
				GameObject.Destroy (newRound.gameObject);
				roundOver = true;
				roundCounter++;
				ChangeRoundName ("ROUND " + roundCounter.ToString ());
				ChangeScoreLabel (score, message);

				if (roundCounter > 5) {
					changePhase = true;
				} 


			}
		}

	void ChangeRoundName(String name){

		GameObject panel = GameObject.Find ("Gameplay Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = name;

	}

	void ChangeScoreLabel (Vector2 score, string message){
		
		GameObject panel = GameObject.Find ("Gameplay Panel");
		panel.GetComponent<DisplayScript> ().playerOneLabel.text = "GREEN: " + score.x.ToString ();
		panel.GetComponent<DisplayScript> ().playerTwoLabel.text = "PINK: " + score.y.ToString ();
		panel.GetComponent<DisplayScript> ().headerLabel.text = message;
	}




	void Start(){
		
		GameObject gameMaster = GameObject.Find ("Game Master");
		masterController = gameMaster.GetComponent<MasterController> ();
		PlayerPrefs.SetString("Last Winner", "Nice...");

	}

	void Update () {

		ChangePhase();
		StartNewRound ();
		ClearRound ();
	
		
	}


}
