using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour 
{
	GameObject musicButton ;
	// Use this for initialization
	void Start () 
	{
		musicButton = GameObject.FindGameObjectWithTag ("musicButton");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void pauseBGMusic()
	{
		if ( MusicManager.instance.IsPlaying() ) 
		{
			MusicManager.instance.Pause ();
			// change button image color now to red (should be green to start)
		}
		else 
		{
			MusicManager.instance.UnPause() ;
			// change button image color now to green 
		}

	}
	public void resumeBGMusic()
	{

	}
}
