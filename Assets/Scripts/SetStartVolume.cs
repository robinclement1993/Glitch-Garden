using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager){
			Debug.Log("Found music manager " +musicManager.name);
			musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
		} else {
			Debug.LogWarning("Did not find music manager so can't set volume");
		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
