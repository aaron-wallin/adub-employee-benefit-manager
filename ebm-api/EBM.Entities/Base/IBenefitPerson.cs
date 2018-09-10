namespace EBM.Entities.Base
{
    public interface IBenefitPerson : IPerson
    {
        BenefitInfo Benefits { get; }
    }
}
