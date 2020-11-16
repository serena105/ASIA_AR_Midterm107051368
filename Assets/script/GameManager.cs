﻿using UnityEngine;

public class GameManager : MonoBehaviour
{   [Header("男孩")]
    public Transform boy;
    [Header("女孩")]
    public Transform girl;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("Boy旋轉速度"), Range(1f, 60f)]
    public float turnD = 1.2f;
    [Header("Girl旋轉速度"), Range(1f, 60f)]
    public float turnC = 1.2f;
    [Header("縮放"), Range(0.01f, 1f)]
    public float size = 0.06f;
    [Header("男孩動畫元件")]
    public Animator aniBoy;
    [Header("女孩動畫元件")]
    public Animator aniGirl;

    private void Start()
    {
        print("開始事件");
    }

    private void Update()
    {
        print("更新事件");
        print(joystick.Vertical);

        boy.Rotate(0, joystick.Horizontal * turnD, 0);
        girl.Rotate(0, joystick.Horizontal * turnC, 0);
        boy.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        boy.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(boy.localScale.x, 0.3f, 3f);
        girl.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        girl.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(girl.localScale.x, 0.3f, 3f);
    }

    public void PlayAnimation(string aniName)
    {
        print(aniName);
        aniBoy.SetTrigger(aniName);
        aniGirl.SetTrigger(aniName);
    }

}
