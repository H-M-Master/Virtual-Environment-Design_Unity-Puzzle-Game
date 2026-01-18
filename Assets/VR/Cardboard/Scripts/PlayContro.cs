using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayContro : MonoBehaviour
{
    public Button PlayBtn;
    public Button OverBtn;
    public Button BackBtn;
    /// <summary>
    /// 游玩设施子物体
    /// </summary>
    public Transform PlayTra;
    public Transform VRCameraTra;
    public Collider MoveCollider;
    public Transform RootTra;
    private Vector3 tempPos=Vector3.zero;
    private Vector3 tempRota = Vector3.zero;
    private void Awake()
    {
        OverBtn.gameObject.SetActive(false);
        PlayBtn.onClick.AddListener(Play);
        OverBtn.onClick.AddListener(Over);
        BackBtn.onClick.AddListener(()=> {
            SceneManager.LoadScene(0);
        });
        tempPos = VRCameraTra.position;
        tempRota = VRCameraTra.localEulerAngles;
    }
    private void Play()
    {
        PlayBtn.gameObject.SetActive(false);
        OverBtn.gameObject.SetActive(true);
        MoveCollider.enabled = false;
        tempPos = VRCameraTra.position;
        tempRota = VRCameraTra.localEulerAngles;
        VRCameraTra.SetParent(PlayTra);
       VRCameraTra.localPosition = Vector3.zero;
    }
    private void Over()
    {
        PlayBtn.gameObject.SetActive(true);
        OverBtn.gameObject.SetActive(false);
        MoveCollider.enabled = true;
        VRCameraTra.SetParent(RootTra);
        VRCameraTra.position = tempPos;
        VRCameraTra.localEulerAngles = tempRota;
    }


    private void Update()
    {


    }
}
