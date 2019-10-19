using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class PlayerControl : MonoBehaviour {
    public DirBtn direction1, direction2, direction3;
    public List<Player> players;
    public static int currentPlayer = 0;
    public Graphic sheetGrafic;
    public float moveDalay = 0.5f;
    public GameObject executeButton;


    public Color[] sheetColors = {
        Color.blue, Color.red, Color.magenta, Color.yellow
    };
 
    void Awake(){
        UpdateSheetColor();
    }

    public void Execute(){
        StartCoroutine(ExecuteProply());
    }

    IEnumerator ExecuteProply(){
        executeButton.SetActive(false);

        var player = players[currentPlayer];

        CallDirection(player, direction1.GetDir());
        if (direction1.direction != DirBtn.Direction.Nill){
            yield return new WaitForSeconds(moveDalay);
        }
        CallDirection(player, direction2.GetDir());

        if (direction2.direction != DirBtn.Direction.Nill &&
            direction2.direction != direction1.direction) {
            yield return new WaitForSeconds(moveDalay);
        }
        CallDirection(player, direction3.GetDir());
        if (direction3.direction != DirBtn.Direction.Nill &&
            direction3.direction != direction2.direction) {
            yield return new WaitForSeconds(moveDalay);
        }

        ++player.data.storedBitcoins;

        NextPlayer();
        executeButton.SetActive(true);
    }
    void NextPlayer(){
        currentPlayer = (currentPlayer + 1) % 4;
        UpdateSheetColor();
    }

    void CallDirection(Player player, DirBtn.Direction dir) {
        switch (dir) {
            case DirBtn.Direction.Up:
                player.Up();
                break;
            case DirBtn.Direction.Down:
                player.Down();
                break;
            case DirBtn.Direction.Left:
                player.Left();
                break;
            case DirBtn.Direction.Right:
                player.Right();
                break;

        }
    }
    void UpdateSheetColor()
        => sheetGrafic.color = sheetColors[currentPlayer];
}

