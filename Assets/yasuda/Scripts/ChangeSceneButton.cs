using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField]
    private SceneTransition.SceneType nextScene;

    [SerializeField] 
    private Button m_button;
    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(() => {
            SceneTransition.Instance.LoadScene(nextScene);
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
