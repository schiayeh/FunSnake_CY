using UnityEngine;
using System.Collections;

public class snakeKnockWall : MonoBehaviour {

	private GameController gc;
	
	void Awake(){
		gc = GameObject.Find ("GameManager").GetComponent<GameController> ();
	}
	void Update(){
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "border")
		{
			GameObject buf = GameObject.Find("block");
			
			if (col.gameObject.name=="BordersRight")
			{
				//place need to change according to calculations
				transform.position = new Vector2(-2.95f, transform.position.y);
			}
			else if (col.gameObject.name=="BordersLeft")
			{
				transform.position = new Vector2(2.95f, transform.position.y);
			}
			else if (col.gameObject.name=="BordersUp")
			{
				transform.position = new Vector2(transform.position.x, -2.20f);
			}
			else if (col.gameObject.name=="BordersBtm")
			{
				transform.position = new Vector2(transform.position.x, 4.70f);
			}
		}

		if (col.gameObject.tag == "body") {
			gc.isGameOver=true;
		}
	}
}
