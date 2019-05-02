using UnityEngine;
using System.Collections;

public class EatScript : MonoBehaviour
{
	private AudioSource eatSound1_AUD;
	private GameObject newCloneObject_GO;
    private GameController gameController_script;
	
	void Awake(){
        eatSound1_AUD = GameObject.Find("EatSound").GetComponent<AudioSource>();
        gameController_script = GameObject.Find("GameManager").GetComponent<GameController>();
    }
	
	void Start(){
		transform.position = new Vector2(-2.95f+Random.Range(0,12)*0.5f, 4.7f-Random.Range(0,14)*0.5f);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "head"){
            eatSound1_AUD.Play();
            newCloneObject_GO = (GameObject)Instantiate(gameObject);
            newCloneObject_GO.name="FOOD";
			gameController_script.incPointsGC();
			Destroy(gameObject);
		}
	}
}
