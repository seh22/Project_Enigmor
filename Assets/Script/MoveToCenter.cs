using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    // ���� ��ġ�� ����
    private Vector3 originalPosition;

    // ��ǥ ��ġ�� ����
    private Vector3 targetPosition;

    // �̵��� Ȱ�� Ȯ��
    private bool moving = false;

    // �߾����� �̵� ����
    private bool movedToCenter = false;

    // �̵� �ӵ�
    public float speed = 5f;

    void Start()
    {
        // ù ��ġ ����
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!moving) 
            {
                moving = true; 
                // ���� �߾����� �̵��ߴٸ�, �ٽ� ���� ��ġ�� ����. �׷��� �ʴٸ� �߾����� ����
                targetPosition = 
                    movedToCenter ? originalPosition : 
                    Camera.main.ViewportToWorldPoint
                    (new Vector3(0.5f, 0.5f, transform.position.z - Camera.main.transform.position.z));
            }
        }

        // �̵� Ȱ��ȭ ��, ������Ʈ�� ��ǥ ��ġ�� �̵�
        if (moving)
        {
            float step = speed * Time.deltaTime; // �̵� �ӵ� ���
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // ��ǥ ��ġ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                moving = false; // �̵� ����
                movedToCenter = !movedToCenter; // �߾����� �̵��ߴ��� ���� ���
            }
        }
    }
}
