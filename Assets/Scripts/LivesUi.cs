using UnityEngine;
using UnityEngine.UI;

public class LivesUi : MonoBehaviour {
	public Text livesText;
	
	// Update is called once per frame
	void Update () {
		if(PlayerStats.lives == 1){
			livesText.text = PlayerStats.lives + " LIVE LEFT";
		} else if(PlayerStats.lives < 0) {
			livesText.text = "0 LIVES LEFT";
		}else {
			livesText.text = PlayerStats.lives + " LIVES LEFT";
		}
	}
}
