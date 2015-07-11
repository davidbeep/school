using UnityEngine;
using System.Collections;

public class UINavigation : MonoBehaviour, UI {

	// Use this for initialization
	void Start () {
	
	}

	public void changeToScene(string key)
	{
		Application.LoadLevel(key) ;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
