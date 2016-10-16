using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchMe.Patterns.Design.Creational
{
    public class AbstractFactory
    {
        public void Run()
        {
            TaxCalculatorFactory factory = new IrishTaxCalculatorFactory();
            
            TaxCalculationRunTime runtime  = new TaxCalculationRunTime(factory);

            runtime.CalculateTaxes();
        }
    }

    public class TaxCalculationRunTime
    {
        private readonly IndividualTaxCalculator _individualTaxCalculator;
        private readonly CorporateTaxCalculator _corporateTaxCalculator;

        public TaxCalculationRunTime(TaxCalculatorFactory factory)
        {
            _individualTaxCalculator = factory.CreateIndividualTaxCalculator();
            _corporateTaxCalculator = factory.CreateCorporateTaxCalculator();
        }

        public void CalculateTaxes()
        {
            _individualTaxCalculator.CalculateTax();
            _corporateTaxCalculator.CalculateTax();
        }
    }

    public abstract class TaxCalculatorFactory
    {
        public abstract IndividualTaxCalculator CreateIndividualTaxCalculator();
        public abstract CorporateTaxCalculator CreateCorporateTaxCalculator();
    }

    public class IrishTaxCalculatorFactory : TaxCalculatorFactory
    {
        public override IndividualTaxCalculator CreateIndividualTaxCalculator()
        {
            return new IrishPayeCalculator();
        }

        public override CorporateTaxCalculator CreateCorporateTaxCalculator()
        {
            return new IrishCorporateTaxCalculator();
        }
    }

    public class UkTaxCalculatorFactory : TaxCalculatorFactory
    {
        public override IndividualTaxCalculator CreateIndividualTaxCalculator()
        {
            return new UkPayeCalculator();
        }

        public override CorporateTaxCalculator CreateCorporateTaxCalculator()
        {
            return new UkCorporateTaxCalculator();
        }
    }

    public abstract class BaseTaxCalculator
    {
        public virtual void CalculateTax() { }
    }

    public abstract class IndividualTaxCalculator : BaseTaxCalculator { }

    public abstract class CorporateTaxCalculator : BaseTaxCalculator { }

    public class IrishPayeCalculator : IndividualTaxCalculator { }

    public class UkPayeCalculator : IndividualTaxCalculator { }

    public class IrishCorporateTaxCalculator : CorporateTaxCalculator { }

    public class UkCorporateTaxCalculator : CorporateTaxCalculator { }
}
