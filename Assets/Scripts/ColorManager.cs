using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    //Chaching an instance to the manager
    private static ColorManager s_Instance = null;
    public static ColorManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType<ColorManager>();
            }
            //If still null, create a new instance
            if (s_Instance == null)
            {
                GameObject obj = new GameObject("ColorManager");
                s_Instance = obj.AddComponent<ColorManager>();
                Debug.Log("Could not locate a ColorManager instance. A new one was generated automatically.");
            }
            return s_Instance;
        }
    }

    public Color RED;
    public Color ORANGE;
    public Color YELLOW;
    public Color GREEN;
    public Color BLUE;
    public Color PURPLE;
    public Color WHITE;

    public struct ColorKey
    {
        public ColorKey(Color color1, Color color2)
        {
            this.color1 = color1;
            this.color2 = color2;
        }
        Color color1;
        Color color2;
    }

    private Dictionary<ColorKey, Color> ColorCombinationDictionary;

    private void Start()
    {
        ColorCombinationDictionary = new Dictionary<ColorKey, Color>();
        ColorCombinationDictionary.Add(new ColorKey(RED, YELLOW), ORANGE);
        ColorCombinationDictionary.Add(new ColorKey(YELLOW, RED), ORANGE);
        ColorCombinationDictionary.Add(new ColorKey(BLUE, YELLOW), GREEN);
        ColorCombinationDictionary.Add(new ColorKey(YELLOW, BLUE), GREEN);
        ColorCombinationDictionary.Add(new ColorKey(RED, BLUE), PURPLE);
        ColorCombinationDictionary.Add(new ColorKey(BLUE, RED), PURPLE);
        ColorCombinationDictionary.Add(new ColorKey(WHITE, RED), RED);
        ColorCombinationDictionary.Add(new ColorKey(WHITE, BLUE), BLUE);
        ColorCombinationDictionary.Add(new ColorKey(WHITE, YELLOW), YELLOW);
        ColorCombinationDictionary.Add(new ColorKey(RED, WHITE), WHITE);
        ColorCombinationDictionary.Add(new ColorKey(BLUE, WHITE), WHITE);
        ColorCombinationDictionary.Add(new ColorKey(YELLOW, WHITE), WHITE);
    }

    public Color CombineColors(Color color1, Color color2)
    {
        Color color;
        if (ColorCombinationDictionary.TryGetValue(new ColorKey(color1, color2), out color))
            return color;
        return color2;
    }
}
