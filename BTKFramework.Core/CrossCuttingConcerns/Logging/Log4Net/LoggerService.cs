using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
  [Serializable]
    public class LoggerService
    {
        private ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsFatalEnabled;

        public void Info(object logMeesage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMeesage);
            }
        }
        public void Debug(object logMeesage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMeesage);
            }
        }
        public void Warn(object logMeesage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMeesage);
            }
        }
        public void Fatal(object logMeesage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMeesage);
            }
        }
        public void Error(object logMeesage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMeesage);
            }
        }
    }
}
