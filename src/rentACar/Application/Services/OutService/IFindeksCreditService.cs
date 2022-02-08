namespace Application.Services.OutService
{
    public interface IFindeksCreditService
    {
        short AssignmentScore();
        short? IterationScore(DateTime customerCreateDate);
        short CalcScore(float? rate);
    }
}
