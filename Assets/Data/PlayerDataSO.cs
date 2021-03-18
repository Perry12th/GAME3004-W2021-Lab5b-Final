using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    // player transform properties
    [Header("Player Transform Properties")]
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    [Header("PlayerAttributes")]
    // player attributes
    public int playerHealth;
}
