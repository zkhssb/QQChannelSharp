namespace QQGuildBotFunc.Enumerations
{
    public enum OPCode
    {
        WSDispatchEvent = 0,
        WSHeartbeat = 1,
        WSIdentity = 2,
        WSResume = 6,
        WSReconnect = 7,
        WSInvalidSession = 9,
        WSHello = 10,
        WSHeartbeatAck = 11,
        HTTPCallbackAck = 12,
    }
}
