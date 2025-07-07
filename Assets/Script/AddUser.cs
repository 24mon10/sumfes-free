using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class AddUser : MonoBehaviour
{
	[SerializeField]
	TMP_InputField m_InputField;

	[SerializeField]
	GameObject panel;

	[SerializeField]
	TextMeshProUGUI userInfo;

	string inputValue;
	private void Start()
	{
	}

	public void OnClick()
	{
		var ds = new DataService("DataBase.db");
		ds.CreatUser(m_InputField.text);
		userInfo.text = m_InputField.text;
		panel.SetActive(false);
	}
}
