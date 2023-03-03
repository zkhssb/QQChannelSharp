using QQChannelSharp.Enumerations;

namespace QQChannelSharp.Extensions
{
    public static class EventTypeExtension
    {
        public static StateChangeType GetStateChangeType(this EventType type)
        {
            string typeString = type.ToString().ToLower();
            if (typeString.EndsWith("add"))
                return StateChangeType.Add;
            else if (typeString.EndsWith("create"))
                return StateChangeType.Create;
            else if (typeString.EndsWith("delete"))
                return StateChangeType.Delete;
            else if (typeString.EndsWith("update"))
                return StateChangeType.Update;
            else
                return StateChangeType.None;
        }

        public static AudioEventType GetAudioEventType(this EventType type)
        {
            switch (type)
            {
                case EventType.AUDIO_FINISH:
                    return AudioEventType.Finish;
                case EventType.AUDIO_START:
                    return AudioEventType.Start;
                case EventType.AUDIO_OFF_MIC:
                    return AudioEventType.OffMic;
                case EventType.AUDIO_ON_MIC:
                    return AudioEventType.OnMic;
                default:
                    throw new ArgumentException(type.ToString());
            }
        }

        public static MessageAuditType GetMessageAuditType(this EventType type)
        {
            switch (type)
            {
                case EventType.MESSAGE_AUDIT_PASS:
                    return MessageAuditType.Pass;
                case EventType.MESSAGE_AUDIT_REJECT:
                    return MessageAuditType.Reject;
                default:
                    throw new ArgumentException(type.ToString());
            }
        }
    }
}