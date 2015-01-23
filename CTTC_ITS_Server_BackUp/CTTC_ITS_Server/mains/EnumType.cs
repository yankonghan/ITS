using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTTC_ITS_Server.mains
{
    public class EnumType
    {

    }
    enum AlarmType
    { 
        NoAlarm,
        OverSpeed,
        OverArea
    }
    public enum TerminalType
    { 
        Manager,
        BusTerminal,
        TaxiTerminal
    }
    public enum InfoType
    {
        Online,
        Offline,
        AlarmInfo,
        RealTimeInfo,
        InlegalInfo,
        InfoChangeFeedBack
    }


    public enum OffLineType
    {
        On,
        Normal,
        ShutPower
    }

    public enum Forward
    {
        UP ,
        DOWN 
    }
}
