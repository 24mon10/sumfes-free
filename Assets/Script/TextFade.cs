using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI starttext;
	float speed = 1.0f;
	float time;
	// Start is called before the first frame update
	void Start()
    {
        starttext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
		starttext.color = GetTextColor(starttext.color);

	}
	Color GetTextColor(Color color)
	{
		time += Time.deltaTime * speed * 5.0f;
		color.a = Mathf.Sin(time);

		return color;
	}
}
