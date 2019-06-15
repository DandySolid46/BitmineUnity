using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
    public DirBtn direction1, direction2, direction3;
    public List<Player> players;
    public static int currentPlayer;

    public void Execute(){
        Debug.Log($"{direction1.GetDir()},{direction2.GetDir()},{direction3.GetDir()}");
    }
}

