using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera gameCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		defenderParent = GameObject.Find("Defenders");
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);		
		GameObject newDef = Button.selectedDefender;
		
		int defenderCost = newDef.GetComponent<Defender>().starCost;
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender(roundedPos, newDef);
		} else {
			Debug.Log("Insufficient stars to spawn");
		}
	}
	
	void SpawnDefender (Vector2 roundedPos, GameObject newDef){
		newDef = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}
	
	public Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPosition = gameCamera.ScreenToWorldPoint(weirdTriplet);
		
		Vector2 roundedWorldPosition = new Vector2(Mathf.Round(worldPosition.x), Mathf.Round(worldPosition.y));	
		
		return roundedWorldPosition;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPosition) {
		Vector2 roundedWorldPosition = new Vector2(Mathf.RoundToInt(rawWorldPosition.x), Mathf.RoundToInt(rawWorldPosition.y));
		return roundedWorldPosition;
	}
}
