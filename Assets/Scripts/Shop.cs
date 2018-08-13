using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour {
BuildManager buildManager;

	public TurretBlueprint standartTurret;
	public TurretBlueprint missileLauncer;
	public TurretBlueprint laserBeamer;

	public Text priceOfStTurret;
	public Text priceOfML;
	public Text priceOfLB;

void Start()
{
	buildManager = BuildManager.instance;
}
	// Use this for initialization
	public void SelecStTurret (){
		SoundManager.instance.PlayClickSFX();		
		buildManager.SelectTurretToBuild(standartTurret);

	}

	public void SelectMissileLauncer (){
		SoundManager.instance.PlayClickSFX();		
		buildManager.SelectTurretToBuild(missileLauncer);
	}

	public void SelectLaserBeamer (){
		SoundManager.instance.PlayClickSFX();		
		buildManager.SelectTurretToBuild(laserBeamer);
	}

	void Update(){
		priceOfStTurret.text = "$" + standartTurret.cost;
		priceOfML.text = "$" + missileLauncer.cost;
		priceOfLB.text = "$" + laserBeamer.cost;
	}
}


