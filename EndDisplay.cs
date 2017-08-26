using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndDisplay : MonoBehaviour {

	public Text message;
	public Text score;


	void Start(){

		// GameObject gameMaster = GameObject.Find ("Game Master");
		MasterController masterController = GameObject.Find ("Game Master").GetComponent<MasterController> ();

		message.text = masterController.gameWinnerMessage;
		score.text = masterController.gameFinalScore;


	}

}
