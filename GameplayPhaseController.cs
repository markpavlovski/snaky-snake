using UnityEngine;
using UnityEngine.UI; 
using System;

public class GameplayPhaseController : MonoBehaviour {

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
	string nameOfTheGame = "SNAKYSNAKE";



	void StartNewRound(){


		if (Input.GetKeyDown (KeyCode.N) && roundOver) {
			
			roundOver = false;
			newRound = Instantiate<Initialize> (prefab);
			ChangeScoreLabel (score , nameOfTheGame);


		}

	}

	void ClearRound(){

		if (Input.GetKeyDown (KeyCode.Space)) {

			score += newRound.roundScore;
			message = newRound.winMessage;
			GameObject.Destroy(newRound.gameObject);
			roundOver = true;
			roundCounter++;
			ChangeRoundName ("ROUND " + roundCounter.ToString());
			ChangeScoreLabel (score , message);


		}

	}

	void ChangeRoundName(String name){
		
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().roundLabel.text = name;

	}

	void ChangeScoreLabel (Vector2 score, string message){
		GameObject panel = GameObject.Find ("Panel");
		panel.GetComponent<DisplayScript> ().playerOneLabel.text = "GREEN: " + score.x.ToString ();
		panel.GetComponent<DisplayScript> ().playerTwoLabel.text = "PINK: " + score.y.ToString ();
		panel.GetComponent<DisplayScript> ().headerLabel.text = message;
		panel.GetComponent<DisplayScript> ().headerLabel.color = Color.green;



	}




	void Start(){

		ChangeRoundName ("ROUND " + roundCounter.ToString());
		StartNewRound ();


	}

	void Update () {
	
		StartNewRound ();
		ClearRound ();
		ChangePhase();
		
	}


}
