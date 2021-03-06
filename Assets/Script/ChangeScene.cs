using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public void ChangeSceneToDesert(string sceneName)
	{
		SceneManager.LoadScene("SceneDesert");
	}

	public void ChangeSceneToMenu(string sceneName)
	{
		SceneManager.LoadScene("SceneMenu");
	}

	public void ChangeSceneToRegle(string sceneName)
	{
		SceneManager.LoadScene("SceneRegle");
	}

	public void ChangeSceneToControle(string sceneName)
	{
		SceneManager.LoadScene("SceneControle");
	}

	public void ChangeSceneToCredits(string sceneName)
	{
		SceneManager.LoadScene("SceneCredits");
	}


	public void ExitGame()
	{
		Debug.Log("Game is exiting");
		Application.Quit();
	}
}
