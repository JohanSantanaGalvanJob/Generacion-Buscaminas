using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int x, y;
    public bool bomb;

    private void OnMouseDown() {
        if (bomb) {
            GetComponent<SpriteRenderer>().material.color = Color.green;
        } else {
            transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = Generator.gen.GetBombsAround(x, y).ToString();
        }
        
    }
}
