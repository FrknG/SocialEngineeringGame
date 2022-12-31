using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPAllign
{
    [AddComponentMenu("Layout/TMPLayout")]

    public class TMPSizeFitter: MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI m_TextMeshPro;
        public TMPro.TextMeshProUGUI TextMeshPro
        {
            get
            {
                if(m_TextMeshPro == null && transform.GetComponentInChildren<TMPro.TextMeshProUGUI>())
                {
                    m_TextMeshPro = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                    m_TMPRectTransform = m_TextMeshPro.rectTransform;
                }
                return m_TextMeshPro;
            }
        }

        private RectTransform m_RectTransform;

        public RectTransform rectTransform
        {
            get
            {
                if (m_RectTransform == null)
                {
                    m_RectTransform = GetComponent<RectTransform>();
                }
                return m_RectTransform;
            }
        }
        private RectTransform m_TMPRectTransform;
        public RectTransform TMPRectTransform { get { return m_TMPRectTransform; } }



        private float m_PrefHeight;
        public float PrefHeight { get { return m_PrefHeight; } }    

        private void SetHeight()
        {
            if(TextMeshPro == null)
            {
                return;
            }
            m_PrefHeight = TextMeshPro.preferredHeight;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, m_PrefHeight);
        }

        private void OnEnable()
        {
            SetHeight();
        }

        private void Start()
        {
            SetHeight();
        }

        private void Update()
        {
                if(m_PrefHeight != TextMeshPro.preferredHeight)
            {
                SetHeight();
            }
        }



    }
}
    

