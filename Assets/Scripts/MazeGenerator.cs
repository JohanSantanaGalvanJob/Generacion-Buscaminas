
using UnityEngine;

public class MazeGenerator : MonoBehaviour {
    public int width;
    public GameObject wall;
    public int height;
    private GameObject[][] maze;

    void Start() {
        GenerateMaze();
    }


    void GenerateMaze() {
        maze = new GameObject[width][];

        for (int i = 0; i < width; i++) {
            maze[i] = new GameObject[height];
        }

        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                maze[i][j] = Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                maze[i][j].GetComponent<Wall>().floor = false;
            }
        }

        GeneratePath(1, 1);
        PrintMaze();
    }


    void GeneratePath(int x, int y) {
        maze[x][y].GetComponent<Wall>().floor = true;

        // Direcciones posibles (arriba, derecha, abajo, izquierda)
        int[] directions = { 0, 1, 2, 3 };
        Shuffle(directions);

        // Explorar direcciones posibles
        for (int i = 0; i < directions.Length; i++) {
            int nextX = x + 2 * (directions[i] == 1 ? 1 : (directions[i] == 3 ? -1 : 0));
            int nextY = y + 2 * (directions[i] == 2 ? 1 : (directions[i] == 0 ? -1 : 0));

            // Verificar límites y si no ha sido visitada
            if (nextX > 0 && nextX < width - 1 &&
                nextY > 0 && nextY < height - 1 &&
                !maze[nextX][nextY].GetComponent<Wall>().floor) {

                // Romper el muro entre las posiciones
                maze[x + (nextX - x) / 2][y + (nextY - y) / 2]
                    .GetComponent<Wall>().floor = true;

                GeneratePath(nextX, nextY);
            }
        }

        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);
        Camera.main.orthographicSize = Mathf.Max(height / 2f, width / (2f * Camera.main.aspect)) + 1;
    }

    void Shuffle(int[] array) {
        for (int i = array.Length - 1; i > 0; i--) {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void PrintMaze() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                if (maze[i][j].GetComponent<Wall>().floor) {
                    maze[i][j].SetActive(false);
                }
            }
        }
    }
}
