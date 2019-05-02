using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject panelPause;
	public GameObject MusicOnImage;
	public GameObject MusicOffImage;

	public AudioSource BGMusic;
	public AudioSource BtnClick;

	bool togglesound = false;

	// Use this for initialization
	void Start () {

		BGMusic.Play ();
		panelPause.SetActive(false);


		if (PlayerPrefs.GetInt ("soundOn") == 0) {
			BGMusic.Stop ();
			MusicOffImage.SetActive(true);
			MusicOnImage.SetActive(false);
		}
		else{ 
			BGMusic.Play ();
			MusicOnImage.SetActive(true);
			MusicOffImage.SetActive(false);
		}
		MusicOnImage.SetActive(true);
		Debug.Log (PlayerPrefs.GetInt("soundOn"));
	}
	
	// Update is called once per frame
	void Update () {


	}
	public void OffMusic(){
		AudioListener.volume = 0;
		PlayerPrefs.SetInt("soundOn",0);

		BGMusic.Stop ();
		//allC.GetComponent<AudioListener>().enabled = false;
		MusicOffImage.SetActive(true);
		MusicOnImage.SetActive(false);
//		PlayerPrefs.Save();

	}

	public void OnMusic(){

		AudioListener.volume = 1;
		PlayerPrefs.SetInt("soundOn",1);

		//allC.GetComponent<AudioListener>().enabled = true;
		BGMusic.Play ();
		MusicOffImage.SetActive(false);
		MusicOnImage.SetActive(true);
//		PlayerPrefs.Save();

	}

	public void OnPause(){
		BtnClick.Play();
		Time.timeScale=0;
		panelPause.SetActive(true);
		BGMusic.Stop ();
	}

	public void OnResume(){
		Time.timeScale = 1;
		panelPause.SetActive(false);
		BGMusic.Play ();
	}

	public void OnReplay(){
		BtnClick.Play();
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
		panelPause.SetActive(false);
	}

	public void GOMenu(){
		BtnClick.Play();
		Time.timeScale = 1;
//		showInterstitial();
		Application.LoadLevel("MainMenu");
	}

	public void GOReplay(){
		BtnClick.Play();
		Time.timeScale = 1;
		Application.LoadLevel("GamePlay");
	}
}
