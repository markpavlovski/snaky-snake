using UnityEngine;
using System.Collections.Generic;

public class Initialize : MonoBehaviour {


	// General

	public int maxIterations;
	public int score;
	public char initialOrientation;
	public Vector2 initialPosition;
	public float timeScale;

	float timeStep;
	float timeSinceLastStep;
	int counter = 0;
	Vector3 newPosition;
	Vector3 direction;
	List<Vector3> blockLocations = new List<Vector3> ();
	List<MeshRenderer> blockMeshes = new List<MeshRenderer> ();
	List<Vector3> killList = new List<Vector3> ();


	// Block Creation;

	public Mesh blockMesh;
	public Material blockMaterial;
	public Material lastMaterial;


	// Directional Vectors

	Vector3 move;
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

	void CreateBlock( Vector3 position ){

		GameObject newBlock = new GameObject ();
		newBlock.AddComponent<MeshFilter> ().mesh = blockMesh;
		newBlock.AddComponent<MeshRenderer> ().material = blockMaterial;
		newBlock.GetComponent<Transform> ().localPosition = position;

		blockMeshes.Add (newBlock.GetComponent<MeshRenderer> ());
		blockLocations.Add (position);
		killList.Add(position);

		score = blockLocations.Count-1;

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

	Vector3 DirectionInput(){

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			move = moveUp;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			move = moveDown;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move = moveLeft;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move = moveRight;
		}

		return move;

	}

	void AssignFinalBlock(int index){

		if ( index > 0) {
			blockMeshes [index - 1].material = lastMaterial;
		}

	}



	void Start () {

		// Set time scale
		timeStep = 1 / timeScale;


		// Set border kill zone
		killList.AddRange (GenerateBorder ());

		// Generate a starting block
		newPosition = new Vector3 (initialPosition.x + 0.5f, initialPosition.y + 0.5f, -1f);
		CreateBlock (newPosition);
		counter++;


		// Set starting direction
		if (initialOrientation == 'U') {
			move = moveUp;
		} 
		else if (initialOrientation == 'D') {
			move = moveDown;
		} 
		else if (initialOrientation == 'L') {
			move = moveLeft;
		} 
		else if (initialOrientation == 'R') {
			move = moveRight;
		} 
		else {
			move = moveDown; // default
		}

	}

	void FixedUpdate(){

		timeSinceLastStep += Time.deltaTime;
		direction = DirectionInput ();


		if (timeSinceLastStep >= timeStep) {

			timeSinceLastStep -= timeStep;

			if (counter < maxIterations) {

				newPosition += direction;

				if (KillCondition (newPosition)) {

					AssignFinalBlock (counter);
					counter = int.MaxValue;

				} else {

					CreateBlock (newPosition);
					counter++;

				}

			}

		}

	}



}
