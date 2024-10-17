using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaDeChegada1 : MonoBehaviour
{
     public GameObject linhaDeChegada;

    void Start()
    {
        StartCoroutine(AtivarLinhaDeChegadaDepoisDe30Segundos());
        linhaDeChegada.SetActive(false);
    }

    IEnumerator AtivarLinhaDeChegadaDepoisDe30Segundos()
    {
        yield return new WaitForSeconds(3f);
        linhaDeChegada.SetActive(true);
    }
}
