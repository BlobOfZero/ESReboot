using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerDataScriptableObject")]

public class PlayerData : ScriptableObject
{
    public int playerCoins;

    public int playerAttackWeaponID;

    public int playerWeaponID;
}
