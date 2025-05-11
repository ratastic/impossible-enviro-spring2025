using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DynamicSortingLayer : MonoBehaviour
{
    private SpriteRenderer sr;

    public string[] sortingLayerNames;  // 6������������
    public float sortingLayerBaseValue = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float playerYPosition = transform.position.y;

        // ����sortingOrder������Yֵ���������������
        sr.sortingOrder = Mathf.RoundToInt(playerYPosition * sortingLayerBaseValue);

        // ����㼶��6���㼶��
        if (playerYPosition > 8f)
        {
            sr.sortingLayerName = sortingLayerNames[5];  // ��Զ�Ĳ�
        }
        else if (playerYPosition > 6f)
        {
            sr.sortingLayerName = sortingLayerNames[4];
        }
        else if (playerYPosition > 4f)
        {
            sr.sortingLayerName = sortingLayerNames[3];
        }
        else if (playerYPosition > 2f)
        {
            sr.sortingLayerName = sortingLayerNames[2];
        }
        else if (playerYPosition > 0f)
        {
            sr.sortingLayerName = sortingLayerNames[1];
        }
        else
        {
            sr.sortingLayerName = sortingLayerNames[0];  // ����Ĳ�
        }
    }
}
