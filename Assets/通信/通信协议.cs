using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ս�׸���.�����ռ�;
using static TGZG.�����ռ�;
using TGZG;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace ս�׸��� {
    //�����б�ͨѶЭ��
    public struct ���з��������� {
        public List<����������> �����б�;
        [JsonIgnore]
        public int �������� => �����б�.Count;
        [JsonIgnore]
        public ���������� this[int index] => �����б�[index];
        [JsonIgnore]
        public ���������� this[string ������] => �����б�.Find(x => x.������ == ������);
        public bool ���ڷ���(string ������) => �����б�.Exists(x => x.������ == ������);
    }
    public struct ���������� {
        public string IP;
        public string ������;
        public string ��������;
        public string ����;
        public int ����;
        public string ��ͼ��;
        public bool ��������;
        public string ����汾;
        public int ÿ��ͬ������;
        public DateTime ���䴴��ʱ��;
        public ģʽ���� ģʽ;
        public List<�ؾ�����> ��ѡ�ؾ�;
        public List<����> ��ѡ����;
    }
    public enum ģʽ���� {
        ����,
        ����,
        �Զ���
    }
    //��ϷͨѶ��ÿ�뷢����ʮ�Ρ�Ϊ�˼��ʹ���ѹ�����ֶ�����������Ҫ���̡ܶ�
    public struct ����������� {
        public ��ҽ������� u;
        public ����������� p;
        public int[] ��;
        public List<������������> msl;
        public HashSet<��λ> ��;
        public void ��λ����() {
            //����floatֻ������λС��
            p.p = p.p.Select(t => (float)Math.Round(t, 3)).ToArray();
            p.d = p.d.Select(t => (float)Math.Round(t, 3)).ToArray();
            p.v = p.v.Select(t => (float)Math.Round(t, 3)).ToArray();
            p.r = p.r.Select(t => (float)Math.Round(t, 3)).ToArray();
            for (int i = 0; i < msl.Count; i++) {
                var n = new ������������();
                n.��� = msl[i].���;
                n.tp = msl[i].tp;
                n.p = msl[i].p.Select(t => (float)Math.Round(t, 3)).ToArray();
                n.d = msl[i].d.Select(t => (float)Math.Round(t, 3)).ToArray();
                n.v = msl[i].v.Select(t => (float)Math.Round(t, 3)).ToArray();
                n.r = msl[i].r.Select(t => (float)Math.Round(t, 3)).ToArray();
                msl[i] = n;
            }
        }
    }
    public struct ������������ {
        public int ���;
        public �������� tp;
        public float[] p;
        public float[] d;
        public float[] v;
        public float[] r;
    }
    public enum �������� {
        ��,
        AIM9E,
    }
    public enum ��λ {
        ��,
        ��,
        ����,
        ����,
        ����,
        ����,
        ��β,
        ��β,
        ��,
    }
    public struct ������Ϣ {
        public string ������;
        public string ������;
        public float �˺�;
        public ��λ ��λ;
    }
    public struct ��ҽ������� {
        public string n;
        public �ؾ����� tp;
        public ���� tm;
        public TimeSpan ����;
        public (string, string) ������;
        public ��������[] ����;
    }
    public struct ����������� {
        public float[] p;
        public float[] d;
        public float[] v;
        public float[] r;
    }
    public enum �ؾ����� {
        ��,
        m15n23,
        f86f25,
        f4c,
        m21pfm,
        P51h
    }
    public enum ���� {
        ��,
        ��,
        ��,
        ϵͳ
    }
    public struct �Ʒְ����� {
        public string[] �ж���;
        public List<object[]> ������;
        public object[] ȡ��(int �к�) {
            return ������[�к�];
        }
        public object[] ȡ��(string ����) {
            var �к� = Array.IndexOf(�ж���, ����);
            if (�к� < 0) return null;
            return ������.Select(t => t[�к�]).ToArray();
        }
    }
}
