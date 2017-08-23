using UnityEngine;

public class MasterController : MonoBehaviour {

	public GameObject[] gamePhases = new GameObject[3];


	public int phaseIndex = 0;



	void Start () {

		GameObject newPhase = Instantiate<GameObject> (gamePhases [phaseIndex]);
		
	}
	
	void Update () {
		
	}



}
