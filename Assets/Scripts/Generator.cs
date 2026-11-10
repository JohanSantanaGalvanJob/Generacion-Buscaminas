using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject piece;
    public int width, height, bombsNumber;
    public GameObject[][] map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++) {
            map[i] = new GameObject[height];
        }
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
            }
        }
        Camera.main.transform.position = new Vector3(((float)width / 2) -  0.5f, ((float)height / 2) - 0.5f, -10);

        
    }

    public void SetBombs() {
        for (int i = 0; i < bombsNumber; i++) {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<Piece>().bomb) {
                map[x][y].GetComponent<Piece>().bomb = true;
            } else {
                i--;
            }
            //map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red; 
        }
    }
}
