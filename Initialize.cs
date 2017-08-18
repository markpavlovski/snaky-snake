using UnityEngine;
using System.Collections.Generic;

public class Initialize : MonoBehaviour {


	// General

	public int maxIterations;
	public int scoreOne;
	public int scoreTwo;
	public char initialOrientationOne;
	public char initialOrientationTwo;
	public Vector2 initialPositionOne;
	public Vector2 initialPositionTwo;
	public float timeScale;

	float timeStep;
	float timeSinceLastStep;
	int counter = 0;
	Vector3 newPositionOne;
	Vector3 newPositionTwo;
	Vector3 directionOne;
	Vector3 directionTwo;
	List<Vector3> blockLocations = new List<Vector3> ();
	List<MeshRenderer> blockMeshes = new List<MeshRenderer> ();
	List<Vector3> killList = new List<Vector3> ();


	// Block Creation;

	public Mesh blockMesh;
	public Material blockMaterialOne;
	public Material blockMaterialTwo;
	public Material lastMaterial;


	// Directional Vectors

	Vector3 moveOne;
	Vector3 moveTwo;
	Vector3 moveUp = new Vector3 (0f,1f,0f);
	Vector3 moveDown = new Vector3 (0f,-1f,0f);
	Vector3 moveLeft = new Vector3 (-1f,0f,0f);
	Vector3 moveRight = new Vector3 (1f,0f,0f);

	// Border setup

	public int borderLength;
	public List<Vector3> borderLocations = new List<Vector3> ();

	Vector2 boardScale = new Vector2(50f,50f);
	Vector3 borderPositionUp;
	Vector3 borderPositionDown;
	Vector3 borderPositionLeft;
	Vector3 borderPositionRight;



	// Supporting Methods


	bool KillCondition (Vector3 position){

		return killList.Contains (position);

	}

	void CreateBlockOne( Vector3 position ){

		GameObject newBlock = new GameObject ();

		newBlock.transform.SetParent (gameObject.transform);

		newBlock.AddComponent<MeshFilter> ().mesh = blockMesh;
		newBlock.AddComponent<MeshRenderer> ().material = blockMaterialOne;
		newBlock.GetComponent<Transform> ().localPosition = position;

		blockMeshes.Add (newBlock.GetComponent<MeshRenderer> ());
		blockLocations.Add (position);
		killList.Add(position);

	}

	void CreateBlockTwo( Vector3 position ){

		GameObject newBlock = new GameObject ();

		newBlock.transform.SetParent (gameObject.transform);

		newBlock.AddComponent<MeshFilter> ().mesh = blockMesh;
		newBlock.AddComponent<MeshRenderer> ().material = blockMaterialTwo;
		newBlock.GetComponent<Transform> ().localPosition = position;

		blockMeshes.Add (newBlock.GetComponent<MeshRenderer> ());
		blockLocations.Add (position);
		killList.Add(position);

	}

	List<Vector3> GenerateBorder(){

		for (int i = 0; i < boardScale.x; i++) {

			borderPositionDown = new Vector3 ((float)i + 0.5f, -0.5f, -1f);
			borderLocations.Add (borderPositionDown);

			borderPositionUp = new Vector3 ((float)i + 0.5f, boardScale.x + 0.5f, -1f);
			borderLocations.Add (borderPositionUp);

		}

		for (int j = 0; j < boardScale.y + 2; j++) {

			borderPositionLeft = new Vector3 (-0.5f, -0.5f + (float)j, -1f);
			borderLocations.Add (borderPositionLeft);

			borderPositionRight = new Vector3 (boardScale.x + 0.5f, -0.5f + (float)j, -1f);
			borderLocations.Add (borderPositionRight);

		}

		borderLength = borderLocations.Count;
		return borderLocations;

	}

	Vector3 DirectionOneInput(){

		if (moveOne == moveUp) {

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				moveOne = moveLeft;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				moveOne = moveRight;
			}
			return moveOne;
		}

		if (moveOne == moveDown) {

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				moveOne = moveLeft;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				moveOne = moveRight;
			}
			return moveOne;
		}

		if (moveOne == moveLeft) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				moveOne = moveUp;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				moveOne = moveDown;
			}
			return moveOne;
		}

		if (moveOne == moveRight) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				moveOne = moveUp;
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				moveOne = moveDown;
			}
			return moveOne;
		}

		return moveOne;
	}

	Vector3 DirectionTwoInput(){

		if (moveTwo == moveUp) {

			if (Input.GetKeyDown (KeyCode.A)) {
				moveTwo = moveLeft;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				moveTwo = moveRight;
			}
			return moveTwo;
		}

		if (moveTwo == moveDown) {

			if (Input.GetKeyDown (KeyCode.A)) {
				moveTwo = moveLeft;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				moveTwo = moveRight;
			}
			return moveTwo;
		}

		if (moveTwo == moveLeft) {
			if (Input.GetKeyDown (KeyCode.W)) {
				moveTwo = moveUp;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				moveTwo = moveDown;
			}
			return moveTwo;
		}

		if (moveTwo == moveRight) {
			if (Input.GetKeyDown (KeyCode.W)) {
				moveTwo = moveUp;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				moveTwo = moveDown;
			}
			return moveTwo;
		}

		return moveTwo;
	}

	void AssignFinalBlock(int index){

		if ( index > 0) {
			blockMeshes [index - 1].material = lastMaterial;
		}

	}

	void StartPlayerOne(){

		// Generate a starting block
		newPositionOne = new Vector3 (initialPositionOne.x + 0.5f, initialPositionOne.y + 0.5f, -1f);
		CreateBlockOne (newPositionOne);
		counter++;


		// Set starting direction
		if (initialOrientationOne == 'U') {
			moveOne = moveUp;
		} 
		else if (initialOrientationOne == 'D') {
			moveOne = moveDown;
		} 
		else if (initialOrientationOne == 'L') {
			moveOne = moveLeft;
		} 
		else if (initialOrientationOne == 'R') {
			moveOne = moveRight;
		} 
		else {
			moveOne = moveDown; // default
		}

	}

	void StartPlayerTwo(){

		// Generate a starting block
		newPositionTwo = new Vector3 (initialPositionTwo.x + 0.5f, initialPositionTwo.y + 0.5f, -1f);
		CreateBlockTwo (newPositionTwo);
		counter++;


		// Set starting direction
		if (initialOrientationTwo == 'U') {
			moveTwo = moveUp;
		} 
		else if (initialOrientationTwo == 'D') {
			moveTwo = moveDown;
		} 
		else if (initialOrientationTwo == 'L') {
			moveTwo = moveLeft;
		} 
		else if (initialOrientationTwo == 'R') {
			moveTwo = moveRight;
		} 
		else {
			moveTwo = moveDown; // default
		}

	}




	void Start () {

		// Set time scale
		timeStep = 1 / timeScale;


		// Set border kill zone
		killList.AddRange (GenerateBorder ());

		// Initialize Players;
		StartPlayerOne();
		StartPlayerTwo();

		counter++;

	}


	void Update(){

		directionOne = DirectionOneInput ();
		directionTwo = DirectionTwoInput ();

	}

	void FixedUpdate(){

		timeSinceLastStep += Time.deltaTime;


		if (timeSinceLastStep >= timeStep) {

			timeSinceLastStep -= timeStep;

			if (counter < maxIterations) {

				newPositionOne += directionOne;
				newPositionTwo += directionTwo;

				if (KillCondition (newPositionOne) || KillCondition (newPositionTwo)) {


					if (KillCondition(newPositionOne)) {

						AssignFinalBlock (2 * counter - 5);

					} 

					if (KillCondition(newPositionTwo)){

						AssignFinalBlock (2 * counter - 4);

					}

					counter = int.MaxValue;

				} 

				else {

					CreateBlockOne (newPositionOne);
					CreateBlockTwo (newPositionTwo);
					counter++;

				}

			}

		}

	}



}