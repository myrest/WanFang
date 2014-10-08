using log4net;
using System;
using System.Text;

namespace Rest.Core.Utility
{
    public sealed class SysLog
    {
        #region Log output marker

        private const string PERFORMANCE = "[Performance]";
        private const string DEBUG = "[Debug      ]";
        private const string EXCPETION = "[Exception  ]";

        #endregion Log output marker

        private ILog logger;

        #region Private Constructor

        private SysLog(Type _type)
        {
            logger = LogManager.GetLogger(_type.Name);
        }

        private SysLog(String _type)
        {
            logger = LogManager.GetLogger(_type);
        }

        #endregion Private Constructor

        #region Static Methods to get an Instance of a Logger

        public static SysLog GetLogger(Type _type)
        {
            return (SysLog)new SysLog(_type);
        }

        public static SysLog GetLogger(String _type)
        {
            return (SysLog)new SysLog(_type);
        }

        #endregion Static Methods to get an Instance of a Logger

        public static bool isDisableLogger()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        #region Logging Methods without parameter priority

        public void Performance(TimeSpan time, string _Message, params object[] objs)
        {
            //GlobalContext.Properties["ModuleName"] = ModuleName;
            if (logger.IsInfoEnabled && !isDisableLogger())
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Info(PERFORMANCE + RequestPerformance(time, _Message));
                }
                else
                {
                    logger.Info(PERFORMANCE + RequestPerformance(time, string.Format(_Message, objs)));
                }
            }
        }

        public void Exception(string _Message, params object[] objs)
        {
            //GlobalContext.Properties["ModuleName"] = ModuleName;
            if (logger.IsErrorEnabled && !isDisableLogger())
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Error(EXCPETION + _Message);
                }
                else
                {
                    logger.Error(EXCPETION + string.Format(_Message, objs));
                }
            }
        }

        public void Exception(Exception error)
        {
            //GlobalContext.Properties["ModuleName"] = ModuleName;
            if (logger.IsErrorEnabled && !isDisableLogger())
            {
                if (error != null)
                {
                    LogError(error, 0);
                }
            }
        }

        public void Debug(string _Message, params object[] objs)
        {
            //GlobalContext.Properties["ModuleName"] = ModuleName;
            if (logger.IsDebugEnabled && !isDisableLogger())
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Debug(DEBUG + _Message);
                }
                else
                {
                    logger.Debug(DEBUG + string.Format(_Message, objs));
                }
            }
        }

        #endregion Logging Methods without parameter priority

        private void LogError(Exception ex, int innerLoop)
        {
            if (isDisableLogger()) return;
            //GlobalContext.Properties["ModuleName"] = ModuleName;
            if (ex != null)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(EXCPETION);
                builder.AppendLine();
                builder.AppendLine(string.Concat("Inner exception number - ", innerLoop));
                builder.AppendLine(ex.Message);
                builder.AppendLine(ex.StackTrace);
                innerLoop++;
                if (ex.InnerException != null)
                {
                    logger.Error(builder.ToString());
                    LogError(ex.InnerException, innerLoop);
                }
                else
                {
                    builder.AppendLine("Main exception & its inner exception Log end");
                    logger.Error(builder.ToString());
                }
            }
        }

        private static readonly TimeSpan fastBound = new TimeSpan(0, 0, 1);

        private string RequestPerformance(TimeSpan timeCost, string logInfo)
        {
            double timeSpan = timeCost.TotalMilliseconds;
            string performance = GetSpeedName(timeSpan);

            if (timeCost < fastBound)
            {
                return string.Format("{0} ,Request Time:[{1}]", logInfo, timeCost);
            }
            else
            {
                return string.Format("{0} ,Request Time:[{1}] {2}", logInfo, timeCost, performance);
            }
        }

        private static string GetSpeedName(double time)
        {
            return (time > 5000 && time <= 10000 ? "[SLOW]" : (time > 10000 ? "[VERYSLOW]" : string.Empty));
        }
    }
}