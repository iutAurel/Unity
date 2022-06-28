using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFin : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("SceneFin");
		Cursor.lockState = CursorLockMode.None;
	}
}

