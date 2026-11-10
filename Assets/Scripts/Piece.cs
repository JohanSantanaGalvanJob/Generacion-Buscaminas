using UnityEngine;

public class Piece : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int x, y;
    public bool bomb;

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().material.color = Color.green;
    }
}
