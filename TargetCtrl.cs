using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//指定一个物体即中心物体，脚本挂载的对象会围绕着这个物体的中心点旋转
//玩家通过鼠标的移动来控制这个物体围绕着中心物体进行旋转，左右移动即横向旋转，上下移动即纵向旋转

public class TargetCtrl : MonoBehaviour
{
    // 旋转中心物体
    public Transform centerObject;
    // 旋转速度
    public float rotationSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (centerObject == null)
        {
            Debug.LogWarning("请指定一个中心物体!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (centerObject != null)
        {
            // 获取鼠标横向和纵向移动
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            
            // 根据鼠标横向移动控制横向旋转
            transform.RotateAround(centerObject.position, Vector3.up, mouseX * rotationSpeed);
            
            // 根据鼠标纵向移动控制纵向旋转
            transform.RotateAround(centerObject.position, transform.right, -mouseY * rotationSpeed);
        }
    }
}
