using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	private SpriteRenderer sprite;
	private Button[] buttonArray;
	private Text costText;
	
	
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();	
		buttonArray = GameObject.FindObjectsOfType<Button>();
		
		costText = GetComponentInChildren<Text>();
		if(costText) {
			costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
		} else {
			Debug.LogWarning("No cost text object found for " + name);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		sprite.color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
