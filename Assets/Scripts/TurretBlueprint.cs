
using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint {
    public GameObject prefabTurret;
    public int cost;
    public GameObject upgradedPrefabTurret;
    public int upgradeCost;

    public int GetAmountSell(){
        return cost/2;
    } 
}
