using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {

	public static float speed = 2;
	private int direction = 2;
	private int act_direction = 2;
	private float seconds = 0.5f;
	
	private bool moving;
	private GameController gc;

	// Use this for initialization
	void Awake () {
		gc = GameObject.Find ("GameManager").GetComponent<GameController> ();
	}
	
	void MoveInDirection()
	{
		seconds -= speed * Time.deltaTime;
		if (seconds <= 0){
            oneMove();
		}
	}
	
	void oneMove()
	{
		Vector2 previousPosition = transform.position;
		if (direction == 1)
		{
			transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
			if(gameObject.transform.localEulerAngles != new Vector3(0,0,90))
				gameObject.transform.localEulerAngles = new Vector3(0,0,270);	
		}
		
		else if (direction == 2)
		{
			transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
			
			if(gameObject.transform.localEulerAngles != new Vector3(0,0,270))
				gameObject.transform.localEulerAngles = new Vector3(0,0,90);
		}
		
		else if (direction == 3)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y +0.5f);
			
			if(gameObject.transform.localEulerAngles != new Vector3(0,0,0))
				gameObject.transform.localEulerAngles = new Vector3(0,0,180);
		}
		
		else 
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
			
			if(gameObject.transform.localEulerAngles != new Vector3(0,0,180))
				gameObject.transform.localEulerAngles = new Vector3(0,0,0);
		}
		act_direction = direction;
		seconds = 0.5f;
		
		gc.MoveOtherBlocktoo(previousPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
		moving=gc.isGameOver;
		//transform.Translate(-Vector3.up * Time.deltaTime*speed);
		if(!moving)
			MoveInDirection();

		if (Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))
		{
			if (act_direction != 1 && act_direction != 2)
				direction = 1;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			if (act_direction != 1 && act_direction != 2)
				direction = 2;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if (act_direction != 3 && act_direction != 4)
				direction = 3;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if (act_direction != 3 && act_direction != 4)
				direction = 4;
		}
	}
	
	public void leftPress(){
		if (act_direction != 1 && act_direction != 2)
			direction = 1;
	}
	
	public void rightPress(){
		if (act_direction != 1 && act_direction != 2)
			direction = 2;
	}
	
	public void upPress(){
		if (act_direction != 3 && act_direction != 4)
			direction = 3;
	}
	
	public void downPress(){
		if (act_direction != 3 && act_direction != 4)
			direction = 4;
	}

}
