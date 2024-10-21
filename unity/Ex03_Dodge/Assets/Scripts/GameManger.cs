using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ��������9
// 1. ����(���ǳ�)
//      ~5�ʱ����� 1�� ��ġ ~10�ʱ����� 2��, ~15�� 3��, ~20���̻��� 4��
// 2. Life Count�ý���: ������ī��Ʈ :
//      3���� ����
//      Unity UI : ���� ���� "Life:3" Text�� ǥ���ϱ�
//      �Ѿ˿� ���� ���� Life Count -1 ���, 0�� �Ǹ� ����
// 3. ���� ��ġ�� 5�ʸ��� ����� ť�� �������� ����Ѵ�.
//    �������� ������, Life Count +1�Ѵ�.

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText; // Ȱ��ȭ/��Ȱ��ȭ ����
    public Text timeText; // Text ������Ʈ ��ũ
    public Text recordText;
    public Text lifeText;

    public GameObject EggSpawner1;
    public GameObject EggSpawner2;
    public GameObject EggSpawner3;
    public GameObject EggSpawner4;
    public GameObject EggSpawner5;
    public GameObject EggSpawner6;
    public GameObject EggSpawner7;
    public GameObject EggSpawner8;

    private float surviveTime;
    private bool isGameover;
    public int lifeCount = 3;

    void Start() {
        // �ʱ�ȭ
        surviveTime = 0f;
        isGameover = false;
        lifeCount = 3;
        //���� ���� �ؽ�Ʈ�� ��Ȱ��ȭ
        gameoverText.SetActive(false);
        //���� ��Ȱ��ȭ
        EggSpawner1.SetActive(true);
        EggSpawner2.SetActive(true);
        EggSpawner3.SetActive(true);
        EggSpawner4.SetActive(true);
        EggSpawner5.SetActive(true);
        EggSpawner6.SetActive(true);
        EggSpawner7.SetActive(true);
        EggSpawner8.SetActive(true);
        // ���ӽ��� ���� ���
        SoundManger soundManger = FindObjectOfType<SoundManger>();
        if(soundManger != null) {
            soundManger.PlaySound("game_start");
        }
    }
    public void EndGame() {
        //���� ���� ���·� ����
        isGameover = true;
        //���� ���� �ؽ�Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //����� �ְ����� ���Ͽ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime"); //�⺻���� 0
        if(surviveTime > bestTime) { //�ְ��� ����
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime); //�����ð��� �ְ������� ����
        }
        recordText.text = "Best Time: " + Mathf.Round(bestTime);
    }

    // �� fps���� ȣ���
    void Update() {
        if(!isGameover) {
            // �����ð� ����
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
            lifeText.text = "Life: " + lifeCount;

            //if(surviveTime > 5.0f) {
            //    EggSpawner3.SetActive(true);
            //    EggSpawner4.SetActive(true);
            //}
            //if(surviveTime > 10.0f) {
            //    EggSpawner5.SetActive(true);
            //    EggSpawner6.SetActive(true);
            //}
            //if(surviveTime > 15.0f) {
            //    EggSpawner7.SetActive(true);
            //    EggSpawner8.SetActive(true);
            //}
        } else {
            if(Input.GetKeyDown(KeyCode.R)) {
                //SampleScene�� �ٽ� �ε�(�ҷ�����)�Ѵ�.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}







