using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimUiLL : MonoBehaviour
{
    //[Header("Resetowanie skali po schowaniu i pokazaniu komponentu (false, jesli w kazdej klatce ukrywamy i pokazujemy obiek")]
    //public bool resetItmeInOnEnalbed = true;

    [Header("Zmian alfy")]
    public bool enabledAlphaAnimation;
    public AnimationCurve alphaCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    //public AnimationCurve rotationCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    [Header("Obracanie o kąt (Euler) na sekunde w wybranych osiach")]
    public bool enabledRotation;
    public Vector3 rotationEulers = new Vector3(0, 0, 30.0f);

    [Header("Zmiana skali")]
    public bool enabledScaleAnimation;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0, 1.0f, 1, 1.2f);
    //public Vector3 rotationEulers = new Vector3();

    float time;

    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = this.transform.GetComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        //if(resetItmeInOnEnalbed)
        time = 0;
        UpdateUi();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Agtualizuje animacje");

        time += Time.deltaTime;

        UpdateUi();
    }
    void UpdateUi()
    {
        if (enabledAlphaAnimation)
            canvasGroup.alpha = alphaCurve.Evaluate(time);

        if (enabledRotation)
            transform.Rotate(rotationEulers * Time.deltaTime);

        if (enabledScaleAnimation)
        {
            transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
        }
    }
}
