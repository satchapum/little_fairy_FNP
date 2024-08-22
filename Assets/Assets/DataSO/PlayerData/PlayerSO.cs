using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObject", order = 1)]
public class PlayerSO : ScriptableObject
{
    [Header("PlayerData")]
    public int currentGameLevel = 1;
    public int currentStar = 0;
    public int currentPlayerMiniGame;
}
