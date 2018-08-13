using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour {
	public SceneFader sceneFader;
	public Button[] levelButtons;
	
	public void Start()
	{
		int levelReached = PlayerPrefs.GetInt ("levelReached", 1);
		for (int i = 0; i < levelButtons.Length; i++)
		{
			if(i+1 > levelReached)
			levelButtons[i].interactable = false;
		}
	}
	
	
	public void SelecyLevel (string levelName){
		SoundManager.instance.PlayClickSFX();
		sceneFader.FadeTo(levelName);
	}
}
