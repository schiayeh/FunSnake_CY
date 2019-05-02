using UnityEngine;
using System.Collections;

public class SetRatio : MonoBehaviour {

	private float widthHeightRatio;
	
	// Use this for initialization
	void Start () {
		
		widthHeightRatio = (float)Screen.height / Screen.width;
		//Debug.Log ("Screen ratio:" + widthHeightRatio);
		
		if ((widthHeightRatio > 0.7f) && (widthHeightRatio < 0.76f)) 
		{
			Camera.main.orthographicSize = 6.68f;
		}
		else if ((widthHeightRatio > 0.65f) && (widthHeightRatio < 0.7f)) 
		{
			Camera.main.orthographicSize = 5.92f;
		}
		else if ((widthHeightRatio > 0.6f) && (widthHeightRatio < 0.65f)) 
		{
			Camera.main.orthographicSize = 5.38f;
		}
		else if ((widthHeightRatio > 0.58f) && (widthHeightRatio < 0.6f)) 
		{
			Camera.main.orthographicSize = 5.3f;
		}
		
	}
}
