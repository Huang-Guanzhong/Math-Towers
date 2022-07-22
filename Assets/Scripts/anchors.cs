using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchors : MonoBehaviour
{
    public GameObject origin;
    public float gridWidth;
    public float gridHeight;
    public int rows;
    public float columns;
    public Sprite sprite;
    public Sprite sprite2;
    private Vector2[] vertices = new Vector2[20];

    // Start is called before the first frame update
    void Start()
    {
        createAnchorPts(origin.transform.position, rows, columns, gridWidth, gridHeight);

        // Loopiing through the vertices and add colliders
        for(int i = 0; i < 20; i++) {
            addCollider(vertices[i]);
        }
    }

    // createAnchorPts() modifies vertices to contain a multidimensional array of uniform points
    //      which gameobjects can later be appended to
    private void createAnchorPts(Vector2 position, int rows, float columns, float width, float height) {
        for(int curCol = 0; curCol < columns; curCol++) {
            for(int curRow = 0; curRow < rows; curRow++) {
                vertices[curRow + curCol * rows] = position;
                position.x += gridWidth;
            }
            position.x -= gridWidth * rows;
            position.y += gridHeight;
        }
    }

    private void addCollider(Vector2 point) {
        GameObject collider = new GameObject();

        collider.transform.position = point;
        collider.AddComponent<BoxCollider2D>();
        collider.AddComponent<SpriteRenderer>();
        collider.GetComponent<SpriteRenderer>().sprite = sprite;

        collider.AddComponent<Rigidbody2D>();
        collider.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
