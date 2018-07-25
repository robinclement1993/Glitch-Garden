using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text amountStarsDisplay;
	private int amountStars = 150;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		amountStarsDisplay = GetComponent<Text>();
		UpdateDisplay();
	}
	
	
	public void AddStars(int amount) {
		amountStars += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		if(amountStars >= amount){
			amountStars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay () {
		amountStarsDisplay.text = amountStars.ToString();
	}
}
