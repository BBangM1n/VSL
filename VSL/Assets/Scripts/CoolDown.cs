using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image coolDownImage;

    // Unity Coroutine
    public IEnumerator CoolTimeCoroutine(float CoolTime)
    {
        var NowCoolTime = CoolTime;

        while(NowCoolTime > 0.0f)
        {
            button.interactable = false;

            NowCoolTime -= Time.deltaTime;

            coolDownImage.fillAmount = NowCoolTime / CoolTime;

            yield return new WaitForFixedUpdate();
        }

        button.interactable = true;
    }
    // Interface
}
