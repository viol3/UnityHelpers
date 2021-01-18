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
            DOTween.To(() => _smr.GetBlendShapeWeight(GameUtility.GetBSIndexByName(_smr, bsName)), x => _smr.SetBlendShapeWeight(GameUtility.GetBSIndexByName(_smr, bsName), x), value, duration);
        }
        
    }
}