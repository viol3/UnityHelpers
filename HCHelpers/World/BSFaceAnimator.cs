using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.World
{
    public class BSFaceAnimator : MonoBehaviour
    {
        private SkinnedMeshRenderer _smr;

        private void Start()
        {
            _smr = GetComponent<SkinnedMeshRenderer>();
        }

        public void MoveBSValueTo(string bsName, float value, float duration)
        {
            DOTween.To(() => _smr.GetBlendShapeWeight(GetBSIndexByName(bsName)), x => _smr.SetBlendShapeWeight(GetBSIndexByName(bsName), x), value, duration);
        }

        int GetBSIndexByName(string bsName)
        {
            _smr = GetComponent<SkinnedMeshRenderer>();
            Mesh m = _smr.sharedMesh;
            for (int i = 0; i < m.blendShapeCount; i++)
            {
                if (m.GetBlendShapeName(i).Equals(bsName))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}