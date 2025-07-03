using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[AddComponentMenu("UI/Effects/Gradient")]
public class UIGradient : BaseMeshEffect
{
    [SerializeField] private Color32 topColor = Color.white;
    [SerializeField] private Color32 bottomColor = Color.black;
    [SerializeField] private bool overrideAllColor = false;

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
            return;

        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        float bottomY = vertexList[0].position.y;
        float topY = bottomY;

        foreach (var v in vertexList)
        {
            float y = v.position.y;
            if (y > topY) topY = y;
            else if (y < bottomY) bottomY = y;
        }

        float uiElementHeight = topY - bottomY;
        if (Mathf.Approximately(uiElementHeight, 0f))
            return;

        for (int i = 0; i < vertexList.Count; i++)
        {
            var vertex = vertexList[i];
            float t = (vertex.position.y - bottomY) / uiElementHeight;
            var gradientColor = Color32.Lerp(bottomColor, topColor, t);

            vertex.color = overrideAllColor ? gradientColor : Color32.Lerp(vertex.color, gradientColor, 0.5f);
            vertexList[i] = vertex;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }
}
