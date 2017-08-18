using UnityEngine;

public class Controller : MonoBehaviour {

	public Initialize prefab;

	Initialize newRound;


	void Start(){

		newRound = Instantiate<Initialize> (prefab);

	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			
			Destroy(newRound);

		}
	}
}
