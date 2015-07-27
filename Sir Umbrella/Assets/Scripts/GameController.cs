using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

	public static GameController controller;
	private static bool[] unlockedLevels = null;
	private static int[] highScores = null; // saved by level


	void Awake () {
	
		// singleton pattern
		if (controller == null) {
			DontDestroyOnLoad (gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(gameObject);


		}
	}
	

	void Update () {
	
	}

	public void unlockLevel ( int levelIndex){
		PlayerData.unlockedLevels [levelIndex] = true;
	}

	public void setHighScore ( int levelIndex, int highScore){
		PlayerData.highScores [levelIndex] = highScore;
	}

	public void safeToFile(){

		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);

		PlayerData data = new PlayerData ();
		formatter.Serialize (stream, data);
		stream.Close ();

	}

	public void loadFromFile(){

		if (File.Exists (Application.persistentDataPath + "/saveData.dat")) {

			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream stream = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
			PlayerData data = (PlayerData)formatter.Deserialize(stream);
			stream.Close();

			// fix error here
			//unlockedLevels = data.unlockedLevels;
		}

	}
}

[Serializable]
class PlayerData {

	public static bool[] unlockedLevels = new bool[100];
	public static int[] highScores = new int[100]; // saved by level

}
