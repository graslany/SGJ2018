using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZooomCard : MonoBehaviour {

    private Vector3 originalScale;

    public Vector3 DestinationPosition = new Vector3(0,0,2);

    private Vector3 originalPosition;


    public Vector3 maxScale = new Vector3(2.5f, 2.5f, 0);

    private Vector3 zoomVelocity;
    private Vector3 positionVelocity;


    private enum STATE{
        ZOOMING,
        ZOOMED,
        DEFAULT,
        REDUCING
    };

    private STATE mCurrentState;

	// Use this for initialization
	void Start () {
        mCurrentState = STATE.DEFAULT;
        GetComponent<Button>().onClick.AddListener(ToggleState);
        originalScale = GetComponent<RectTransform>().localScale;
        originalPosition = GetComponent<RectTransform>().localPosition;
	}

    private void ToggleState()
    {
        mCurrentState = InverseState();
    }

    private STATE InverseState()
    {
        switch (mCurrentState)
        {
            case STATE.ZOOMING:
                return STATE.REDUCING;
            case STATE.ZOOMED:
                return STATE.REDUCING;
            case STATE.DEFAULT:
                return STATE.ZOOMING;
            case STATE.REDUCING:
                return STATE.ZOOMING;
        }
        return STATE.DEFAULT;
    }

    private RectTransform rt()
    {
        return GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (mCurrentState == STATE.DEFAULT || mCurrentState == STATE.ZOOMED) return;

        if(mCurrentState == STATE.ZOOMING) {
            foreach(ZooomCard go in GameObject.FindObjectsOfType<ZooomCard>())
            {
                if(go != this)
                {
                    go.gameObject.SetActive(false);
                }
            }

            GetComponent<Button>().image.canvas.sortingLayerName = "UI";
            rt().localScale = Vector3.SmoothDamp(rt().localScale, maxScale, ref zoomVelocity, Time.deltaTime);
            rt().localPosition = Vector3.SmoothDamp(rt().localPosition, DestinationPosition, ref positionVelocity, Time.deltaTime);

            Debug.Log(DestinationPosition);

            if (rt().localScale == maxScale)
            {
                mCurrentState = STATE.ZOOMED;
                zoomVelocity = Vector3.zero;
                positionVelocity = Vector3.zero;
            }
        }
        else if(mCurrentState == STATE.REDUCING)
        { 
            foreach(ZooomCard go in Resources.FindObjectsOfTypeAll(typeof(ZooomCard)))
            {
                    go.gameObject.SetActive(true);
            }

            rt().localScale = Vector3.SmoothDamp(rt().localScale, originalScale, ref zoomVelocity, Time.deltaTime);
            rt().localPosition = Vector3.SmoothDamp(rt().localPosition, originalPosition, ref positionVelocity, Time.deltaTime);

            if (rt().localScale == originalScale)
            {
                mCurrentState = STATE.DEFAULT;
                zoomVelocity = Vector3.zero;
                positionVelocity = Vector3.zero;
            }
        }

	}
}
