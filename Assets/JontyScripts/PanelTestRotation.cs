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
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(0, 0, 2));
            yield return new WaitForSeconds(0.01f);
        }

        transform.Rotate(new Vector3(0, 0, 3));
        yield return new WaitForSeconds(0.2f);
        transform.Rotate(new Vector3(0, 0, -3));
        Rotating = false;
        yield return new WaitForSeconds(0.3f);

        Charge.GetComponent<ChargeRotationbyPanel>().FreeChargefromPanel();        
    }
}
