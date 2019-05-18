using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerData data;
    public Grid grid;
    Renderer renderer;
    void Awake() {
        renderer = GetComponentInChildren<MeshRenderer>();
    }
    void Start() {
        renderer.material.color = GetColorFromType(data.cellType);
    }
    public static Color GetColorFromType(Board.Cell cellType){
        switch (cellType){
            case Board.Cell.PlayerBlue:
                return Color.blue;
            case Board.Cell.PlayerRed:
                return Color.red;
            case Board.Cell.PlayerPurple:
                return Color.magenta;
            case Board.Cell.PlayerYellow:
                return Color.yellow;
            default:
                throw new Exception("no color for " + cellType);
        }
    }
    void Update(){
        transform.localPosition = grid.GetCellCenterLocal((Vector3Int)data.position);
    }
}
