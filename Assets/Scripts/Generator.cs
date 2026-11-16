using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator gen;
    public GameObject piece;
    public int width, height;
        
    public int bombsNumber;
    public GameObject[][] map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gen = this;
        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++) {
            map[i] = new GameObject[height];
        }
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = j;
            }
        }

        //for (int i = 0; i < bombsNumber; i++) {
        //    map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        //}
        Camera.main.transform.position = new Vector3(((float)width / 2) -  0.5f, ((float)height / 2) - 0.5f, -10);

        SetBombs();
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

    public int GetBombsAround(int x, int y) {
        int cont = 0;

        //arriba izquierda
        if(x>0 && y < height - 1 && map[x-1][y+1].GetComponent<Piece>().bomb) {
            cont++;
        }

        //arriba
        if (y < height - 1 && map[x][y +1].GetComponent<Piece>().bomb) {
            cont++;
        }

        //arriba derecha
        if (x < width - 1 && y < height - 1 && map[x+1][y + 1].GetComponent<Piece>().bomb) {
            cont++;
        }

        //izquierda
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb) {
            cont++;
        }
        //derecha
        if (x < width - 1 && map[x+1][y].GetComponent<Piece>().bomb) {
            cont++;
        }

        //abajo izquierda
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb) {
            cont++;
        }

        //abajo
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().bomb) {
            cont++;
        }

        //abajo derecha
        if (x < width - 1 && y > 0 && map[x+1][y - 1].GetComponent<Piece>().bomb) {
            cont++;
        }
        return cont;
    }
}
