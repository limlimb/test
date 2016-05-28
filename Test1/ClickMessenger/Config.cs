using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ClickMessenger
{
    [DataContract]
    class Config
    {
        StreamingContext context = new StreamingContext(StreamingContextStates.All);

        public Config()
        {
            SetStatus(context);
        }

        /// <summary>1秒間のクリック間隔
        /// </summary>
        [DataMember]
        public int ClickInterval;

        /// <summary>既定値を設定する
        /// </summary>
        [OnDeserializing]
        public void SetStatus(StreamingContext sc)
        {
            ClickInterval = 30;
        }
    }
}