using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeSpeed : MonoBehaviour {

	public GameObject savePanel_GO;
	public AudioSource BtnClick_AUD;

    // Use this for initialization
    void Start () {
        savePanel_GO.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AdjustSpeed(float newSpeed){
		newSpeed = gameObject.GetComponent<Slider>().value;
		MovementControl.speed = newSpeed;
	}

	public void BackMenu(){
        BtnClick_AUD.Play ();
		Application.LoadLevel("MainMenu");
	}

	public void SaveSetting(){
        BtnClick_AUD.Play ();
        savePanel_GO.SetActive(true);
		StartCoroutine(SaveDissapear());
	}

	IEnumerator SaveDissapear(){
		yield return new WaitForSeconds(1);
        savePanel_GO.SetActive(false);
	}
}
