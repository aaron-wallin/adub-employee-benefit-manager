using EBM.Entities.Base;

namespace EBM.Entities
{
    public class Dependent : IBenefitPerson
    {
        public BenefitInfo Benefits { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /*
        protected internal Dependent()
        {

        }
        */
    }
}
