using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float offset = -2.5f;
	public Transform player;

	Vector3 moveVector;

	// Update is called once per frame
	void Update () {

		ScreenShake2D.Update();

		moveVector = transform.position;
		moveVector.x = player.position.x + offset;

		transform.position = moveVector;

	}
}
