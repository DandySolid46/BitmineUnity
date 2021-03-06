using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerData data;
    public Grid grid;
    Renderer renderer;
    void Awake() {
        renderer = GetComponentInChildren<MeshRenderer>();
        data.position = data.startPosition;
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
    void FixedUpdate(){
        var newPos = grid.GetCellCenterLocal((Vector3Int)data.position);
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            newPos,
            0.1f
        );
        //transform.localPosition = grid.GetCellCenterLocal((Vector3Int)data.position);
    }
    
    public void Up()
        => data.position.y = Mathf.Clamp(data.position.y +1, -3,3);
    public void Down()
        => data.position.y = Mathf.Clamp(data.position.y -1, -3,3);
    public void Left()
        => data.position.x = Mathf.Clamp(data.position.x -1, -3,3);
    public void Right()
        => data.position.x = Mathf.Clamp(data.position.x +1, -3,3);

}
