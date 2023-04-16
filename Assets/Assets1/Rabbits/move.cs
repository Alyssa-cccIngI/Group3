using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move : MonoBehaviour
{
    public float moveSpeed = 1f;
    // ��������
    private Rigidbody rb;
    // ��������
    private Animator animator;
    // λ���ƶ�
    private Vector3 targetPos;
    // �����Ƿ��ƶ���bool����
    private bool isMove;
    // �ڿ�ʼ��һִ֡�еĺ���
    public int score = 0;
    public GameObject sco;
    public GameObject winn;
    public AudioSource music;
    // public AudioSource music;
    //public Text text;
    void Start()
    {
        // ��ȡ��ǰ����ĸ�������
        rb = GetComponent<Rigidbody>();
        // ��ȡ��ǰ����Ķ�������
        animator = GetComponent<Animator>();
        winn.SetActive(false);
        music = GetComponent<AudioSource>();
        //music.Stop();
    }
    // ˢ�µ�ÿһִ֡�еĺ���
    void Update()
    {
        // ���ռ��̲�������
        Run();
        // �ƶ�״̬
        if (isMove)
        {
            // �����Run��֮ǰ���Ǵ�����״̬ת�����Ǹ����������֣������Լ��������޸�
            animator.SetBool("Run", isMove);
            // ʵ��������ƶ�
            rb.velocity = transform.forward * moveSpeed * 1.1f;
            // �ھ���Ŀ��ĵص�ܽ���ʱ��0.1f����ֹͣ�ƶ�
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                rb.velocity = Vector3.zero;
                isMove = false;
                animator.SetBool("Run", isMove);
            }
        }
    }

    void Run()
    {
        // ������wǰ���߼�
        if (Input.GetKey(KeyCode.W))
        {
            targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1);
            // ת��
            transform.LookAt(targetPos);
            //�ı��ƶ�State
            isMove = true;
        }
        // ������a�����߼�
        if (Input.GetKey(KeyCode.A))
        {
            //��¼��Ŀ���
            targetPos = new Vector3(transform.localPosition.x + 1, transform.localPosition.y, transform.localPosition.z);
            // ת��
            transform.LookAt(targetPos);
            //�ı��ƶ�State
            isMove = true;
        }
        // ������s�����߼�
        if (Input.GetKey(KeyCode.S))
        {
            //��¼��Ŀ���
            targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);
            // ת��
            transform.LookAt(targetPos);
            //�ı��ƶ�State
            isMove = true;
        }

        // ������D�����߼�
        if (Input.GetKey(KeyCode.D))
        {
            // ��¼��Ŀ���
            targetPos = new Vector3(transform.localPosition.x - 1, transform.localPosition.y, transform.localPosition.z);
            // ת��
            transform.LookAt(targetPos);
            // �ı��ƶ�״̬
            isMove = true;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "carrot")
        {
            Destroy(collision.collider.gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "carrot")
        {
            music.Play();
            score++;
            //music.play();
            sco.GetComponent<TMP_Text>().text = "Score:" + score.ToString()+"/10";
            if (score == 10)
            {
                winn.SetActive(true);
                Time.timeScale = 0;

            }
            Destroy(collider.gameObject);
        }
    }
}
