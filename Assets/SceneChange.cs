using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour {


	bool fadeIn, kill, fadeOut;
	float fadeSpeed = 0.65f;
	Texture2D tex;
	float delayedTime = 0;
	public Scene scene;
	// Use this for initialization
	void Start () {
		fadeIn = true;
		fadeOut = kill = false;
		tex = Resources.Load ("Images/Black") as Texture2D;
		delayedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (kill) {
			delayedTime = Time.time;


			fadeOut = true;
			kill = false;
		}
	}

	void OnGUI() {
		if (fadeIn) {
			GUI.color = Color.Lerp (Color.black, Color.clear, fadeSpeed*(Time.time - delayedTime));
			if (GUI.color == Color.clear) {
				fadeIn = false;
				kill = true;
				Debug.Log ("Faded In");
			}
		} else if (fadeOut) {
			GUI.color = Color.Lerp (Color.clear, Color.black, fadeSpeed*(Time.time - delayedTime));
			//Debug.Log ("Color: " + GUI.color);
			if (GUI.color == Color.black) {
				Application.Quit ();
			}
		}
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tex);
	}
}
