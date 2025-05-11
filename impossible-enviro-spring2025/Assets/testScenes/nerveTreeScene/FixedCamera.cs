using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    // 设置摄像机的固定位置
    public Vector3 fixedPosition;

    void Start()
    {
        // 在启动时将摄像机固定在特定位置
        transform.position = fixedPosition;
    }

    void Update()
    {
        // 摄像机保持固定位置，不随物体移动
        transform.position = fixedPosition;
    }
}
