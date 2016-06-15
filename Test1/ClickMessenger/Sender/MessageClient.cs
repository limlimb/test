using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClickMessenger.Sender.ImageRecognition;

namespace ClickMessenger.Sender
{
    // 連打や各クリック用のクライアント
    //
    // 勉強: Taskベースの投げっぱなしマルチスレッド処理クラス
    // TaskCreationOptions.LongRunningはスレッドプールに含まれない専用のスレッドを生成するが、
    // Defaultでどうしても処理が遅くなってしまうケース以外では通常推奨されない
    class MessageClient : IDisposable
    {
        MessageSender sender;
        Task clickTask;
        Task capturingTask;
        CancellationTokenSource cts;
        CancellationToken token;

        public MessageClient(IntPtr flashHandle, Config config)
        {
            sender = new MessageSender(flashHandle);
            cts = new CancellationTokenSource();
            token = cts.Token;

            // タスクの初期化
            if (!(config.DontClick))
            {
                clickTask = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        sender.Click(900, 320);
                        var interval = 1000 / config.ClickInterval;
                        Thread.Sleep(interval);

                        try
                        {
                            if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException) { return; }
                    }
                },
                token,
                TaskCreationOptions.None,
                TaskScheduler.Default
                );
            }
            capturingTask = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    using (var screen = ScreenCapture.GrayCapture(flashHandle))
                    {
                        var recognizers = new ImageRecognitionBase[]
                        {
                            new Clickable(),
                        };
                        foreach (var recognizer in recognizers)
                        {
                            if (recognizer.Check(screen)) sender.Click(recognizer.X, recognizer.Y);
                        }
                    }

                    try
                    {
                        if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
                    }
                    catch (OperationCanceledException) { return; }

                    Thread.Sleep(15000);
                }
            },
            token,
            TaskCreationOptions.None,
            TaskScheduler.Default
            );
        }

        public void ProgressiveClick()
        {
            // 靴アイコンは1113, 250
            sender.Click(1113, 250);
        }

        public void NextMapClick()
        {
            // 次のマップ: 907, 42
            sender.Click(907, 42);
        }

        public void PreviousMapClick()
        {
            // 前のマップ: 784, 42
            sender.Click(784, 42);
        }

        #region IDisposableメンバ

        public void Dispose()
        {
            cts.Cancel();
            cts.Dispose();
        }

        #endregion
    }
}
