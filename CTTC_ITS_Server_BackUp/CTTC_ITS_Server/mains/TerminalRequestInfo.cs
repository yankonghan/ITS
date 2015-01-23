using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;

namespace CTTC_ITS_Server.mains
{
    public class TerminalRequestInfo : RequestInfo<byte[]>
    {
        #region 属性
        /// <summary>
        /// 公交车牌号
        /// </summary>
        private string busID;
        /// <summary>
        /// 公交车牌号
        /// </summary>
        public string BusID
        {
            get
            {
                return this.busID;
            }
            set
            {
                this.busID = value;
            }
        }
        /// <summary>
        /// 信息实时时间
        /// </summary>
        private DateTime infoTime;
        /// <summary>
        /// 信息实时时间
        /// </summary>a
        public DateTime InfoTime
        {
            get
            {
                return this.infoTime;
            }
            set
            {
                this.infoTime = value;
            }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        private TerminalType terminalType;
        /// <summary>
        /// 设备类型
        /// </summary>
        public TerminalType TerminalType
        {
            get
            {
                return this.terminalType;
            }
            set
            {
                terminalType = value;
            }
        }
        /// <summary>
        /// 指令类型
        /// </summary>
        private InfoType infoType;
        /// <summary>
        /// 指令类型
        /// </summary>
        public InfoType InfoType
        {
            get
            {
                return this.infoType;
            }
            set
            {
                infoType = value;
            }
        }
        /// <summary>
        /// 报警类型
        /// </summary>
        private AlarmType alarmType = AlarmType.NoAlarm;
        /// <summary>
        /// 报警类型
        /// </summary>
        private AlarmType AlarmType
        {
            get
            {
                return this.alarmType;
            }
            set
            {
                alarmType = value;
            }
        }
        /// <summary>
        /// 离线类型
        /// </summary>
        private OffLineType offLineType = OffLineType.On;
        /// <summary>
        /// 离线类型
        /// </summary>
        public OffLineType OffLineType
        {
            get
            {
                return this.offLineType;
            }
            set
            {
                offLineType = value;
            }
        }
        /// <summary>
        /// 司机
        /// </summary>
        private string driverID;
        /// <summary>
        /// 司机
        /// </summary>
        public string DriverID
        {
            get
            {
                return this.driverID;
            }
            set
            {
                driverID = value;
            }
        }
        /// <summary>
        /// 速度
        /// </summary>
        private double speed;
        /// <summary>
        /// 速度
        /// </summary>
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        private double lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat
        {
            get
            {
                return this.lat;
            }
            set
            {
                lat = value;
            }
        }
        /// <summary>
        /// 经度
        /// </summary>
        private double lng;
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng
        {
            get
            {
                return this.lng;
            }
            set
            {
                lng = value;
            }
        }
        /// <summary>
        /// 油量
        /// </summary>
        private double oil;
        /// <summary>
        /// 油量
        /// </summary>
        public double Oil
        {
            get
            {
                return this.oil;
            }
            set
            {
                oil = value;
            }
        }
        /// <summary>
        /// 方向
        /// </summary>
        private Forward forward;
        /// <summary>
        /// 方向
        /// </summary>
        public Forward Forward
        {
            get
            {
                return this.forward;
            }
            set
            {
                forward = value;
            }
        }
        /// <summary>
        /// 车上人数
        /// </summary>
        private int peopleNumber;
        /// <summary>
        /// 车上人数
        /// </summary>
        public int PeopleNumber
        {
            get
            {
                return this.peopleNumber;
            }
            set
            {
                peopleNumber = value;
            }
        }

        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="body"></param>
        public TerminalRequestInfo(string key, byte[] body)
            : base(key, body)
        {
            switch (body[1])
            {
                case 0x31://BusTerminal
                    TerminalType = mains.TerminalType.BusTerminal;
                    BusID = Encoding.ASCII.GetString(body, 5, 6);
                    BusOfflineAndAlarm(body);
                    switch (body[2])
                    { 
                        case 0x31://realtimeInfo
                            this.InfoType = mains.InfoType.RealTimeInfo;
                            break;
                        case 0x32://OnlineInfo
                            this.InfoType = mains.InfoType.Online;
                            break;
                        case 0x33://OffLine
                            this.InfoType = mains.InfoType.Offline;
                            break;
                        case 0x34://Alarm
                            this.InfoType = mains.InfoType.AlarmInfo;
                            break;
                        case 0x35://InfoChangeFeedBack
                            this.InfoType = mains.InfoType.InfoChangeFeedBack;
                            break;
                        default:
                            break;
                    
                    }
                    //实时时间
                    GetInfoRealTime(body);
                    //油量
                    GetInfoOil(body);
                    //速度
                    GetInfoSpeed(body);
                    //车上人数
                    GetInfoPeopleNum(body);
                    //司机
                    GetInfoDriver(body);
                    //经纬度
                    GetInfoLatAndLng(body);
                    //方向
                    GetInfoForward(body);
                    //RealTime
                    break;
                case 0x32://manageTerminal
                    TerminalType = TerminalType.Manager;
                    break;
                case 0x33://TaxiTerminal
                    TerminalType = TerminalType.TaxiTerminal;
                    break;
                default:
                    break;
            }
            
        }
        #region 解析数据包包体

        /// <summary>
        /// 信息数据包中的司机
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoForward(byte[] body)
        {
            try
            {
                switch (body[42])
                {
                    case 0x01:
                        this.Forward = mains.Forward.UP;
                        break;
                    case 0x02:
                        this.Forward = mains.Forward.DOWN;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { 
            
            }
        }
        /// <summary>
        /// 信息数据包中的司机
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoLatAndLng(byte[] body)
        {
            try
            {
                //经度
                string tempLng = string.Empty;
                tempLng += Convert.ToInt32(body[28]).ToString();
                tempLng += ".";
                tempLng += Encoding.ASCII.GetString(body, 29, 6);
                this.Lng = Convert.ToDouble(tempLng);
                //经度
                string tempLat = string.Empty;
                tempLat += Convert.ToInt32(body[35]).ToString();
                tempLat += ".";
                tempLat += Encoding.ASCII.GetString(body, 36, 6);
                this.Lat = Convert.ToDouble(tempLat);
            }
            catch (Exception ex)
            { 
                
            }
        }

        /// <summary>
        /// 信息数据包中的司机
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoDriver(byte[] body)
        {
            try
            {
                this.DriverID = Encoding.ASCII.GetString(body, 24, 4);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 信息数据包中的车上人数
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoPeopleNum(byte[] body)
        {
            try
            {
                this.PeopleNumber = Convert.ToInt32(body[20]);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 信息数据包中的速度
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoSpeed(byte[] body)
        {
            try
            {
                string tempSpeed = string.Empty;
                tempSpeed += Convert.ToInt32(body[17]).ToString();
                tempSpeed += ".";
                tempSpeed += Encoding.ASCII.GetString(body, 18, 2);
                this.Speed = Convert.ToDouble(tempSpeed);
            }
            catch (Exception ex)
            { 
            
            }
        }
        /// <summary>
        /// 信息数据包中实时时间
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoRealTime(byte[] body)
        {
            try
            {
                string TempRealTime = string.Empty;
                TempRealTime += Encoding.ASCII.GetString(body, 11, 2);
                TempRealTime += ":";
                TempRealTime += Encoding.ASCII.GetString(body, 13, 2);
                TempRealTime += ":";
                TempRealTime += Encoding.ASCII.GetString(body, 15, 2);
                TempRealTime = DateTime.Now.ToShortDateString() + " " + TempRealTime;
                this.InfoTime = Convert.ToDateTime(TempRealTime);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 信息数据包中油量
        /// </summary>
        /// <param name="body">数据包包体</param>
        private void GetInfoOil(byte[] body)
        {
            try
            {
                string tempOil = string.Empty;
                tempOil += Convert.ToInt32(body[21]).ToString();
                tempOil += ".";
                tempOil += Encoding.ASCII.GetString(body, 22, 2);
                this.Oil = Convert.ToDouble(tempOil);
            }
            catch (Exception ex)
            { 
                
            }
        }
        /// <summary>
        /// 对终端状态进行设置
        /// </summary>
        /// <param name="TerminalRequestBody">数据包体</param>
        private void BusOfflineAndAlarm(byte[] TerminalRequestBody)
        {
            switch (TerminalRequestBody[2])//CommandType
            {
                case 0x31://终端实时普通信息
                    //AlarmType = mains.AlarmType.NoAlarm;
                    break;
                case 0x32://终端开机上线通知
                    //AlarmType = mains.AlarmType.NoAlarm;
                    break;
                case 0x33://终端离线通知
                    //AlarmType = mains.AlarmType.NoAlarm;
                    switch (TerminalRequestBody[4])
                    {
                        case 0x32://正常离线
                            this.OffLineType = mains.OffLineType.Normal;
                            break;
                        case 0x33://强制断电源
                            this.OffLineType = mains.OffLineType.ShutPower;
                            break;
                        default:
                            break;
                    }
                    break;
                case 0x34://终端报警通知
                    switch (TerminalRequestBody[3])
                    {
                        case 0x32://超速
                            this.AlarmType = mains.AlarmType.OverSpeed;
                            break;
                        case 0x33://电子围栏越界
                            this.AlarmType = mains.AlarmType.OverArea;
                            break;
                        default:
                            break;
                    }
                    break;
                case 0x35://终端修改信息执行反馈

                    break;
                case 0x36://终端警报处理执行反馈

                    break;
                default:

                    break;
            }
        }

        #endregion
    }
}
