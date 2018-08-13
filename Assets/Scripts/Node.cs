using UnityEngine.EventSystems;
using UnityEngine;


public class Node : MonoBehaviour {
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffcet;
	public AudioSource nodeEvent;
	public AudioClip upgradeSFX;
	public AudioClip builsSFX;
	public AudioClip sellSFX;

	private Renderer rend;
	private Color startColor;


	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgrade = false;

	BuildManager buildManager;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition(){
		return transform.position + positionOffcet;
	}
	

	void BuildTurret(TurretBlueprint blueprint){
		if(PlayerStats.money < blueprint.cost)return;
		PlayerStats.money -= blueprint.cost;
		nodeEvent.clip = builsSFX;
		nodeEvent.Play();
		GameObject _turret = (GameObject) Instantiate(blueprint.prefabTurret, GetBuildPosition(), Quaternion.identity);
		turret = _turret;
		turretBlueprint = blueprint;
		GameObject effect = (GameObject) Instantiate(buildManager.buidEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		blueprint.cost +=blueprint.cost;
	}

	public void UpgradeTurret(){
		if(PlayerStats.money < turretBlueprint.upgradeCost)return;
		nodeEvent.clip = upgradeSFX;
		nodeEvent.Play();
		PlayerStats.money -= turretBlueprint.upgradeCost;
		Destroy(turret);
		GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefabTurret, GetBuildPosition(), Quaternion.identity);
		turret = _turret;
		GameObject effect = (GameObject) Instantiate(buildManager.buidEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		//turretBlueprint.upgradeCost += turretBlueprint.upgradeCost;
		isUpgrade = true;
	}

	public void SellTurret(){
		nodeEvent.clip = sellSFX;
		nodeEvent.Play();
		PlayerStats.money += turretBlueprint.GetAmountSell();
		GameObject effect = (GameObject) Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
		Destroy(turret);
		turretBlueprint = null;
	}

	void OnMouseDown()
	{
		if(EventSystem.current.IsPointerOverGameObject())return;	
		if(turret != null){
			buildManager.SelectNode(this);			
			return;
		}		
		if(!buildManager.CanBuild) return;
		BuildTurret(buildManager.GetTurretToBuild());
		buildManager.NullTurretToBuild();
		//Build Turret
	}

	void OnMouseEnter()
	{
		if(EventSystem.current.IsPointerOverGameObject())return;
		if(!buildManager.CanBuild) return;
		if(buildManager.HasMoney){
			rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}		
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
	
}
