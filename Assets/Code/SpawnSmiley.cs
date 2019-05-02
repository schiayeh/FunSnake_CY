using UnityEngine;
using System.Collections;

public class SpawnSmiley : MonoBehaviour {

	public Transform [] SpawnPoints;
	public float spawnTime = 1.5f;
	public GameObject smiley_GO;
	private float time = 5;
	bool isDie;

	// Use this for initialization
	void Start () {
        if (!isDie)
        {
            InvokeRepeating("spawnSmileyRandom", 1.0f, Random.Range(3.0f,10.0f));
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void spawnSmileyRandom(){
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		GameObject SmileyClone = Instantiate (smiley_GO, SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation) as GameObject;
		Destroy (SmileyClone,time);
	}
}
