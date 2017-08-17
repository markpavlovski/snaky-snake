using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour {

	public Vector3 boardScale;
	public List<Vector3> borderLocations = new List<Vector3> ();
	Vector3 borderPositionUp;
	Vector3 borderPositionDown;
	Vector3 borderPositionLeft;
	Vector3 borderPositionRight;

	public int borderLength;

	void Start () {
		gameObject.GetComponent<Transform> ().localScale = boardScale;
		GenerateBorder ();
	}

	void GenerateBorder(){
			/*
		for (int i = 0; i < boardScale.x; i++) {

			borderPositionDown = new Vector3 ((float)i, -1f, -1f);
			borderLocations.Add (borderPositionDown);

			borderPositionUp = new Vector3 ((float)i, boardScale.x + 1f, -1f);
			borderLocations.Add (borderPositionUp);

		}

		for (int j = 0; j < boardScale.y + 2 ; j++) {

			borderPositionLeft = new Vector3 (-1f, -1f + (float) j, -1f);
			borderLocations.Add (borderPositionLeft);

			borderPositionRight = new Vector3 (boardScale.x+1f, -1f + (float) j, -1f);
			borderLocations.Add (borderPositionRight);

		}


		borderLength = borderLocations.Count;
*/
	}



}
