using UnityEngine;
using System.Collections;

public class MainMenuBtn : MonoBehaviour {

	public GameObject PanelGuide_GO;
	public AudioSource BtnClick_AUD;

	// Use this for initialization
	void Start () {
        PanelGuide_GO.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}

	public void StartGame(){
        BtnClick_AUD.Play();
        StartCoroutine(LoadToScene("GamePlay"));
		
	}

	public void QuitGame(){
        BtnClick_AUD.Play();
		Application.Quit();
	}

	public void GoSettings(){
        BtnClick_AUD.Play();
		//Application.LoadLevel("Setting");
        StartCoroutine(LoadToScene("Setting"));
    }

	public void OpenGuide(){
        BtnClick_AUD.Play();
        PanelGuide_GO.SetActive(true);
	}

	public void BackMenuGuide(){
        BtnClick_AUD.Play();
		//Application.LoadLevel("MainMenu");
        PanelGuide_GO.SetActive(false);
	}

    IEnumerator LoadToScene(string sceneName)
    {
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel(sceneName);
    }
}
