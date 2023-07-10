using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �������� ������ ���� : 2
    public GameObject[] prefabs;

    // Ǯ ��� ����Ʈ : 2
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for (int index = 0; index< pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... prefab, enemy 0��°..
        // ������ Ǯ�� ��� �ִ�(��Ȱ��ȭ ��) ���� ������Ʈ ����
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            { // ... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... �� ã������?
            
        if (!select)
        {// ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select);
        }

        return select;
    }

}
