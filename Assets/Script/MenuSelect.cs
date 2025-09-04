using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class MenuSelect : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
	[SerializeField]
	Toggle toggle;


	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter");
		if(Input.GetMouseButtonDown(0))
		{
			toggle.isOn = true;
		}
		
	}

	public void OnSelect(BaseEventData eventData)
	{
		Debug.Log(this.gameObject.name + " was selected");
		toggle.isOn = true;
		
	}
}