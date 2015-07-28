using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class Options : MonoBehaviour
{

	//GameObject musicButton ;
	public Button musicButton ;
	public Button sfxButton ;
	public Sprite green, red ;
	public Button highScoreButton;
	private GameObject highScores;
	private bool highScoreToggle;

	// Use this for initialization
	void Start ()
	{
		if (MusicManager.instance.IsPlaying () == false) {
			musicButton.image.sprite = red;
		}
		if (MusicManager.instance.SoundEffectsOn () == false) {
			sfxButton.image.sprite = red;
		}

		highScoreToggle = false;
		highScores = GameObject.FindGameObjectWithTag ("highScores");
		highScores.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!highScoreToggle) {
			highScoreButton.image.sprite = green;
		} else {
			highScoreButton.image.sprite = red;
		}
	}

	public void toggleBGMusic ()
	{
		if (MusicManager.instance.IsPlaying ()) {
			MusicManager.instance.Pause ();
			// change button image color now to red (should be green to start)
			musicButton.image.sprite = red;

		} else {
			MusicManager.instance.UnPause ();
			// change button image color now to green
			musicButton.image.sprite = green;
		}

	}
	public void toggleSoundEffects ()
	{
		if (MusicManager.instance.SoundEffectsOn ()) {
			MusicManager.instance.DisableSoundEffects ();
			sfxButton.image.sprite = red;
		} else {
			MusicManager.instance.EnableSoundEffects ();
			sfxButton.image.sprite = green;
		}
	}

	public void toggleHighScores ()
	{
		highScoreToggle = !highScoreToggle;
		if (!highScores.activeSelf) {
			highScores.SetActive (true);

		} else {
			highScores.SetActive (false);
		}
	}
}
