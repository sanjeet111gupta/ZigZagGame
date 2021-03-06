﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformSpawner : MonoBehaviour {
	public GameObject plateform;
	public GameObject diamonds;
	Vector3 lastPos;
	float size;
	public bool gameOver;


	// Use this for initialization
	void Start () {
		lastPos = plateform.transform.position;
		size = plateform.transform.lossyScale.x;
		for (int i = 0; i <20  ; i++) {
			SpawnPlatforms ();
		}
		//InvokeRepeating ("SpawnPlatforms",2f,0.2f);
	}

	public void StartSpawningPlatforms(){
		InvokeRepeating ("SpawnPlatforms",2f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver==true) {
			CancelInvoke("SpawnPlatforms");
		}
	}

	void SpawnPlatforms(){
		
		int rand = Random.Range (0, 6);
		if (rand < 3) {
			SpawnX ();
		} else if (rand >= 3) {
		
			SpawnZ ();
		}
	}
	void SpawnX(){
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (plateform, pos, Quaternion.identity);
	
		int rand = Random.Range (0, 4);
		//generating diamond in x spawn
		if (rand < 1) {
			Instantiate (diamonds,new Vector3(pos.x,pos.y+1,pos.z), diamonds.transform.rotation);
		

		}

	}
	void SpawnZ(){
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (plateform, pos, Quaternion.identity);

		int rand = Random.Range (0, 4);
		//generating diamonds in z spawn
		if (rand < 1) {
			Instantiate (diamonds,new Vector3(pos.x,pos.y+1,pos.z), diamonds.transform.rotation);
		

		}
	}

}
