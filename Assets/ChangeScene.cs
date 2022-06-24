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
	public void Exit()
	{
		Application.Quit();
	}
}
