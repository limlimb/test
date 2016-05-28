using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Test1.Number
{
    public static class RundomNumber
    {
        /// <summary>bool値
        /// </summary>
        public static bool GetRandomBoolean()
        {
            var buffer = new byte[1];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }
            return buffer[0] >= 128;
        }

        /// <summary>[min, max]の範囲で指定された整数をランダムに返す
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns></returns>
        public static int GetRandomInteger(int min, int max)
        {
            if (min == max) return min;
            var buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }
            var toint = (double)BitConverter.ToUInt32(buffer, 0);
            var divide = (double)BitConverter.ToUInt32(buffer, 0) / (UInt32.MaxValue + 1.0);
            var range = max - min + 1;
            var floor = (int)((double)Math.Floor(divide * range) + min);
            return floor;
        }

        /// <summary>ランダムな文字列
        /// </summary>
        /// <param name="length">取得したい文字列の長さ</param>
        /// <param name="characterset">文字列のセット</param>
        /// <returns></returns>
        public static string GetRandomString(int length, string characterset)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                var index = GetRandomInteger(0, characterset.Length - 1);
                sb.Append(characterset[index]);
            }
            return sb.ToString();
        }

        /// <summary>Fisher-Yatesシャッフル
        /// </summary>
        /// <param name="list">シャッフルしたいList</param>
        public static void FisherYatesShuffle<T>(List<T> list)
        {
            for (var i = 0; i < list.Count; ++i)
            {
                var swappedIndex = GetRandomInteger(0, i);
                var temp = list[i];
                list[i] = list[swappedIndex];
                list[swappedIndex] = temp;
            }
        }

        /// <summary>確率の判定を行う
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        /// <returns></returns>
        public static bool GetProbability(int numerator, int denominator)
        {
            // 分子が0ならfalse
            if (numerator == 0) return false;

            // 確率が1ならtrue
            if (numerator == denominator) return true;

            // 分母が0なら例外スロー
            if (denominator == 0) throw new ArgumentOutOfRangeException("ゼロ除算は行えません。");

            // 分子＞分母なら例外スロー
            if (numerator > denominator) throw new ArgumentOutOfRangeException("確率を1より大きい数にすることはできません。");

            var number = GetRandomInteger(1, denominator);
            return number >= 1 && number <= numerator;
        }
    }
}
