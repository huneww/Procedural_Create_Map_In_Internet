using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralCreateMap : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public float[,] map;
    public float noiseScale = 20.0f;
    public Button createBtn;

    Texture2D texture;
    GameObject mapObj;

    public void Start()
    {
        createBtn.onClick.AddListener(() => { CreateMap(); });
    }

    private void CreateMap()
    {
        texture = new Texture2D(width, height);
        map = new float[width, height];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                float xCode = (float)j / width * noiseScale;
                float yCode = (float)i / height * noiseScale;
                map[j, i] = Mathf.PerlinNoise(xCode, yCode);
                float colorvalue = map[j, i] <= 0.5f ? 0 : 1;
                Color color = new Color(colorvalue, colorvalue, colorvalue);
                texture.SetPixel(j, i, color);
            }
        }

        texture.Apply();

        if (mapObj != null)
        {
            Destroy(mapObj);
            mapObj = null;
        }

        mapObj = new GameObject("MapObj");
        SpriteRenderer renderer = mapObj.AddComponent<SpriteRenderer>();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector3(0.5f, 0.5f));
        renderer.sprite = sprite;
    }

}
