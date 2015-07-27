using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

	public static GameController controller;
	private bool[] unlockedLevels;
	private int[] highScores; // saved by level
	public static int levelIndex;

	void Awake () {
	
		// singleton pattern
		if (controller == null) {
			DontDestroyOnLoad (gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(gameObject);


		}
		//if save file doesnt exist yet, create it
		if (!System.IO.File.Exists (Application.persistentDataPath + "/saveData.dat")) {
			FileStream createFile = File.Create (Application.persistentDataPath + "/saveData.dat");
			createFile.Close ();
			GameController.controller.resetScores ();// initializes everything to 0
			GameController.controller.saveToFile ();

		} else {
			GameController.controller.loadFromFile();
		}
	}
	

	void OnApplicationQuit() {
		saveToFile ();
	}

	public int getCurrentLevelIndex (){

		return levelIndex; 
	}

	public void unlockLevel ( int levelIndex){
		unlockedLevels [levelIndex] = true;
	}

	public void setHighScore ( int levelIndex, int highScore){
		highScores [levelIndex] = highScore;
	}

	public int getHighScore (int levelIndex){
		if (GameController.controller.highScores == null) {
			GameController.controller.loadFromFile ();
		} // do the same for levels
				return GameController.controller.highScores [levelIndex];
	}
	public bool checkIfLevelIsUnlocked (int levelIndex){
		return GameController.controller.unlockedLevels [levelIndex];
	}


	public void saveToFile(){

		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
		PlayerData data = new PlayerData ();
		data.unlockedLevels = unlockedLevels;
		data.highScores = highScores;
		formatter.Serialize (stream, data);
		stream.Close ();

	}

	public void loadFromFile(){

		if (File.Exists (Application.persistentDataPath + "/saveData.dat")) {

			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
			PlayerData data = (PlayerData)formatter.Deserialize(stream);
			stream.Close();

			if (GameController.controller.highScores == null || GameController.controller.unlockedLevels == null ){
				GameController.controller.unlockedLevels = new bool[100];
				GameController.controller.highScores = new int[100];
				unlockedLevels = data.unlockedLevels;
				highScores = data.highScores;
			}
			else {
				unlockedLevels = data.unlockedLevels;
				highScores = data.highScores;
			}
		}

	}

	public void resetScores(){
		if (GameController.controller.highScores != null) {
			Array.Clear (GameController.controller.highScores, 0, GameController.controller.highScores.Length);
		} else {
			GameController.controller.highScores = new int[100];
		}
		// maybe save and load here
	}

}

[Serializable]
class PlayerData {

	public bool[] unlockedLevels = new bool[100];
	public int[] highScores = new int[100]; // saved by level

}
