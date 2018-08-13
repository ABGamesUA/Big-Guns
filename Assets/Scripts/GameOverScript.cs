using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "MainMenu";

	

	public void Retry() {
		SoundManager.instance.PlayClickSFX();		
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu() {
		SoundManager.instance.PlayClickSFX();		
		sceneFader.FadeTo(menuSceneName);
	}
}
