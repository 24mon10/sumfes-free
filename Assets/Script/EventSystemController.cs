using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemController : MonoBehaviour
{
	[SerializeField] GameObject firstSelect;
    // Start is called before the first frame update
    void Start()
    {
        if(EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(firstSelect);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
