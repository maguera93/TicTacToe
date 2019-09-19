using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class LoadView : View {

    public Image image;

	// Use this for initialization
	public void Init () {
        image.color = Color.black;
	}
	
    public void Hide()
    {
        StartCoroutine(HideAnimation());
    }

    IEnumerator HideAnimation()
    {
        float _timeCounter = 0;
        float _timeDuration = 0.5f;

        Color currentColor = image.color;

        while (true)
        {
            _timeCounter += Time.deltaTime;
            currentColor.a = Easing.QuadEaseIn(_timeCounter, 1, -1, _timeDuration);

            image.color = currentColor;

            if (_timeCounter >= _timeDuration)
            {
                _timeCounter = 0;
                gameObject.SetActive(false);

                yield break;
            }

            yield return null;
        }
    }
}
