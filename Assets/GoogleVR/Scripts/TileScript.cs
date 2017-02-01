using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	public int col;
	bool isOn;
	public AudioSource sound;

	// Use this for initialization
	void Start () {
		isOn = false;
		StartCoroutine (PlayToneLoop ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator PlayToneLoop() {
		yield return new WaitForSeconds(col/5f);
		while (true) {
//			PlaySound ();
			MeshRenderer my_renderer = GetComponent<MeshRenderer>();
			if (my_renderer != null) {
				my_renderer.material.color = Color.cyan;
			}
			yield return new WaitForSeconds (1/5f);
			if (my_renderer != null) {
				my_renderer.material.color = Color.white;
			}
			yield return new WaitForSeconds(3);
		}
	}
//	public void playSound(int tone) {
//		playSound (tone);
//	}

	public void onClick() {

		MeshRenderer my_renderer = GetComponent<MeshRenderer> ();
		if (my_renderer != null) {
			if (isOn) {
				my_renderer.material.color = new Color(0.196f,0.196f,0.196f);
			} else {
				my_renderer.material.color = Color.white;
			}
			isOn = !isOn;
		}
	}
}
