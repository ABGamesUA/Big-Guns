using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
	public string nextLevel = "Level02";
	public int levelToUnlock = 2;
	public SceneFader sceneFader;
	public string menuSceneName = "MainMenu";

	public void Continue(){
		SoundManager.instance.PlayClickSFX();
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo(nextLevel);
	}

	public void Retry() {
		SoundManager.instance.PlayClickSFX();		
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu() {
		SoundManager.instance.PlayClickSFX();		
		sceneFader.FadeTo(menuSceneName);
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
	}
}

