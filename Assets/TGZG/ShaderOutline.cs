using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderOutLine : MonoBehaviour {
    public Color Color;
    public float �߿���;
    public float ģ����;
    public Vector2 �ߴ�;
    public bool Mix;
    public void Start() {

    }
    //������仯ʱˢ�£�����Unity bug
    public void OnApplicationFocus(bool focus) {
        //Active();
    }
    public void Active() {
        //if (GetComponent<Image>() == null) {
        //    throw new System.Exception("ģ����ֵ���󣡴������ϱ������Image�����");
        //}
        //GetComponent<Image>().material = new Material(Shader.Find("Custom/ģ�������3"));
        //GetComponent<Image>().material.SetColor("BorderC", Color);
        //GetComponent<Image>().material.SetColor("SelfColor", gameObject.GetComponent<Image>().color);
        //GetComponent<Image>().material.SetFloat("Size", ģ����);
        //GetComponent<Image>().material.SetFloat("BorderW", �߿���);
        //GetComponent<Image>().material.SetInt("Mix", Mix ? 1 : 0);
        //GetComponent<Image>().material.SetVector("Rect", �ߴ� = new Vector2(GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height));
        //if (GetComponent<Image>().sprite != null) {
        //    //GetComponent<Image>().material.SetTexture("_MainTex", GetComponent<Image>().sprite.texture);
        //}
    }
    //���ߴ�仯ʱˢ�£����¼���߿�
    public void OnRectTransformDimensionsChange() {
        GetComponent<Image>().material.SetVector("Rect", �ߴ� = new Vector2(GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height));
    }
}
