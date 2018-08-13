using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundsSurvived : MonoBehaviour {
	public Text roundsText;
	void OnEnable()
	{
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText(){

		roundsText.text = "0";
		int round = 0;
		yield return new WaitForSeconds(.7f);
		while (round < PlayerStats.rounds)
		{
			round++;
			roundsText.text = round.ToString();

			yield return new WaitForSeconds(.05f);
		}

	}
}
