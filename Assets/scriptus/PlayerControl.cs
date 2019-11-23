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
    public Board board;


    public Color[] sheetColors = {
        Color.blue, Color.red, Color.magenta, Color.yellow
    };
 
    void Start(){
        foreach (var p in players){
            p.data.heldBitcoins = 0;
            p.data.storedBitcoins = 0;
        }
    }

    void Awake(){
        UpdateSheetColor();
    }

    public void Execute(){
        StartCoroutine(ExecuteProply());
    }

    IEnumerator ExecuteProply(){
        executeButton.SetActive(false);

        var player = players[currentPlayer];

        yield return PlayerAction(player, direction1);
        yield return PlayerAction(player, direction2);
        yield return PlayerAction(player, direction3);

        NextPlayer();
        executeButton.SetActive(true);
    }
    IEnumerator PlayerAction(Player player, DirBtn direction){
        var lastPos = player.data.position;
        CallDirection(player, direction.GetDir());
        var cell = board.GetCell(player.data.position);
        if (player.data.position == Vector2Int.zero){
            if(player.data.heldBitcoins< 3)
                ++player.data.heldBitcoins;
            player.data.position = lastPos;
        }


        if (direction.direction != DirBtn.Direction.Nill){
            yield return new WaitForSeconds(moveDalay);
        }
        if (player.data.position == player.data.startPosition){
            player.data.storedBitcoins += player.data.heldBitcoins;
            player.data.heldBitcoins = 0;
        }
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

