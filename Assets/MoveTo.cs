using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveTo : MonoBehaviour {

	public Transform goal;
	public Vector3 newDestination;
	public NavMeshAgent agent;
	GameObject farmer = GameObject.Find("Farmer walk");
	float timeThing = 0;
	float sceneTime = 0.0f;
	public static bool flag = true;
	Texture2D tex;
	public AudioClip m_LandSound;
	AudioSource m_AudioSource;

	void Start () {
		//m_LandSound
		m_AudioSource = GetComponent<AudioSource>();
		tex = Resources.Load ("Images/PressAnyKey") as Texture2D;
		agent = GetComponent<NavMeshAgent>();
		agent.speed = 0;
		agent.destination = farmer.transform.position; 
	}

	void Update () {
		if (Input.anyKey && flag) {
			agent.speed = 3.2f;
			flag = false;
			m_AudioSource.clip = m_LandSound;
			m_AudioSource.Play();
		}
		if (!flag) {
			if (Time.time > timeThing) {
				timeThing = Time.time + 10.0f;
				agent.speed += 0.1f;
			}
			newDestination = goal.transform.localPosition;
			agent.destination = newDestination;
		}
	}

	void OnGUI() {
		if (flag)
			GUI.DrawTexture (new Rect (Screen.width/2 - 141, Screen.height - 75, 283, 72), tex);
	}
	void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "FPSController") {
			SceneManager.LoadScene ("EndScene", LoadSceneMode.Single);
			sceneTime = Time.time;
		}
	}
}