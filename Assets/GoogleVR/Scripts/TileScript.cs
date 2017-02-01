using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	
	public int col;
	private bool isOn;
	private float TimeToFlash;
	private float TimeSinceStart;
	private MeshRenderer tile_renderer;
	private AudioSource source;
	

	// Use this for initialization
	void Awake () {
		isOn = false;
		TimeSinceStart = -col/5f;
		TimeToFlash = 0f;
		tile_renderer = GetComponent<MeshRenderer> ();
		source = GetComponent<AudioSource> ();
		AudioSource[] sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[];
		Debug.Log (sources);
	}
	
	// Update is called once per frame
	void Update () {
		TimeSinceStart = TimeSinceStart + Time.deltaTime;
		if (TimeSinceStart > TimeToFlash) {
			TimeSinceStart = -3f;
			if (isOn) {
//				source.Play ();
				AudioSource.PlayClipAtPoint (source.clip, transform.position);
				// active on
//				tile_renderer.material.color = Color.cyan;
				tile_renderer.material.color = new Color (0.361f, 1f, 1f, 1f);
			} else {
//				tile_renderer.material.color = new Color (0.180f, 0.180f, 0.180f);
				// active off
				tile_renderer.material.color = new Color (0.824f, 0.867f, 1f, 1f);
			}
			Invoke ("resetColor", 1 / 5f);
		}
	}

	void resetColor () {
		if (tile_renderer != null) {
			if (isOn) {
				// inactive on
//				tile_renderer.material.color = Color.white;
				tile_renderer.material.color = new Color (0.620f, 1f, 0.984f, 0.616f);
			} else {
//				tile_renderer.material.color = new Color (0.196f, 0.196f, 0.196f);
				// inactive off
				tile_renderer.material.color = new Color (0.824f, 0.867f, 1f, 0.616f);
			}
		}
	}

	public void onClick() {

		isOn = !isOn;
		resetColor ();

	}
}
