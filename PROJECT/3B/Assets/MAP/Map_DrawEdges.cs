using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_DrawEdges : MonoBehaviour
{

    public int NumEdges;
    public float Radius;

    private float RadiusConversion = 0.1215933333f;

    // Use this for initialization
    void Awake()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty");
        if (Mathf.Sqrt(difficulty) * 75 > 300)
        {
            Radius = 300;
        }
        else
        {
            Radius = Mathf.Sqrt(difficulty) * 75;
        }

        GameObject boundarySprite = GetComponentInChildren<SpriteRenderer>().gameObject;
        float converted = Radius * RadiusConversion;
        boundarySprite.transform.localScale = new Vector3(converted, converted, transform.localScale.z);


        
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[NumEdges + 1];

        for (int i = 0; i < NumEdges; i++)
        {
            float angle = 2 * Mathf.PI * i / NumEdges;
            float x = Radius * Mathf.Cos(angle);
            float y = Radius * Mathf.Sin(angle);

            points[i] = new Vector2(x, y);
        }
        points[NumEdges] = points[0];
         
         edgeCollider.points = points;
     }
}

