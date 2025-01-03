using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light lightSource;
    public bool LightisOn = true;//是否开启光照
    public string Modifier;//自定义的光照模式
    public float LightIntensity = 1;//光照强度
    public int lightStyle = 0;
    private string[] lightPatterns = new string[]
    {
        "m", // Normal
        "mmnmmommommnonmmonqnmmo", // Flicker A
        "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba", // Slow, strong pulse
        "mmmmmaaaaammmmmaaaaaabcdefgabcdefg", // Candle A
        "mamamamamama", // Fast strobe
        "jklmnopqrstuvwxyzyxwvutsrqponmlkj", // Gentle pulse
        "nmonqnmomnmomomno", // Flicker B
        "mmmaaaabcdefgmmmmaaaammmaamm", // Candle B
        "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa", // Candle C
        "aaaaaaaazzzzzzzz", // Slow strobe
        "mmamammmmammamamaaamammma", // Fluorescent flicker
        "abcdefghijklmnopqrrqponmlkjihgfedcba" // Slow pulse, no black
    };
    private int patternIndex = 0;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightSource == null)
            return;

        // 光照开关
        lightSource.enabled = LightisOn;

        if (!LightisOn)
            return;

        // 使用自定义光照模式
        string pattern = string.IsNullOrEmpty(Modifier) ? lightPatterns[lightStyle] : Modifier;

        timer += Time.deltaTime;
        if (timer >= 0.1f) // 10 frames per second
        {
            timer = 0f;
            if (pattern.Length == 0)
                return;

            patternIndex = patternIndex % pattern.Length; // 确保 patternIndex 不会超出范围
            char currentChar = pattern[patternIndex];
            float intensity = (currentChar - 'a') / 25f; // 'a' is 0, 'm' is 1, 'z' is 2
            lightSource.intensity = intensity * LightIntensity; // 乘以光照强度

            patternIndex = (patternIndex + 1) % pattern.Length;
        }
    }

    public void SetLightStyle(int style)
    {
        if (style >= 0 && style < lightPatterns.Length)
        {
            lightStyle = style;
            patternIndex = 0; // 重置模式时重置索引
        }
    }

    public float GetLightIntensity()
    {
        return LightIntensity;
    }
}
