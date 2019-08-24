using UnityEngine;
using UnityEngine.UI;

public class DirBtn : MonoBehaviour {
    public enum Direction {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
        Nill = 4,
    }

    static readonly float[] DirectionAngles = new float[]{
        0, 270, 180, 90
    };

    public Direction direction = Direction.Up;
    Graphic graphic;

    void Awake (){
        graphic = GetComponent<Graphic>();
    }

    void Start(){
        ApplyDirection();
    }

    public void OnClick(){
        int dir = (int)direction;
        dir = (dir + 1) % 5;
        direction = (Direction)dir;
        ApplyDirection();
    }
    void ApplyDirection() {
        if (direction == Direction.Nill) {
            graphic.color = Color.clear;
        } else {
            graphic.color = Color.white;
            var rot = transform.localRotation.eulerAngles;
            rot.z = DirectionAngles[(int)direction];
            transform.localRotation = Quaternion.Euler(rot);
        }
    }
    public Direction GetDir() => direction;
    public void SetDir(Direction dir){
        direction = dir;
        ApplyDirection();
    }
}