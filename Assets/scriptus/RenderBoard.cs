using System.Collections;
using UnityEngine;

public class RenderBoard : MonoBehaviour {
	public GameObject Bitcoin;

	Grid grid;
	int x = -3;
	int y = -3;
	int xdir = 1;
	int ydir = 1;
	float time;
	
	void Awake() {
		grid = GetComponent<Grid>();
	}

	void Start() {
		time = Time.time;
	}

	void Update() {
		if (Time.time - time > 0.5f) {
			int r = Random.Range(0, 2);

			if (r == 1) {
				x += xdir;
				xdir = (x == 3) ? -1 : (x == -3) ? 1 : xdir;
			}
			else {
				y += ydir;
				ydir = (y == 3) ? -1 : (y == -3) ? 1 : ydir;
			}
			
			Bitcoin.transform.localPosition =
				grid.GetCellCenterLocal(new Vector3Int(x, y, 0));
			
			time = Time.time;
		}
	}
}