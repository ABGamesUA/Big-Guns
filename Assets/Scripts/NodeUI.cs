using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
	 private Node target;
	 public GameObject ui;
	 public Text upgradeTextCost;
	 public Text sellText;
	 public Button upgradeButton;
	 

	 public void SetTarget (Node _target){
		 target = _target;
		 transform.position = target.GetBuildPosition();
		 if(!target.isUpgrade){
			 upgradeTextCost.text = "$" + target.turretBlueprint.upgradeCost;
			 upgradeButton.interactable = true;
		 } else {
			 upgradeTextCost.text = "MAX";
			 upgradeButton.interactable = false;
		 }		
		 sellText.text = "$"+target.turretBlueprint.GetAmountSell();
		 ui.SetActive(true);
	 }
	
	public void Hide(){
		ui.SetActive(false);
	}

	public void Upgrade(){
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}
	public void Sell(){
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}
}
