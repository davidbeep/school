using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{

	public static GameController controller;
	private static bool[] unlockedLevels = new bool[100];
	private static int[] highScores = new int[100]; // saved by level
	public static int levelIndex; // current level

	void Awake ()
	{
	
		// singleton pattern
		if (controller == null) {
			DontDestroyOnLoad (gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy (gameObject);


		}
		//if save file doesnt exist yet, create it
		if (!System.IO.File.Exists (Application.persistentDataPath + "/saveData.dat")) {
			FileStream createFile = File.Create (Application.persistentDataPath + "/saveData.dat");
			createFile.Close ();
			GameController.controller.saveToFile ();

		} else {
			GameController.controller.loadFromFile ();
		}

		unlockLevel (0);
	}


	void OnApplicationQuit ()
	{
		saveToFile ();
	}

	// to be used on level completion
	public void unlockNextLevel ()
	{
		unlockLevel (levelIndex + 1);
	}

	public int getCurrentLevelIndex ()
	{

		return levelIndex; 
	}

	public static void unlockLevel (int index)
	{
		unlockedLevels [index] = true;
	}

	public void setHighScore (int levelIndex, int highScore)
	{
		highScores [levelIndex] = highScore;
	}

	public int getHighScore (int levelIndex)
	{
		if (highScores == null) {
			GameController.controller.loadFromFile ();
		} 
		return highScores [levelIndex];
	}
	public bool checkIfLevelIsUnlocked (int levelIndex)
	{
		if (unlockedLevels == null) {
			GameController.controller.loadFromFile ();
		} 
		return unlockedLevels [levelIndex];
	}


	public void saveToFile ()
	{

		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
		PlayerData data = new PlayerData ();
		data.unlockedLevels = unlockedLevels;
		data.highScores = highScores;
		formatter.Serialize (stream, data);
		stream.Close ();

	}

	public void loadFromFile ()
	{

		if (File.Exists (Application.persistentDataPath + "/saveData.dat")) {

			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
			PlayerData data = (PlayerData)formatter.Deserialize (stream);
			stream.Close ();

			if (highScores == null || unlockedLevels == null) {
				unlockedLevels = new bool[100];
				highScores = new int[100];
				unlockedLevels = data.unlockedLevels;
				highScores = data.highScores;
			} else {
				unlockedLevels = data.unlockedLevels;
				highScores = data.highScores;
			}
		}

	}

	public void resetScores ()
	{
		if (highScores != null) {
			Array.Clear (highScores, 0, highScores.Length);
		} else {
			highScores = new int[100];
		}
		// maybe save and load here
	}

}

[Serializable]
class PlayerData
{

	public bool[] unlockedLevels = new bool[100];
	public int[] highScores = new int[100]; // saved by level

}
