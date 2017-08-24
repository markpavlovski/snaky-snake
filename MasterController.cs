using UnityEngine;

public class MasterController : MonoBehaviour {

	// 

	public GameObject[] gamePhases = new GameObject[3];
	public int phaseIndex = 0;
	public bool loadNextPhase = false;

	public int gamesToDate = 0;
	public Vector2[] gameScores;
	public string lastWinner = "Yellow Player";



	GameObject currentPhase;


	// Suppotring Methods

		bool CheckPhaseSwitch(){

			return false;

		}

		int ChangePhaseIndex(int currentPhase){


			if (currentPhase == 0){
				return 1;
			} else if (currentPhase == 1){
				return 2;
			} else if (currentPhase == 3){
				return 0;
			} else {
				return 0;
			}

		}

		void InitiatePhase(int phase){

				currentPhase = Instantiate<GameObject> (gamePhases [phase]);

		}

		void EndCurrentPhase(){

			if (!currentPhase.Equals(null)){

				GameObject.Destroy(currentPhase.gameObject);
				
			}

		}
	


	void Start () {

		InitiatePhase(phaseIndex);

	}
	
	void Update () {


		if (loadNextPhase) {

			loadNextPhase = false;

			EndCurrentPhase();
			phaseIndex = ChangePhaseIndex(phaseIndex);
			InitiatePhase(phaseIndex);


		}
		
	}



}
