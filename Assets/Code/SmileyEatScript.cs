using UnityEngine;
using System.Collections;

public class SmileyEatScript : MonoBehaviour {

	private AudioSource eatSound_AUD;
    private GameController gameController_script;

	void Awake(){
        eatSound_AUD = GameObject.Find("SmileyEatSound").GetComponent<AudioSource>();
        gameController_script = GameObject.Find("GameManager").GetComponent<GameController>();
    }

	void Start(){
		
		//new position has to be the origin position + the possible position
		transform.position = new Vector2(-2.95f+Random.Range(0,12)*0.5f, 4.7f-Random.Range(0,14)*0.5f);
	}


	void OnTriggerEnter2D(Collider2D col)
	{	
		if(col.gameObject.tag == "head"){
            eatSound_AUD.Play();
            gameController_script.incSmileyPointsGC();
		    Destroy(gameObject);
		}
	}
}
