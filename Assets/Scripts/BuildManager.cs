
using UnityEngine;

public class BuildManager : MonoBehaviour {
	private TurretBlueprint turretToBuild;
	public NodeUI nodeUI;
	private Node selectedNode;
	public static BuildManager instance;
	public GameObject standartTurretPrefab;
	public GameObject missileLauncerPrefab;
	public GameObject buidEffect;
	public GameObject sellEffect;

	private static int countOfStTurrets = 0;
	private static int countOfMissileLaunchers = 0;
	
	void Awake()
	{
		instance = this;
	}

	public bool CanBuild { get {return turretToBuild != null;}}
	public bool HasMoney { get {return PlayerStats.money >= turretToBuild.cost;}}


	public void SelectNode (Node node){
		if(selectedNode == node){
			DeselectNode();
			return;
		}
		selectedNode = node;
		turretToBuild = null;
		nodeUI.SetTarget(node);
	}

	public void DeselectNode(){
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild(TurretBlueprint turret){
		turretToBuild = turret;	
		nodeUI.Hide();	
	}

	public TurretBlueprint GetTurretToBuild(){
		return turretToBuild;
	}

	public void NullTurretToBuild(){
		turretToBuild = null;
	}
}
