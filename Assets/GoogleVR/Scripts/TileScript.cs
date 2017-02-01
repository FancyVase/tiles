using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	public int col;
	private bool isOn;
	public AudioSource sound;
	private float TimeToFlash;
	private float TimeSinceStart;
	private MeshRenderer tile_renderer;
	

	// Use this for initialization
	void Awake () {
		isOn = false;
		TimeSinceStart = -col/5f;
		TimeToFlash = 0f;
//		StartCoroutine (PlayToneLoop ());
		tile_renderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		TimeSinceStart = TimeSinceStart + Time.deltaTime;
		if (TimeSinceStart > TimeToFlash) {
			TimeSinceStart = -3f;
			if (isOn) {
				tile_renderer.material.color = Color.cyan;
			} else {
				tile_renderer.material.color = new Color (0.180f, 0.180f, 0.180f);
			}
			Invoke ("resetColor", 1 / 5f);
		}
	}

	void resetColor () {
		if (tile_renderer != null) {
			if (isOn) {
				tile_renderer.material.color = Color.white;
			} else {
				tile_renderer.material.color = new Color (0.196f, 0.196f, 0.196f);
			}
		}
	}
	 
//	IEnumerator PlayToneLoop() {
//		yield return new WaitForSeconds(col/5f);
//		while (true) {
////			PlaySound ();
//			if (isOn) {
//				MeshRenderer my_renderer = GetComponent<MeshRenderer> ();
//				if (my_renderer != null) {
//					my_renderer.material.color = Color.cyan;
//				}
//				yield return new WaitForSeconds (1 / 5f);
//				if (my_renderer != null) {
//					my_renderer.material.color = Color.white;
//				}
//			} else {
//				yield return new WaitForSeconds (1/5f);
//			}
//
////			MeshRenderer my_renderer = GetComponent<MeshRenderer>();
////			if (my_renderer != null) {
////				my_renderer.material.color = Color.cyan;
////			}
////			yield return new WaitForSeconds (1/5f);
////			if (my_renderer != null) {
////				my_renderer.material.color = Color.white;
////			}
//			yield return new WaitForSeconds(3);
//		}
//	}
//	public void playSound(int tone) {
//		playSound (tone);
//	}

	public void onClick() {

		isOn = !isOn;
		resetColor ();

	}
}
