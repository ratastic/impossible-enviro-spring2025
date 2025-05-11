using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // 控制浮动的幅度
    public float floatHeight = 1.0f;
    // 控制浮动速度
    public float floatSpeed = 1.0f;

    private Vector3 startPos;

    void Start()
    {
        // 记录物体初始位置
        startPos = transform.position;
    }

    void Update()
    {
        // 使用 Mathf.PingPong 来实现上下浮动效果
        float newY = startPos.y + Mathf.PingPong(Time.time * floatSpeed, floatHeight);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
