using Application.Services.OutService;

namespace Infrastructure.ServiceAdaters
{
    public class FakeFindeksCreditServiceAdapter : IFindeksCreditService
    {
        public short AssignmentScore()
        {
            short score = 1900;
            return score;
        }

        public short CalcScore(float? rate)
        {
            return rate switch
            {
                100 => 1900,
                80 => 1000,
                60 => 600,
                40 => 4000,
                20 => 200,
                0 => 0,
                _ => 0,
            };
        }

        public short? IterationScore(DateTime customerCreateDate)
        {
            var currentDate = DateTime.Now;
            var customerSeniority = currentDate.Year - customerCreateDate.Year;
            if (customerSeniority >= 5)
            {
                return 1900;
            }
            return null;
        }
    }
}
