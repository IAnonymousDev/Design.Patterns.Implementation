using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern.Utilities
{
    public class ExceptionLogger : IInterceptor
    {
        private readonly TextWriter output;

        public ExceptionLogger(TextWriter output)
        {
            this.output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch(Exception ex)
            {
                output.WriteLine("Logged Exception: {0}", ex.Message);
                throw;
            }
        }
    }
}
