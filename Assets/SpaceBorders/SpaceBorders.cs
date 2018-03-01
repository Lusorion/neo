using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBorders : MonoBehaviour
{

    //--By Matej Vanco 2018

    public float Grid_Size = 1f;

    public int minX = -15;
    public int minY = -15;
    public int maxX = 15;
    public int maxY = 15;

    public Vector3 Grid_Offset = Vector3.zero;

    public bool Grid_TopDown = true;

    private int GizmoLinesMajorities = 1;
    public Color Grid_Color = Color.red;

    void Reset()
    {
        transform.position = Vector3.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;

        Color dimColor = new Color(Grid_Color.r, Grid_Color.g, Grid_Color.b, 0.25f * Grid_Color.a);
        Color brightColor = Color.Lerp(Color.white, Grid_Color, 0.75f);

        for (int x = minX; x < maxX + 1; x++)
        {
            Gizmos.color = (x % GizmoLinesMajorities == 0 ? Grid_Color : dimColor);
            if (x == 0)
                Gizmos.color = brightColor;

            Vector3 pos1 = new Vector3(x, minY, 0) * Grid_Size;
            Vector3 pos2 = new Vector3(x, maxY, 0) * Grid_Size;

            if (Grid_TopDown)
            {
                pos1 = new Vector3(pos1.x, 0, pos1.y);
                pos2 = new Vector3(pos2.x, 0, pos2.y);
            }
            Gizmos.DrawLine((Grid_Offset + pos1), (Grid_Offset + pos2));
        }

        for (int y = minY; y < maxY + 1; y++)
        {
            Gizmos.color = (y % GizmoLinesMajorities == 0 ? Grid_Color : dimColor);
            if (y == 0)
                Gizmos.color = brightColor;

            Vector3 pos1 = new Vector3(minX, y, 0) * Grid_Size;
            Vector3 pos2 = new Vector3(maxX, y, 0) * Grid_Size;

            if (Grid_TopDown)
            {
                pos1 = new Vector3(pos1.x, 0, pos1.y);
                pos2 = new Vector3(pos2.x, 0, pos2.y);
            }

            Gizmos.DrawLine((Grid_Offset + pos1), (Grid_Offset + pos2));
        }
    }
}
