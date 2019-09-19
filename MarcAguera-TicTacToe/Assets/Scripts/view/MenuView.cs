using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : View
{

    public Signal PlaySignal = new Signal { };

    public Transform titleTransform;
    public Button playButton;

	// Use this for initialization
	public void Init ()
    {
        playButton.onClick.AddListener(OnClick);
	}
	
	public void OnClick()
    {
        PlaySignal.Dispatch();
    }

    public void Show()
    {
        StartCoroutine(TitleAnimation());
    }

    IEnumerator TitleAnimation()
    {
        float _timeCounter = 0;
        float _timeDuration = 1f;

        Vector3 _finalSize = titleTransform.localScale;
        Vector3 _currentSize = Vector3.zero;

        Vector3 _finalRotation = titleTransform.eulerAngles;
        Vector3 _currentRotation = Vector3.zero;

        while (true)
        {
            _timeCounter += Time.deltaTime;
            _currentSize.x = Easing.QuadEaseIn(_timeCounter, 0, _finalSize.x, _timeDuration);
            _currentSize.y = Easing.QuadEaseIn(_timeCounter, 0, _finalSize.y, _timeDuration);

            _currentRotation.z = Easing.CubicEaseIn(_timeCounter, -180, _finalRotation.z + 180, _timeDuration);

            titleTransform.localScale = _currentSize;
            titleTransform.eulerAngles = _currentRotation;

            if (_timeCounter >= _timeDuration)
            {
                _timeCounter = 0;

                titleTransform.localScale = _finalSize;

                titleTransform.eulerAngles = _finalRotation;

                yield break;
            }

            yield return null;
        }
    }
}
