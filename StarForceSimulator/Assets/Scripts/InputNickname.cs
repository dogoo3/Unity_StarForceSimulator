using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputNickname : MonoBehaviour
{
    [SerializeField] private EquipWindowManager sm_equipWindowManager;

    private InputField m_inputField;

    private int[] bytes;
    
    private int totalByte = 0;
    private int oldLength = 0;

    private void Awake()
    {
        m_inputField = GetComponent<InputField>();
        bytes = new int[18];
    }

    public void SendData()
    {
        if (m_inputField.text.Length < 2)
            return;

        sm_equipWindowManager.GetUserItemInfo(m_inputField.text);
        m_inputField.text = "";

        totalByte = 0;
        oldLength = 0;
    }

    public void CheckTextLength()
    {
        m_inputField.text = Regex.Replace(m_inputField.text, @"[^0-9a-zA-Z가-힣]", ""); // 특수문자를 입력받게된다면 바로 없애줌

        if (oldLength == m_inputField.text.Length) // 특수문자를 입력받으면 연산하지 않는다
            return;

        if (m_inputField.text == "") // 다 지워지면 초기화한다
        {
            totalByte = 0;
            oldLength = 0;

            return;
        }

        byte[] asd = Encoding.UTF8.GetBytes(m_inputField.text.Substring(m_inputField.text.Length - 1, 1));
        
        
        if(oldLength < m_inputField.text.Length)
        {
            if (asd.Length == 3) // 한글
            {
                bytes[m_inputField.text.Length-1] = 2;
                totalByte += 2;
            }
            else // 영문
            {
                bytes[m_inputField.text.Length-1] = 1;
                totalByte++;
            }

            if (totalByte > 12) // 길이를 꽉 채웠을 경우 (한글로 6글자를 가득 채웠거나 영문으로 12글자를 가득 채웠을 경우)
            {
                m_inputField.text = m_inputField.text.Substring(0, m_inputField.text.Length - 1);
                totalByte -= bytes[m_inputField.text.Length];
            }
        }
        else
        {
            totalByte = 0;
            oldLength = 0;
            for (int i = 0; i < m_inputField.text.Length;i++)
            {
                byte[] zxcv = Encoding.UTF8.GetBytes(m_inputField.text.Substring(i, 1));
                if (asd.Length == 3) // 한글
                {
                    bytes[i] = 2;
                    totalByte += 2;
                }
                else // 영문
                {
                    bytes[i] = 1;
                    totalByte++;
                }
            }
        }
        oldLength = m_inputField.text.Length;
    }
}
