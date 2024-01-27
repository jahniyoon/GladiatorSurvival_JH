using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace JH
{
    public class PopularityManager : MonoBehaviour
    {
        #region 싱글톤 패턴
        public static PopularityManager Instance
        {
            get
            {
                // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
                if (m_Instance == null)
                {
                    // 씬에서 PopularityManager 오브젝트를 찾아 할당
                    GameObject popularityManager = new GameObject("PopularityManager");
                    m_Instance = popularityManager.AddComponent<PopularityManager>();
                }
                // 싱글톤 오브젝트를 반환
                return m_Instance;
            }
        }
        private static PopularityManager m_Instance; // 싱글톤이 할당될 static 변수    
        #endregion

        [Header("Popularity")]
        private int maxPopularity;   // 최대 인기도
        private int curPopularity;   // 현재 인기도

        [Header("Buff")]
        private float popularBuff;   // 버프
        private float popularDebuff; // 디버프



        #region ############################ 인기도 관련 세팅 ############################

        /// <summary> 인기도 세팅 </summary>
        public void SetPopularity(int value)
        {
            curPopularity = value;
        }

        /// <summary> 버프류 세팅 </summary>
        /// <param name="buff">세팅할 버프 값</param>
        /// <param name="debuff">세팅할 디버프 값</param>
        public void SetPopularityBuff(float buff, float debuff)
        {
            popularBuff = buff;
            popularDebuff = debuff;
        }
        #endregion


        #region ############################# 인기도 증감소 ############################

        // 인기도 증가
        public void PopularityIncrease(int value)
        {
            // 버프는 반올림
            int newValue = value + Mathf.RoundToInt(value * (popularBuff / 100));

            curPopularity += newValue;

            // 인기도가 최대를 넘기면 최대로 변경
            if (maxPopularity < curPopularity)
            {
                curPopularity = maxPopularity;
            }
        }

        // 인기도 감소
        public void PopularityDecrease(int value)
        {
            // 디버프는 반올림
            int newValue = value + Mathf.RoundToInt(value * (popularDebuff / 100));

            curPopularity -= newValue;

            // 인기도가 최대를 넘기면 최대로 변경
            if (curPopularity < 0)
            {
                curPopularity = 0;
            }
        }

        #endregion#
        // 인기도 감소 카운트 시작

        // 인기도 감소 카운트 종료

    }
}
