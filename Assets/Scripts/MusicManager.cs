using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	private string previousSong;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);	
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = levelMusicChangeArray[0];
		audioSource.Play();
		previousSong = levelMusicChangeArray[0].name;
		Debug.Log("playing " + levelMusicChangeArray[0].name);
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic) {
			if(thisLevelMusic.name == previousSong){
				Debug.Log("Already playing this song!");
			}
			else {
				audioSource.clip = thisLevelMusic;
				Debug.Log("playing " + thisLevelMusic.name);
				previousSong = thisLevelMusic.name;
				audioSource.loop = true;
				audioSource.Play();
			}
		}
	}
	
	public void ChangeVolume (float volume){
		audioSource.volume = volume;
	}
}
