using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlataformaMovimiento : MonoBehaviour
{

    [SerializeField] private Transform[] plataformasMovimientoY;
    [SerializeField] private Transform plataformaRotatoria;
    private float velocidadRotacion = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        plataformasMovimientoY[0].transform.DOMoveY(8.0f, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        plataformasMovimientoY[1].transform.DOMoveY(8.0f, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        plataformasMovimientoY[2].transform.DOMoveY(4.0f, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        plataformasMovimientoY[3].transform.DOMoveY(4.0f, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        plataformasMovimientoY[4].transform.DOMoveY(8.0f, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);


    }

    private void Update()
    {
        plataformaRotatoria.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }



}