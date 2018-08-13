using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;
	public void Play(){		
		SoundManager.instance.PlayClickSFX();
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit(){
		SoundManager.instance.PlayClickSFX();
		Application.Quit();
	}
	
}
