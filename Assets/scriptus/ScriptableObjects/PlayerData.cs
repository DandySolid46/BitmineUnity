using UnityEngine;

[CreateAssetMenu(fileName="playerData", menuName="Data/PlayerData")]
public class PlayerData : ScriptableObject {
    public string playerName;
    public Board.Cell cellType;
    public Vector2Int startPosition, position;
    public int heldBitcons , storedBitcoins;
    
}