using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class PlayerControl : MonoBehaviour {
    public DirBtn direction1, direction2, direction3;
    public List<Player> players;
    public static int currentPlayer = 0;
    public Graphic sheetGrafic;

    public Color[] sheetColors = {
        Color.blue, Color.red, Color.magenta, Color.yellow
    };

    void Awake(){
        UpdateSheetColor();
    }

    public void Execute(){
        var player = players[currentPlayer];
        CallDirection(player, direction1.GetDir());
        CallDirection(player, direction2.GetDir());
        CallDirection(player, direction3.GetDir());

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

