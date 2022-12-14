using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlataformaMovimientoCircular : MonoBehaviour
{


    [SerializeField] Transform plataforma;
    [SerializeField] private PathType p = PathType.CatmullRom;

    [SerializeField] private Vector3[] puntosTraslacion;
    private Tween t;


    // Start is called before the first frame update
    void Start()
    {
        t = plataforma.transform.DOPath(puntosTraslacion, 4, p).SetEase(Ease.Linear).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
