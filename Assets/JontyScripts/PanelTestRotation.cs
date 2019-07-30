using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTestRotation : MonoBehaviour
{
    public GameObject Charge;
    public bool Rotating = false;

    public void RotatePanel()
    {
        if (Rotating == false)
            StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        Charge.GetComponent<ChargeRotationbyPanel>().RotateChargewithPanel(gameObject.transform);
        Rotating = true;
        for (int i = 0; i < 36; i++)
        {
            transform.Rotate(new Vector3(0, 0, 5));
            yield return new WaitForSeconds(0.01f);
        }

        transform.Rotate(new Vector3(0, 0, 5));
        yield return new WaitForSeconds(0.05f);
        transform.Rotate(new Vector3(0, 0, -5));
        Rotating = false;
        yield return new WaitForSeconds(0.2f);

        Charge.GetComponent<ChargeRotationbyPanel>().FreeChargefromPanel();        
    }
}
