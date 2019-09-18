using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float SpawnTimer = 0;
	public bool SpawnerOn = true;
	public ItemFunction[] DroppedItems;
	int t = 30;

	void Update () {
		if (SpawnTimer < t && SpawnerOn)
			SpawnTimer += Time.deltaTime;
		if (SpawnTimer >= t) {
			DroppedItems = FindObjectsOfType<ItemFunction> ();
			if(DroppedItems.Length <= 10){
			AllItems.Instance.RanDrop ();
				}
			SpawnTimer = 0;
		}
	}

	private static Spawner instance;
	public static Spawner Instance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<Spawner> ();
			}
			return instance;
		}
	}
}
