using UnityEngine;

[CreateAssetMenu(fileName="playerData", menuName="Data/PlayerData")]
public class PlayerData : ScriptableObject {
    public string playerName;
    public Board.Cell cellType;
    public Vector2Int position;
    public int heldBitcons , storedBitcoins;
    // Player functions here later.
}