using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour{
    public PlayerData playerData;
    public Text heldScore, storedScore;

    void FixedUpdate() {
        heldScore.text = playerData.heldBitcoins.ToString();
        storedScore.text = playerData.storedBitcoins.ToString();
    }
}