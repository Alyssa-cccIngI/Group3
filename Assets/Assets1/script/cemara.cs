using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemara : MonoBehaviour
{
	public Transform playerTransform;   //���幫��������¼С���λ����Ϣ
	private Vector3 offset;    //���������С��֮ǰ�ľ���
							   // Use this for initialization
	void Start()
	{
		offset = transform.position - playerTransform.position;    //���������С��֮�����
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = playerTransform.position + offset;  //���־���
	}
}
