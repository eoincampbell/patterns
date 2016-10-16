using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchMe.Patterns.Design.Creational
{
    public class FactoryMethod
    {
        public void Run()
        {
            Report[] reports = {new TpsReport(), new AnnualKpiResult()};

            var results = reports
                .ToList()
                .Select(r => r.GenerateResult());
        }
    }

    public abstract class ReportResult { }

    public class TpsReportResult : ReportResult { }

    public class AnnaulKpiReportResult : ReportResult { }

    public abstract class Report
    {
        public abstract ReportResult GenerateResult(); //Factory Method
    }

    public class TpsReport : Report
    {
        public override ReportResult GenerateResult()
        {
            return new TpsReportResult();
        }
    }

    public class AnnualKpiResult : Report
    {
        public override ReportResult GenerateResult()
        {
            return new AnnaulKpiReportResult();
        }
    }

}
