using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(string name){
        Application.LoadLevel(name);
	}

	public void QuitGame(){
        Application.Quit();
    }
}
