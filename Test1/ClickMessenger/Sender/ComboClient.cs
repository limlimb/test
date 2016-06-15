using System;
using System.Threading;

namespace ClickMessenger.Sender
{
    // DRコンボ用のクライアント
    // 勉強: Threadベースの投げっぱなしマルチスレッド処理クラス
    class ComboClient : IDisposable
    {
        MessageSender sender;
        Thread comboThread;

        public ComboClient(IntPtr flashHandle)
        {
            sender = new MessageSender(flashHandle);

            // スレッドの初期化
            comboThread = new Thread(() =>
            {
                while (true)
                {
                    // 123457869→15分待機
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    sender.Key(KeyCode.VK_KEY_3);
                    sender.Key(KeyCode.VK_KEY_4);
                    sender.Key(KeyCode.VK_KEY_5);
                    sender.Key(KeyCode.VK_KEY_7);
                    sender.Key(KeyCode.VK_KEY_8);
                    sender.Key(KeyCode.VK_KEY_6);
                    sender.Key(KeyCode.VK_KEY_9);
                    Thread.Sleep((15 * 60 + 2) * 1000);

                    // 89123457→2分半待機
                    sender.Key(KeyCode.VK_KEY_8);
                    sender.Key(KeyCode.VK_KEY_9);
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    sender.Key(KeyCode.VK_KEY_3);
                    sender.Key(KeyCode.VK_KEY_4);
                    sender.Key(KeyCode.VK_KEY_5);
                    sender.Key(KeyCode.VK_KEY_7);
                    Thread.Sleep((2 * 60 + 30 + 1) * 1000);

                    // 12→2分半待機
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    Thread.Sleep((2 * 60 + 30 + 1) * 1000);

                    // 12→2分半待機
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    Thread.Sleep((2 * 60 + 30 + 1) * 1000);

                    // 1234→2分半待機
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    sender.Key(KeyCode.VK_KEY_3);
                    sender.Key(KeyCode.VK_KEY_4);
                    Thread.Sleep((2 * 60 + 30 + 1) * 1000);

                    // 12→2分半待機
                    sender.Key(KeyCode.VK_KEY_1);
                    sender.Key(KeyCode.VK_KEY_2);
                    Thread.Sleep((2 * 60 + 30 + 1) * 1000);

                    // 12→2分半待機
                    // ここまでのSleepに遊びを入れるのでこのフェイズを無効にしておく
                    // sender.Key(KeyCode.VK_KEY_1);
                    // sender.Key(KeyCode.VK_KEY_2);
                    Thread.Sleep((2 * 60 + 30) * 1000);
                }
            })
            { IsBackground = true };

            // スレッドの開始
            comboThread.Start();
        }

        #region IDisposableメンバ

        public void Dispose()
        {
            try { comboThread.Abort(); } catch { }
        }

        #endregion
    }
}
