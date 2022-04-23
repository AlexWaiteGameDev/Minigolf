using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeCounter : MonoBehaviour
{
    // For Mutliple UI Elements
    // public static Text[] texts; 
    public static Text StrokeText;
    private static int StrokeCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        StrokeText = GetComponent<Text>();
        
        ResetStrokeCount();

        // Multiple UI Element Solution
        // texts = ResetStrokeCount(); 
    }


    // Update is called once per frame
    void Update()
    {
        // Shoot Ball (Space)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            IncreaseStrokeCount();
        }
    }


    // Count++
    public static void IncreaseStrokeCount()
    {
        StrokeCount++;
        StrokeText.text = "Strokes: " + StrokeCount;
    }


    // Count--
    public static void DecreaseStrokeCount()
    {
        StrokeCount--;
        StrokeText.text = "Strokes: " + StrokeCount;
    }


    // Count Reset
    public static void ResetStrokeCount()
    {
        StrokeCount = 0;
        StrokeText.text = "Strokes: " + StrokeCount;
    }

}