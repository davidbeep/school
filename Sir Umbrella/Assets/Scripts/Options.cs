using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class Options : MonoBehaviour 
{

	//GameObject musicButton ;
	public Button musicButton ;
	public Sprite green, red ;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void toggleBGMusic()
	{
		if ( MusicManager.instance.IsPlaying() ) 
		{
			MusicManager.instance.Pause ();
			// change button image color now to red (should be green to start)
			musicButton.image.sprite = red ;

		}
		else 
		{
			MusicManager.instance.UnPause() ;
			// change button image color now to green
			musicButton.image.sprite = green ;
		}

	}
	public void resumeBGMusic()
	{

	}
}
