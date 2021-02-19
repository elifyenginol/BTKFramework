using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.Aspects.PostSharp.PerformanceAspects
{
    [Serializable]
    public class PerformancaCounterAspect:OnMethodBoundaryAspect
    {
        //Method başında bir kronometre açıp bitinca kapatacağız ki sistem yönetimi hızı kontrol edilebilsin
        //Eğer bir methodun süresi benim belirdeğim sürenin üstündeyse yapılacak işlemler
        private int _interval;
        private Stopwatch _stopwatch;
        public PerformancaCounterAspect(int interval=5)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                Debug.WriteLine("Performance:{0}.{1}->>{2}", args.Method.DeclaringType.FullName,args.Method.Name,_stopwatch.Elapsed.TotalSeconds);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
