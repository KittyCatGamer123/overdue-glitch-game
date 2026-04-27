using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineGraphRenderer : Graphic
{
    public Vector2Int gridSize;
    public List<Vector2> points;
    public float thickness;

    private float width;
    private float height;
    private float unitWidth;
    private float unitHeight;
    
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;
        unitWidth = width / (float)gridSize.x;
        unitHeight = height / (float)gridSize.y;

        if (points.Count < 2) return;

        foreach (var pt in points)
        {
            DrawVerticesForPoint(pt, vh);
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            int idx = i * 2;
            vh.AddTriangle(idx + 0, idx + 1, idx + 3);
            vh.AddTriangle(idx + 3, idx + 2, idx + 0);
        }
    }

    void DrawVerticesForPoint(Vector2 pt, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(-thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * pt.x, unitHeight * pt.y);
        vh.AddVert(vertex);
        
        vertex.position = new Vector3(thickness / 2, 0);
        vertex.position += new Vector3(unitWidth * pt.x, unitHeight * pt.y);
        vh.AddVert(vertex);
    }
}
