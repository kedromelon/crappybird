using UnityEngine;
using System.Collections;

public class SpawnPipes : MonoBehaviour {

	public int numToSpawn = 10;

	public GameObject pipe;

	// Use this for initialization
	void Start () {

		float pipeX = 5f;
		float pipeY;

		for (int i = 0; i < numToSpawn; i++){
			pipeY = Random.Range(-5,3);
			Instantiate(pipe, new Vector2(pipeX,pipeY), Quaternion.identity);
			pipeX += 5f;
		}
	}

}
