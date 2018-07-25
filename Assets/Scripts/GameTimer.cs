using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private AudioSource audioSource;
	private Slider slider;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	public float startTime = 10;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindWinLabel();
		winLabel.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / startTime;
		if(Time.timeSinceLevelLoad >= startTime && !isEndOfLevel) {
			winLabel.SetActive(true);
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
	
	void FindWinLabel () {
		winLabel = GameObject.Find("WinLabel");
		if(!winLabel) {
			Debug.LogWarning("Please create WinLabel object");
		}
	}
}
