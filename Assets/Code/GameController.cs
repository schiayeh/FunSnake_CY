using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static float speed = 2;
	private int direction = 2;
	private int act_direction = 2;
	private float seconds = 0.5f;

	public Text points_txt;
	public int points = 0;
	private bool init_first = false;
	
	private GameObject first_block_GO;
	public List<Vector2> block_positions = new List<Vector2>();
	public List <GameObject> AllObjects;
	
	public GameObject PanelGO;
	public Text GOScore_txt;
	public Text GOBestScore_txt;
	public GameObject TextScore_GO;
	public GameObject BestScoreReward_GO;
	private int newHighscore;
	public AudioSource BGMusic_AUD;
	public AudioSource BtnClick_AUD;

	private GameObject createdObject_GO;
	public bool isGameOver=false;
	public GameObject snakeBody;

	private bool eatSomething=false;
	private Vector2 previousPosition;
    private bool once = false;

    public GameObject MusicOnImage_GO;
    public GameObject MusicOffImage_GO;

    void Start () {
        PanelGO.SetActive(false);
        first_block_GO = GameObject.Find("block");
		block_positions.Add(first_block_GO.transform.position);
		AllObjects.Add(first_block_GO);
		
	}
	public void MoveOtherBlocktoo(Vector2 previousPosition){
		block_positions [0] = first_block_GO.transform.position;
		int allObjectAmount = AllObjects.Count - 1;
		if (eatSomething) {
			AddBlock (AllObjects[allObjectAmount].transform.position);
			eatSomething=false;
		}
		
		allObjectAmount = AllObjects.Count - 1;
		for (int i = allObjectAmount; i >0; i-- )
		{
			if(i!=1)
			{
				AllObjects[i].transform.position=AllObjects[i-1].transform.position;
			}
			else
			{
				AllObjects[i].transform.position=previousPosition;
			}
			AllObjects[i].SetActive (true);
		}
	}
	
	
	void Update (){
		if (isGameOver && once == false) {
			GameOver();
			once=true;
		}
	}
	
	public void GameOver(){
        GOScore_txt.text = points.ToString();
		PanelGO.SetActive(true);
		
		int oldHighscore = PlayerPrefs.GetInt("highscore");    
		if(points >oldHighscore){
			PlayerPrefs.SetInt("highscore",points);
			BestScoreReward_GO.SetActive(true);
		}
        GOBestScore_txt.text = "Best:"+ PlayerPrefs.GetInt("highscore");
		PlayerPrefs.Save();
		
		TextScore_GO.SetActive(false);
		BGMusic_AUD.Stop();
			
		for (int i = block_positions.Count; i >0; i++ )
		{
			AllObjects[i].SetActive(false);
		}
		Time.timeScale=0;
	}
	
	
	public void incPointsGC()
	{
		points++;
        points_txt.text = points.ToString();
		if (!init_first)
		{
			init_first = true;
			eatSomething=true;
		}
		else
			eatSomething=true;
	}
	
	public void incSmileyPointsGC()
	{
		points += 5;
        points_txt.text = points.ToString();
		if (!init_first)
		{
			init_first = true;
			eatSomething=true;
		}else
			eatSomething=true;
	}

	void AddBlock(Vector2 spawnedPosition)
	{
		int size = block_positions.Count;
		createdObject_GO=(GameObject)Instantiate(snakeBody,spawnedPosition,transform.rotation);
		createdObject_GO.SetActive (false);
		createdObject_GO.name = "block_"+size;
		AllObjects.Add(createdObject_GO);
	}

    public void OffMusic()
    {
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("soundOn", 0);
        BGMusic_AUD.Stop();
        MusicOffImage_GO.SetActive(true);
        MusicOnImage_GO.SetActive(false);
    }

    public void OnMusic()
    {
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("soundOn", 1);
        BGMusic_AUD.Play();
        MusicOffImage_GO.SetActive(false);
        MusicOnImage_GO.SetActive(true);
    }

    public void OnReplay()
    {
        BtnClick_AUD.Play();
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GOMenu()
    {
        BtnClick_AUD.Play();
        Time.timeScale = 1;
        //		showInterstitial();
        Application.LoadLevel("MainMenu");
    }
}
