using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    // 원래 위치를 저장
    private Vector3 originalPosition;

    // 목표 위치를 저장
    private Vector3 targetPosition;

    // 이동이 활성 확인
    private bool moving = false;

    // 중앙으로 이동 여부
    private bool movedToCenter = false;

    // 이동 속도
    public float speed = 5f;

    void Start()
    {
        // 첫 위치 저장
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!moving) 
            {
                moving = true; 
                // 현재 중앙으로 이동했다면, 다시 원래 위치로 설정. 그렇지 않다면 중앙으로 설정
                targetPosition = 
                    movedToCenter ? originalPosition : 
                    Camera.main.ViewportToWorldPoint
                    (new Vector3(0.5f, 0.5f, transform.position.z - Camera.main.transform.position.z));
            }
        }

        // 이동 활성화 시, 오브젝트를 목표 위치로 이동
        if (moving)
        {
            float step = speed * Time.deltaTime; // 이동 속도 계산
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // 목표 위치에 도달했는지 확인
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                moving = false; // 이동 중지
                movedToCenter = !movedToCenter; // 중앙으로 이동했는지 상태 토글
            }
        }
    }
}
