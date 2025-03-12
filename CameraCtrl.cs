using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个脚本结合TargetCtrl脚本，实现了一个相机围绕着一个中心物体旋转的效果
//CameraCtrl脚本挂载在相机上，TargetCtrl脚本挂载在一个空物体上，相机会挂载一个旋转中心，然后相机始终面朝TargetCtrl物体

public class CameraCtrl : MonoBehaviour
{
    // 旋转中心物体
    public Transform rotationCenter;
    
    // 目标物体（挂载TargetCtrl脚本的物体）
    public Transform targetObject;
    
    // 相机距离中心点的距离
    public float distance = 10f;
    
    // 相机旋转的速度
    public float rotationSpeed = 5f;
    
    // 相机高度偏移
    public float heightOffset = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (rotationCenter == null)
        {
            Debug.LogWarning("请指定一个旋转中心物体!");
        }
        
        if (targetObject == null)
        {
            Debug.LogWarning("请指定一个目标物体（挂载TargetCtrl脚本的物体）!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationCenter != null && targetObject != null)
        {
            // 计算从中心物体到目标物体的方向向量
            Vector3 directionToTarget = (targetObject.position - rotationCenter.position).normalized;
            
            // 将相机放置在中心物体的另一侧，以确保三点共线
            transform.position = rotationCenter.position - directionToTarget * distance;
            
            // 使相机始终面向目标物体
            transform.LookAt(targetObject);
        }
    }
}
