using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{

    [SerializeField] private Text bestScoreText;
    [SerializeField] private InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.LoadData();
        bestScoreText.text = string.Format("BEST SCORE : {0} : {1}", MenuManager.Instance.playerName, MenuManager.Instance.score);
        nameInputField.text = MenuManager.Instance.playerName;
    }

    public void SaveData()
    {
        MenuManager.Instance.SetNameScore(nameInputField.text, 0);
    }
}
