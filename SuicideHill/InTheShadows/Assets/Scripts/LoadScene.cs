using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


	public void SelectLevel(int Level_Select){
		SceneManager.LoadScene(Level_Select);
	}
}
