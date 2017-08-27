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

	float maxScore;
	int maxRound = 10;
	int i = 0;





	Initialize newRound;
	GameObject[] children;
	bool roundOver = true;
	int roundCounter = 1;
	string message;



	void StartNewRound(){

		if (roundOver) {

		

				roundOver = false;
				ChangeRoundName ("ROUND " + roundCounter.ToString ());
				ChangeScoreLabel (score, "SNAKYSNAKE");
				newRound = Instantiate<Initialize> (prefab);
				newRound.transform.SetParent (gameObject.transform);

			}

	}

	void ClearRound(){


		if (newRound.roundEnded & i == 0) {

			score += newRound.roundScore;
			maxScore = Mathf.Max(score.x, score.y);
			message = newRound.winMessage;
			ChangeScoreLabel (score, message);
			i++;

		}


		if (Input.GetKeyDown (KeyCode.Space) && newRound.roundEnded ) {

			i = 0;
			message = newRound.winMessage;
			GameObject.Destroy (newRound.gameObject);
			roundOver = true;
			roundCounter++;
			ChangeRoundName ("ROUND " + roundCounter.ToString ());
			ChangeScoreLabel (score, message);

			if ( maxScore >= 5 || roundCounter > maxRound) {

				if (score.x > score.y) {
					masterController.gameWinnerMessage = "GREEN PLAYER WINS";
				} else if (score.y > score.x) {
					masterController.gameWinnerMessage = "PINK PLAYER WINS";
				} else {
					masterController.gameWinnerMessage = "IT'S A TIE";
				}

				masterController.gameFinalScore = score.x.ToString() + " : " + score.y.ToString();

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

	}

	void Update () {

		ChangePhase();
		StartNewRound ();
		ClearRound ();
	
		
	}


}
