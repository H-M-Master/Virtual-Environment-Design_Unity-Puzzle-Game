using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GazeTip : MonoBehaviour
{
    public static GazeTip Instance;
    public Image TipImage;
    public Vector3 InitScale= new Vector3(0.00005f, 0.00005f, 1f);
    public Vector3 TargetScale=new Vector3(0.0001f,0.0001f,1f);
    private Tweener tweener;
    private void Awake()
    {
        Instance = this;
  transform.localScale = InitScale;
        TipImage.color = Color.white;
    }

    public void Open(float t,Vector3 pos)
    {
        if(pos!=Vector3.zero)
        transform.position = pos;
        var dis = Vector3.Distance(Camera.main.transform.position,transform.position);
        transform.localScale = transform.localScale*dis;
        if (tweener != null)
            tweener.Rewind();
        transform.DOScale(TargetScale,0.1f);
        TipImage.fillAmount = 0f;
        tweener = TipImage.DOFillAmount(1, t).SetEase(Ease.Linear).SetAutoKill();
        TipImage.color = Color.green;
    }

    public void Close()
    {
        if(tweener!=null)
        tweener.Rewind();
        transform.DOScale(InitScale, 0.1f);
        TipImage.fillAmount = 1f;
        TipImage.color = Color.white;
    }
}
