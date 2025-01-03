using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightController 类用于控制光源的各种照明模式和强度。
/// </summary>
public class LightController : MonoBehaviour
{
    // 公共变量
    public Light lightSource; // 光源对象
    public bool LightisOn = true; // 是否开启光照
    public string Modifier; // 自定义的光照模式
    public float LightIntensity = 1; // 光照强度
    public int lightStyle = 0; // 光照模式索引

    // 私有变量
    private string[] lightPatterns = new string[] // 预定义的光照模式数组
    {
        "m", // 正常
        "mmnmmommommnonmmonqnmmo", // 闪烁 A
        "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba", // 缓慢的强脉冲
        "mmmmmaaaaammmmmaaaaaabcdefgabcdefg", // 蜡烛 A
        "mamamamamama", // 快速频闪
        "jklmnopqrstuvwxyzyxwvutsrqponmlkj", // 柔和的脉冲
        "nmonqnmomnmomomno", // 闪烁 B
        "mmmaaaabcdefgmmmmaaaammmaamm", // 蜡烛 B
        "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa", // 蜡烛 C
        "aaaaaaaazzzzzzzz", // 缓慢的频闪
        "mmamammmmammamamaaamammma", // 荧光灯闪烁
        "abcdefghijklmnopqrrqponmlkjihgfedcba" // 缓慢的脉冲，无黑色
    };
    private int patternIndex = 0; // 当前模式的索引
    private float timer = 0f; // 计时器

    // Start 是在脚本启用时调用的
    void Start()
    {
        
    }

    // Update 是在每帧调用的
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
        if (timer >= 0.1f) // 每秒10帧
        {
            timer = 0f;
            if (pattern.Length == 0)
                return;

            patternIndex = patternIndex % pattern.Length; // 确保 patternIndex 不会超出范围
            char currentChar = pattern[patternIndex];
            float intensity = (currentChar - 'a') / 25f; // 'a' 是 0，'m' 是 1，'z' 是 2
            lightSource.intensity = intensity * LightIntensity; // 乘以光照强度

            patternIndex = (patternIndex + 1) % pattern.Length;
        }
    }

    /// <summary>
    /// 设置光照模式
    /// </summary>
    /// <param name="style">光照模式索引</param>
    public void SetLightStyle(int style)
    {
        if (style >= 0 && style < lightPatterns.Length)
        {
            lightStyle = style;
            patternIndex = 0; // 重置模式时重置索引
        }
    }

    /// <summary>
    /// 获取当前光照强度
    /// </summary>
    /// <returns>光照强度</returns>
    public float GetLightIntensity()
    {
        return LightIntensity;
    }
}