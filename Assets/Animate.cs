using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {
	public Animator anim;
	bool start = true;
	float startTime = 0.0f;
	float scenetime = 5.0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time > (startTime + scenetime))&&start) {
			anim.Play ("Armature|Murder", -1, 0f);
			start = false;
		}
	}
}
